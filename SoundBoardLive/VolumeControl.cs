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
		private int _volume;

		public int Volume { get { return _volume; } set { _volume = value; this.Refresh(); } }

		public event EventHandler<Int32> VolumeChanged = (obj, vol) => { };

		public VolumeControl() {
			InitializeComponent();
			drawing = false;
			_volume = 100;
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
				_volume = (100 * y) / this.Height;
				if (_volume > 100) _volume = 100;
				if (_volume < 0) _volume = 0;

				ReDraw();
				VolumeChanged(this, _volume);
			}
		}

		private void ReDraw() {
			int y = this.Height - this._volume * this.Height / 100;

			graph.Clear(Color.White);
			graph.FillRectangle(Brushes.Green, new Rectangle(0, y, this.Width, this.Height));
		}
		

		private void VolumeControl_Paint(object sender, PaintEventArgs e) {
			ReDraw();
		}
	}
}
