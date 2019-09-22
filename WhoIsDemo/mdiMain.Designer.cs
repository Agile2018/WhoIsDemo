namespace WhoIsDemo
{
    partial class mdiMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detecciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enrolamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDeEntradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboVideo = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.detecciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(928, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.configuraciónToolStripMenuItem.Text = "&Configuración";
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // detecciónToolStripMenuItem
            // 
            this.detecciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enrolamientoToolStripMenuItem,
            this.controlDeEntradaToolStripMenuItem});
            this.detecciónToolStripMenuItem.Name = "detecciónToolStripMenuItem";
            this.detecciónToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.detecciónToolStripMenuItem.Text = "&Reconocimiento";
            // 
            // enrolamientoToolStripMenuItem
            // 
            this.enrolamientoToolStripMenuItem.Name = "enrolamientoToolStripMenuItem";
            this.enrolamientoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.enrolamientoToolStripMenuItem.Text = "Enrolamiento";
            this.enrolamientoToolStripMenuItem.Click += new System.EventHandler(this.enrolamientoToolStripMenuItem_Click);
            // 
            // controlDeEntradaToolStripMenuItem
            // 
            this.controlDeEntradaToolStripMenuItem.Name = "controlDeEntradaToolStripMenuItem";
            this.controlDeEntradaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.controlDeEntradaToolStripMenuItem.Text = "Control de entrada";
            this.controlDeEntradaToolStripMenuItem.Click += new System.EventHandler(this.controlDeEntradaToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 536);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(928, 22);
            this.statusStrip.TabIndex = 22;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cboVideo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(928, 25);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(98, 22);
            this.toolStripLabel1.Text = "Seleccione video:";
            // 
            // cboVideo
            // 
            this.cboVideo.Name = "cboVideo";
            this.cboVideo.Size = new System.Drawing.Size(121, 25);
            this.cboVideo.ToolTipText = "Select video";
            this.cboVideo.SelectedIndexChanged += new System.EventHandler(this.cboVideo_SelectedIndexChanged);
            // 
            // mdiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::WhoIsDemo.Properties.Resources.agile;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(928, 558);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mdiMain";
            this.Text = "Detección y Registro Facial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mdiMain_FormClosing);
            this.Load += new System.EventHandler(this.mdiMain_Load);
            this.Shown += new System.EventHandler(this.mdiMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detecciónToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cboVideo;
        private System.Windows.Forms.ToolStripMenuItem enrolamientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlDeEntradaToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

