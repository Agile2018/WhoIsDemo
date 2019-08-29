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
            this.globalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parcialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detecciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enrolamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLoadLibrary = new System.Windows.Forms.ToolStripButton();
            this.btnStopLibrary = new System.Windows.Forms.ToolStripButton();
            this.btnReloadLibrary = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnChangeMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cboVideo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboResolution = new System.Windows.Forms.ToolStripComboBox();
            this.controlDeEntradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.detecciónToolStripMenuItem,
            this.herramientasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(890, 24);
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
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.globalToolStripMenuItem,
            this.parcialToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.configuraciónToolStripMenuItem.Text = "&Configuración";
            // 
            // globalToolStripMenuItem
            // 
            this.globalToolStripMenuItem.Name = "globalToolStripMenuItem";
            this.globalToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.globalToolStripMenuItem.Text = "Global";
            this.globalToolStripMenuItem.Click += new System.EventHandler(this.globalToolStripMenuItem_Click);
            // 
            // parcialToolStripMenuItem
            // 
            this.parcialToolStripMenuItem.Name = "parcialToolStripMenuItem";
            this.parcialToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.parcialToolStripMenuItem.Text = "Parcial";
            this.parcialToolStripMenuItem.Click += new System.EventHandler(this.parcialToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
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
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baseDeDatosToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "&Herramientas";
            // 
            // baseDeDatosToolStripMenuItem
            // 
            this.baseDeDatosToolStripMenuItem.Name = "baseDeDatosToolStripMenuItem";
            this.baseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.baseDeDatosToolStripMenuItem.Text = "Base de datos";
            this.baseDeDatosToolStripMenuItem.Click += new System.EventHandler(this.baseDeDatosToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 468);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(890, 22);
            this.statusStrip.TabIndex = 22;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadLibrary,
            this.btnStopLibrary,
            this.btnReloadLibrary,
            this.toolStripSeparator1,
            this.btnChangeMode,
            this.toolStripSeparator2,
            this.cboVideo,
            this.toolStripLabel1,
            this.cboResolution});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(890, 25);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLoadLibrary
            // 
            this.btnLoadLibrary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoadLibrary.Image = global::WhoIsDemo.Properties.Resources.upload;
            this.btnLoadLibrary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadLibrary.Name = "btnLoadLibrary";
            this.btnLoadLibrary.Size = new System.Drawing.Size(23, 22);
            this.btnLoadLibrary.ToolTipText = "Upload library";
            this.btnLoadLibrary.Click += new System.EventHandler(this.btnLoadLibrary_Click);
            // 
            // btnStopLibrary
            // 
            this.btnStopLibrary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopLibrary.Image = global::WhoIsDemo.Properties.Resources.stop;
            this.btnStopLibrary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopLibrary.Name = "btnStopLibrary";
            this.btnStopLibrary.Size = new System.Drawing.Size(23, 22);
            this.btnStopLibrary.ToolTipText = "Stop library";
            this.btnStopLibrary.Click += new System.EventHandler(this.btnStopLibrary_Click);
            // 
            // btnReloadLibrary
            // 
            this.btnReloadLibrary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadLibrary.Image = global::WhoIsDemo.Properties.Resources.reload;
            this.btnReloadLibrary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadLibrary.Name = "btnReloadLibrary";
            this.btnReloadLibrary.Size = new System.Drawing.Size(23, 22);
            this.btnReloadLibrary.ToolTipText = "Reload Library";
            this.btnReloadLibrary.Click += new System.EventHandler(this.btnReloadLibrary_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnChangeMode
            // 
            this.btnChangeMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnChangeMode.Image = global::WhoIsDemo.Properties.Resources.flash;
            this.btnChangeMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeMode.Name = "btnChangeMode";
            this.btnChangeMode.Size = new System.Drawing.Size(23, 22);
            this.btnChangeMode.ToolTipText = "Change Mode Detection";
            this.btnChangeMode.Click += new System.EventHandler(this.btnChangeMode_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cboVideo
            // 
            this.cboVideo.Name = "cboVideo";
            this.cboVideo.Size = new System.Drawing.Size(121, 25);
            this.cboVideo.ToolTipText = "Select video";
            this.cboVideo.SelectedIndexChanged += new System.EventHandler(this.cboVideo_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel1.Text = "Resolución";
            // 
            // cboResolution
            // 
            this.cboResolution.Items.AddRange(new object[] {
            "320x240",
            "640x480",
            "1280x960"});
            this.cboResolution.Name = "cboResolution";
            this.cboResolution.Size = new System.Drawing.Size(121, 25);
            this.cboResolution.SelectedIndexChanged += new System.EventHandler(this.cboResolution_SelectedIndexChanged);
            // 
            // controlDeEntradaToolStripMenuItem
            // 
            this.controlDeEntradaToolStripMenuItem.Name = "controlDeEntradaToolStripMenuItem";
            this.controlDeEntradaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.controlDeEntradaToolStripMenuItem.Text = "Control de entrada";
            this.controlDeEntradaToolStripMenuItem.Click += new System.EventHandler(this.controlDeEntradaToolStripMenuItem_Click);
            // 
            // mdiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 490);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mdiMain";
            this.Text = "Detección y Registro Facial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mdiMain_FormClosing);
            this.Load += new System.EventHandler(this.mdiMain_Load);
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
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLoadLibrary;
        private System.Windows.Forms.ToolStripButton btnStopLibrary;
        private System.Windows.Forms.ToolStripButton btnReloadLibrary;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnChangeMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox cboVideo;
        private System.Windows.Forms.ToolStripMenuItem globalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parcialToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboResolution;
        private System.Windows.Forms.ToolStripMenuItem enrolamientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlDeEntradaToolStripMenuItem;
    }
}

