using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundBoardLive {
	public partial class VolumeControl : UserControl {
		bool drawing;
		private Graphics graph;
		int volume;
		public event EventHandler<Int32> VolumeChanged = (obj, vol) => { };

		public VolumeControl() {
			InitializeComponent();
			drawing = false;
			volume = 100;
			graph = this.CreateGraphics();
		}

		private void VolumeControl_MouseDown(object sender, MouseEventArgs e) {
			drawing = true;
		}

		private void VolumeControl_MouseUp(object sender, MouseEventArgs e) {
			drawing = false;
		}

		private void VolumeControl_MouseMove(object sender, MouseEventArgs e) {
			int y = this.Height - e.Y;

			if (drawing) {
				volume = (100 * y) / this.Height;
				if (volume > 100) volume = 100;
				if (volume < 0) volume = 0;

				ReDraw();
				VolumeChanged(this, volume);
			}
		}

		private void ReDraw() {
			int y = this.Height - this.volume * this.Height / 100;

			graph.Clear(Color.White);
			graph.FillRectangle(Brushes.Green, new Rectangle(0, y, this.Width, this.Height));
		}
		

		private void VolumeControl_Paint(object sender, PaintEventArgs e) {
			ReDraw();
		}
	}
}
