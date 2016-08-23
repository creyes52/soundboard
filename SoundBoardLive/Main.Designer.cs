namespace SoundBoardLive {
	partial class Main {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.lstCues = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// lstCues
			// 
			this.lstCues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstCues.Location = new System.Drawing.Point(0, 0);
			this.lstCues.Name = "lstCues";
			this.lstCues.Size = new System.Drawing.Size(840, 353);
			this.lstCues.TabIndex = 0;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(840, 353);
			this.Controls.Add(this.lstCues);
			this.KeyPreview = true;
			this.Name = "Main";
			this.Text = "Form1";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel lstCues;
	}
}

