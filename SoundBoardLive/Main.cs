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
		bool sessionModified;

		public Main() {
			InitializeComponent();

			this.cues = new Dictionary<char, SoundCue>();
			for (char n = 'A'; n < 'P'; n++) {
				cues.Add(n, new SoundCue(n.ToString()));
			}
			
			foreach(var cue in cues) {
				lstCues.Controls.Add(cue.Value);
				cue.Value.Modified += Cue_Modified;
			}

			this.sessionModified = false;
		}

		private void Cue_Modified(object sender, EventArgs e) {
			if ( sessionModified == false) {
				this.Text = this.Text + " *";
			}
			sessionModified = true;
		}

		private async void LoadSession(String FileName) {
			this.Session = SoundSessionFile.Load(FileName);

			this.Text = Path.GetFileName(FileName);
			this.sessionModified = false;

			// update the UI
			foreach (var pair in this.Session.FileList) {
				SoundCue soundCue;
				if (cues.TryGetValue(pair.Key, out soundCue)) {
					if ( pair.Value != null ) {
						await soundCue.LoadSound(pair.Value);
					} else {
						soundCue.Clear();
					}
				}
			}
		}

		private void SaveSession() {
			String FileDest = null;

			// find file
			if (this.Session == null) {
				var dlg = new SaveFileDialog();
				dlg.Filter = "soundboard (*.sbd)|*.sbd";

				DialogResult res = dlg.ShowDialog();
				if (res == DialogResult.OK) {
					this.Session = new SoundSessionFile();
					FileDest = dlg.FileName;
				} else {
					return;
				}
			} else {
				FileDest = this.Session.FileName;
			}

			// update session
			foreach (var cue in cues) {
				this.Session.FileList[cue.Key] = cue.Value.FileName;
			}

			if ( this.Session != null ) {
				this.Session.Save(FileDest);

				this.Text = Path.GetFileName(FileDest);
				this.sessionModified = false;
			}
		}



		private void Main_KeyUp(object sender, KeyEventArgs e) {
			SoundCue soundCue;
			if (cues.TryGetValue((char)e.KeyValue, out soundCue)) {
				if (e.Shift) {
					soundCue.Restart();
				} else {
					soundCue.Play();
				}
			}
		}
		
		private void guardarToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveSession();
		}

		private void cargarToolStripMenuItem_Click_1(object sender, EventArgs e) {
			if ( this.sessionModified ) {
				DialogResult outDlg = MessageBox.Show("¿Descartar los cambios actuales?", "Session modificada", MessageBoxButtons.YesNo);
				if ( outDlg == DialogResult.No) {
					return;
				}
			}

			var dlg = new OpenFileDialog();
			dlg.Filter = "soundboard (*.sbd)|*.sbd";
			DialogResult res = dlg.ShowDialog();
			if (res == DialogResult.OK) {
				try {
					LoadSession(dlg.FileName);
				} catch (Exception ex) {
					MessageBox.Show(ex.Message, "Hubo un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void salirToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}
