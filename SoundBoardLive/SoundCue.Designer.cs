namespace SoundBoardLive {
	partial class SoundCue {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.btPlay = new System.Windows.Forms.Button();
			this.lblFile = new System.Windows.Forms.Label();
			this.btBrowse = new System.Windows.Forms.Button();
			this.lblId = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.progressCue = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// btPlay
			// 
			this.btPlay.Enabled = false;
			this.btPlay.Location = new System.Drawing.Point(3, 33);
			this.btPlay.Name = "btPlay";
			this.btPlay.Size = new System.Drawing.Size(75, 23);
			this.btPlay.TabIndex = 5;
			this.btPlay.TabStop = false;
			this.btPlay.Text = "Play";
			this.btPlay.UseVisualStyleBackColor = true;
			this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
			// 
			// lblFile
			// 
			this.lblFile.AutoSize = true;
			this.lblFile.Location = new System.Drawing.Point(84, 8);
			this.lblFile.Name = "lblFile";
			this.lblFile.Size = new System.Drawing.Size(0, 13);
			this.lblFile.TabIndex = 4;
			// 
			// btBrowse
			// 
			this.btBrowse.Location = new System.Drawing.Point(3, 3);
			this.btBrowse.Name = "btBrowse";
			this.btBrowse.Size = new System.Drawing.Size(75, 23);
			this.btBrowse.TabIndex = 3;
			this.btBrowse.TabStop = false;
			this.btBrowse.Text = "Buscar";
			this.btBrowse.UseVisualStyleBackColor = true;
			this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
			// 
			// lblId
			// 
			this.lblId.AutoSize = true;
			this.lblId.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblId.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblId.Location = new System.Drawing.Point(255, 38);
			this.lblId.Name = "lblId";
			this.lblId.Size = new System.Drawing.Size(16, 15);
			this.lblId.TabIndex = 6;
			this.lblId.Text = "B";
			// 
			// timer1
			// 
			this.timer1.Interval = 50;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// progressCue
			// 
			this.progressCue.Location = new System.Drawing.Point(87, 31);
			this.progressCue.Name = "progressCue";
			this.progressCue.Size = new System.Drawing.Size(162, 23);
			this.progressCue.TabIndex = 7;
			this.progressCue.Visible = false;
			// 
			// SoundCue
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.progressCue);
			this.Controls.Add(this.lblId);
			this.Controls.Add(this.btPlay);
			this.Controls.Add(this.lblFile);
			this.Controls.Add(this.btBrowse);
			this.Name = "SoundCue";
			this.Size = new System.Drawing.Size(274, 59);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btPlay;
		private System.Windows.Forms.Label lblFile;
		private System.Windows.Forms.Button btBrowse;
		private System.Windows.Forms.Label lblId;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ProgressBar progressCue;
	}
}
