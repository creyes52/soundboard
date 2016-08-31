using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using System.IO;

namespace SoundBoardLive {

	public enum Status {
		Empty,
		Playing,
		Paused
	}

	
	/// <summary>
	/// Sound cue playback control
	/// </summary>
	public partial class SoundCue : UserControl {
		IWavePlayer waveOutDevice;
		AudioFileReader audioFileReader;
		Status status;
		String id;
		float volume;

		public string FileName { get; private set; }
		public int Volume {  get { return (int) (volume * 100.0f); } }
		public Status Status { get { return this.status; } }

		public event EventHandler Modified = (a, b) => { };
		public event EventHandler<Int32> VolumeChanged {
			add { volSlider.VolumeChanged += value; }
			remove { volSlider.VolumeChanged -= value; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="FileName"></param>
		public SoundCue(String id) {
			InitializeComponent();
			lblId.Text = id;
			this.id = id;
			this.volume = 1.0f;
			this.volSlider.VolumeChanged += VolSlider_VolumeChanged;
			waveOutDevice = new WaveOut();

			Clear();
		}

		private void VolSlider_VolumeChanged(object sender, int volume) {
			SetVolume(volume);
		}

		private async void btBrowse_Click(object sender, EventArgs e) {
			var dlg = new OpenFileDialog();
			dlg.Filter = "Music files (*.mp3;*.wav,*.m4a)|*.mp3;*.wav;*.m4a";

			DialogResult res = dlg.ShowDialog();

			if (res == DialogResult.OK) {
				await LoadSound(dlg.FileName);
				Modified(this, null);
			}
		}

		private void btPlay_Click(object sender, EventArgs e) {
			if (this.status == Status.Paused)
				this.Play();
			else if (this.status == Status.Playing)
				this.Stop();
		}
		
		private void timer1_Tick(object sender, EventArgs e) {
			progressCue.Value = (int) (100 * audioFileReader.Position / audioFileReader.Length);
			this.lblProgress.Text = String.Format("{0:m\\:ss}/{1:m\\:ss}", audioFileReader.CurrentTime, audioFileReader.TotalTime);

			if ( audioFileReader.Position == audioFileReader.Length ) {
				Stop();
				Restart();
			}
		}



		// --------------------------------------------------------
		//                     music controls
		// --------------------------------------------------------


		/// <summary>
		/// Changes volume to this sound
		/// </summary>
		/// <param name="newVolume">a number between 0 and 100</param>
		public void SetVolume(int newVolume) {
			this.volume = newVolume / 100.0f;
			if ( status != Status.Empty ) {
				audioFileReader.Volume = this.volume;
			}
		}

		/// <summary>
		/// Resets the cue to Empty state, stops playback if necessary
		/// </summary>
		public void Clear() {

			if ( status == Status.Playing ) {
				Stop();
			}

			if ( status != Status.Empty) {
				audioFileReader.Close();
			}
			
			lblFile.Text = "";
			lblProgress.Text = "";
			FileName = null;
			progressCue.Value = 0;
			progressCue.Visible = false;

			status = Status.Empty;
			timer1.Enabled = false;
		}

		/// <summary>
		/// Loads a sound, stops and clears any previous playing sound
		/// </summary>
		/// <param name="FileName"></param>
		/// <returns></returns>
		public async Task LoadSound(String FileName) {
			System.Diagnostics.Debug.WriteLine(String.Format("Loading: {0}", FileName));
			Clear();

			this.FileName = FileName;
			lblFile.Text = Path.GetFileName(FileName);
			lblProgress.Text = "Cargando...";

			await Task.Run(() => {
				audioFileReader = new AudioFileReader(FileName);
				waveOutDevice.Init(audioFileReader);
			});

			lblProgress.Text = "";
			btPlay.Enabled = true;
			this.progressCue.Visible = true;
			status = Status.Paused;
		}
		
		/// <summary>
		/// Restarts the sound to its initial position (either when playing or stopped)
		/// </summary>
		public void Restart() {
			if (status != Status.Empty) {
				audioFileReader.Position = 0;
				progressCue.Value = 0;
			}
		}
		
		/// <summary>
		/// Starts playback
		/// </summary>
		public void Play() {
			if (status == Status.Paused) {
				waveOutDevice.Play();

				btPlay.Text = "Pause";
				timer1.Enabled = true;
				progressCue.Visible = true;

				status = Status.Playing;
				this.BackColor = Color.Thistle;
			}
		}

		/// <summary>
		/// Stops current playback
		/// </summary>
		public void Stop() {
			if ( status == Status.Playing) {
				waveOutDevice.Pause();

				btPlay.Text = "Play";

				timer1.Enabled = false;
				status = Status.Paused;
				this.BackColor = Color.Transparent;
			}
		}

		private void btnLimpiar_Click(object sender, EventArgs e) {
			Clear();
		}
	}
}
