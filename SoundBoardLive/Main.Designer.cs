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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panelTransport = new System.Windows.Forms.Panel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cargarMusicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstCues
			// 
			this.lstCues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstCues.BackColor = System.Drawing.Color.LightSteelBlue;
			this.lstCues.Location = new System.Drawing.Point(0, 29);
			this.lstCues.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
			this.lstCues.Name = "lstCues";
			this.lstCues.Size = new System.Drawing.Size(841, 271);
			this.lstCues.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(841, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// archivoToolStripMenuItem
			// 
			this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.salirToolStripMenuItem,
            this.toolStripSeparator1,
            this.cargarMusicaToolStripMenuItem});
			this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
			this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.archivoToolStripMenuItem.Text = "&Archivo";
			// 
			// cargarToolStripMenuItem
			// 
			this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
			this.cargarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.cargarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.cargarToolStripMenuItem.Text = "&Abrir";
			this.cargarToolStripMenuItem.Click += new System.EventHandler(this.cargarToolStripMenuItem_Click_1);
			// 
			// guardarToolStripMenuItem
			// 
			this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
			this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
			this.guardarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.guardarToolStripMenuItem.Text = "&Guardar";
			this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
			// 
			// salirToolStripMenuItem
			// 
			this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
			this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.salirToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.salirToolStripMenuItem.Text = "&Salir";
			this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
			// 
			// panelTransport
			// 
			this.panelTransport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelTransport.BackColor = System.Drawing.Color.Gray;
			this.panelTransport.Location = new System.Drawing.Point(0, 306);
			this.panelTransport.Name = "panelTransport";
			this.panelTransport.Size = new System.Drawing.Size(841, 79);
			this.panelTransport.TabIndex = 2;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
			// 
			// cargarMusicaToolStripMenuItem
			// 
			this.cargarMusicaToolStripMenuItem.Name = "cargarMusicaToolStripMenuItem";
			this.cargarMusicaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
			this.cargarMusicaToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.cargarMusicaToolStripMenuItem.Text = "Cargar &Musica";
			this.cargarMusicaToolStripMenuItem.Click += new System.EventHandler(this.cargarMusicaToolStripMenuItem_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(841, 385);
			this.Controls.Add(this.panelTransport);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.lstCues);
			this.KeyPreview = true;
			this.Name = "Main";
			this.Text = "Session sin titulo";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel lstCues;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
		private System.Windows.Forms.Panel panelTransport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem cargarMusicaToolStripMenuItem;
	}
}

