using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using System.IO;

namespace SoundBoardLive {
	public partial class Main : Form {

		Dictionary<char, SoundCue> cues;
		SoundSessionFile Session;
		private Graphics graph;
		private bool _modified;

		public Main() {
			InitializeComponent();
			this.Session = new SoundSessionFile();
			this.cues = new Dictionary<char, SoundCue>();
			
			// initialize cue controls
			String flow = "QAZWSXEDCRFVTGBYHN";
			foreach (char n in flow.ToCharArray()) {
				var cueControl = new SoundCue(n.ToString());
				cueControl.Modified += Cue_Modified;
				cueControl.VolumeChanged += Cue_Volume;

				cues.Add(n, cueControl);// add to data model
				lstCues.Controls.Add(cueControl);// add to UI
			}

			// initialize sound chart, comment
			graph = panelTransport.CreateGraphics();
			graph.Clear(Color.Black);
		}

		private void Cue_Volume(object sender, int e) {
			_setModified(true);
		}

		private void Cue_Modified(object sender, EventArgs e) {
			_setModified(true);
		}
		
		private bool _setModified(bool newState) {
			bool current = this._modified;
			if ( !_modified && newState ) {
				this.Text = this.Text + " *";
			}
			this._modified = newState;
			return current;
		}
		
		private void CheckForModifications() {
			if (_modified) {
				DialogResult outDlg = MessageBox.Show("¿Desea guardar los cambios actuales?", "Session modificada", MessageBoxButtons.YesNo);
				if (outDlg == DialogResult.Yes) {
					SaveSession();
				}
			}
		}




		private async Task _loadSession(SoundSessionFile session) {
			this.Session = session;
			this.Text = Path.GetFileName(session.FileName);
			_setModified(false);

			ClearAll();

			// update the UI
			foreach (var pair in this.Session.FileList) {
				SoundCue soundCue;
				if (cues.TryGetValue(pair.Key, out soundCue)) {
					if (pair.Value != null) {
						await soundCue.LoadSound(pair.Value.FilePath);
						soundCue.SetVolume(pair.Value.volume);
					}
				}
			}
		}

		private async void LoadSession(String FileName) {
            try
            {
                var session = SoundSessionFile.Load(FileName);
                await _loadSession(session);
            } catch(Exception e)
            {
                MessageBox.Show("Ha ocurrido un problema", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
			
		}

		private void StopAll() {
			// stop everything
			foreach (var cue in cues) {
				cue.Value.Stop();
			}
		}

		private void ClearAll() {
			// stop everything
			foreach (var cue in cues) {
				cue.Value.Clear();
			}
		}

		private void SaveSession() {
			String FileDest = null;

			// find file
			if (this.Session.FileName == null) {
				var dlg = new SaveFileDialog();
				dlg.Filter = "soundboard (*.sbd)|*.sbd";

				DialogResult res = dlg.ShowDialog();
				if (res != DialogResult.OK) {
					return;
				}

				FileDest = dlg.FileName;
			} else {
				FileDest = this.Session.FileName;
			}

			// update session model
			foreach (var cue in cues) {
				if( cue.Value.Status != Status.Empty) {
					this.Session.FileList[cue.Key] = new SoundCueInfo(cue.Value.FileName, cue.Value.Volume);
				} else {
					this.Session.FileList[cue.Key] = null;
				}
			}

			this.Session.Save(FileDest);
			this.Text = Path.GetFileName(FileDest);
			_setModified(false);
		}
		
		private void OpenSessionFile() {
			var dlg = new OpenFileDialog();
			dlg.Filter = "soundboard (*.sbd)|*.sbd";
			DialogResult res = dlg.ShowDialog();
			if (res == DialogResult.OK) {
				StopAll();

				try {
					LoadSession(dlg.FileName);
				} catch (Exception ex) {
					MessageBox.Show(ex.Message, "Hubo un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}


		private void Main_KeyUp(object sender, KeyEventArgs e) {
			SoundCue soundCue;
			if (cues.TryGetValue((char)e.KeyValue, out soundCue)) {
				if (e.Shift) {
					soundCue.Restart();
				} else {
					if ( soundCue.Status == Status.Paused) {
						soundCue.Play();
					} else {
						soundCue.Stop();
					}
				}
			}
		}
		
		private void cargarToolStripMenuItem_Click_1(object sender, EventArgs e) {
			CheckForModifications();
			OpenSessionFile();
		}
		
		private void guardarToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveSession();
		}

		private void salirToolStripMenuItem_Click(object sender, EventArgs e) {
			CheckForModifications();
			this.Close();
		}

		private async void nuevoToolStripMenuItem_Click(object sender, EventArgs e) {
			CheckForModifications();
			var session = new SoundSessionFile();
			await _loadSession(session);
		}


		private void cargarMusicaToolStripMenuItem_Click(object sender, EventArgs e) {
			var dlg = new OpenFileDialog();
			dlg.Filter = "Music files (*.mp3;*.wav)|*.mp3;*.wav";

			DialogResult res = dlg.ShowDialog();

			if (res == DialogResult.OK) {
				var audioFileReader = new AudioFileReader(dlg.FileName);
			}
		}
	}
}
