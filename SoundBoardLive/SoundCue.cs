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

	enum Status {
		Empty,
		Playing,
		Paused,
		Stopped
	}

	
	/// <summary>
	/// Sound cue playback control
	/// </summary>
	public partial class SoundCue : UserControl {
		IWavePlayer waveOutDevice;
		AudioFileReader audioFileReader = null;
		Status status;
		String id;
		public string FileName { get; private set; }
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
		public SoundCue(String id, String FileName = null) {
			InitializeComponent();
			lblId.Text = id;
			this.id = id;
			this.volSlider.VolumeChanged += VolSlider_VolumeChanged;

			Clear();

			if ( FileName != null ) {
				#pragma warning disable CS4014 // Do not await
				LoadSound(FileName);
				#pragma warning restore CS4014 // Do not await
			}
		}

		private void VolSlider_VolumeChanged(object sender, int volume) {
			if ( status != Status.Empty ) {
				float newVolume = volume / 100.0f;
				System.Diagnostics.Debug.WriteLine("Changing volume: " + newVolume);
				audioFileReader.Volume = newVolume;
				//waveOutDevice.Volume = newVolume;
			}
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
			this.Play();
		}
		
		private void timer1_Tick(object sender, EventArgs e) {
			progressCue.Value = (int) (100 * audioFileReader.Position / audioFileReader.Length);
			this.lblProgress.Text = String.Format("{0:m\\:ss}/{1:m\\:ss}", audioFileReader.CurrentTime, audioFileReader.TotalTime);

			if ( audioFileReader.Position == audioFileReader.Length ) {
				Stop();
				Restart();
			}
		}


		/// <summary>
		/// Resets the cue to not loaded state
		/// </summary>
		public void Clear() {
			Stop();

			if ( waveOutDevice != null ) {
				waveOutDevice.Stop();
				waveOutDevice.Dispose();
			}
			waveOutDevice = new WaveOut();
			if ( audioFileReader != null ) {
				audioFileReader.Close();
			}

			lblFile.Text = "";
			FileName = null;
			progressCue.Value = 0;
			progressCue.Visible = false;

			status = Status.Empty;
			timer1.Enabled = false;
		}

		/// <summary>
		/// Loads a sound and changes to stopped state
		/// </summary>
		/// <param name="FileName"></param>
		/// <returns></returns>
		public async Task LoadSound(String FileName) {
			Clear();

			lblFile.Text = Path.GetFileName(FileName);
			this.FileName = FileName;

			
			await Task.Run(() => {
				audioFileReader = new AudioFileReader(FileName);
				waveOutDevice.Init(audioFileReader);

				status = Status.Stopped;
			});

			btPlay.Enabled = true;
			this.progressCue.Visible = true;
		}
		
		/// <summary>
		/// Restarts the sound to its initial position (either when playing or stopped)
		/// </summary>
		public void Restart() {
			if (audioFileReader != null) {
				audioFileReader.Position = 0;
				progressCue.Value = 0;

				//waveOutDevice.Dispose();
				//waveOutDevice = new WaveOut();
				//waveOutDevice.Init(audioFileReader);
			}
		}
		
		/// <summary>
		/// Starts playback
		/// </summary>
		public void Play() {
			if (status == Status.Stopped || status == Status.Paused) {
				waveOutDevice.Play();

				btPlay.Text = "Pause";
				timer1.Enabled = true;
				progressCue.Visible = true;

				status = Status.Playing;
				this.BackColor = Color.Thistle;
			} else if (status == Status.Playing) {
				Stop();
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
				status = Status.Stopped;
				this.BackColor = Color.Transparent;
			}
		}
	}
}
