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
		Playing,
		Paused,
		Empty,
		Stopped
	}

	public partial class SoundCue : UserControl {
		IWavePlayer waveOutDevice;
		AudioFileReader audioFileReader = null;
		Status status;
		String id;


		public SoundCue(String id) {
			InitializeComponent();

			lblId.Text = id;

			this.id = id;
			waveOutDevice = new WaveOut();
			status = Status.Empty;
		}

		private async void btBrowse_Click(object sender, EventArgs e) {
			var f = new OpenFileDialog();
			DialogResult res = f.ShowDialog();

			if (res == DialogResult.OK) {
				
				await LoadSound(f.FileName);

				lblFile.Text = Path.GetFileName(f.FileName);
				btPlay.Enabled = true;
				status = Status.Stopped;
			}
		}

		private async Task LoadSound(String FileName) {
			await Task.Run(() => {
				audioFileReader = new AudioFileReader(FileName);
				waveOutDevice.Init(audioFileReader);
			}); 
		}

		private void btPlay_Click(object sender, EventArgs e) {
			this.Play();
		}

		public void Play() {
			if ( status == Status.Stopped || status == Status.Paused) {
				waveOutDevice.Play();

				btPlay.Text = "Pause";
				status = Status.Playing;
				timer1.Enabled = true;
				progressCue.Visible = true;

			} else if ( status == Status.Playing ) {
				waveOutDevice.Pause();

				btPlay.Text = "Play";
				status = Status.Stopped;
				timer1.Enabled = false;
			}
		}

		public void Reset() {
			if ( audioFileReader != null ) {
				audioFileReader.Position = 0;
			}
		}

		private void timer1_Tick(object sender, EventArgs e) {
			progressCue.Value = (int) (100 * audioFileReader.Position / audioFileReader.Length);
		}
	}
}
