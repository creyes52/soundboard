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

namespace SoundBoardLive {
	public partial class Main : Form {
		Dictionary<char, SoundCue> cues;

		public Main() {
			InitializeComponent();
			this.cues = new Dictionary<char, SoundCue>();
			for (char n = 'A'; n < 'P'; n++) {
				cues.Add(n, new SoundCue(n.ToString()));
			}
			
			foreach(var cue in cues) {
				lstCues.Controls.Add(cue.Value);
			}
			System.Diagnostics.Debug.WriteLine("controls:" + lstCues.Controls.Count);
		}

		private void Main_KeyUp(object sender, KeyEventArgs e) {

			SoundCue soundCue;
			if(cues.TryGetValue((char)e.KeyValue, out soundCue)) {
				if ( e.Shift ) {
					soundCue.Reset();
				} else {
					soundCue.Play();
				}
			}
			
		}

	}
}
