namespace WhoIsDemo.form
{
    partial class frmEntryControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntryControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.pic8 = new System.Windows.Forms.PictureBox();
            this.pic6 = new System.Windows.Forms.PictureBox();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.pic5 = new System.Windows.Forms.PictureBox();
            this.pic7 = new System.Windows.Forms.PictureBox();
            this.pic9 = new System.Windows.Forms.PictureBox();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.imbVideo = new Emgu.CV.UI.ImageBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imbVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pic1);
            this.splitContainer1.Panel1.Controls.Add(this.pic8);
            this.splitContainer1.Panel1.Controls.Add(this.pic6);
            this.splitContainer1.Panel1.Controls.Add(this.pic4);
            this.splitContainer1.Panel1.Controls.Add(this.pic2);
            this.splitContainer1.Panel1.Controls.Add(this.pic3);
            this.splitContainer1.Panel1.Controls.Add(this.pic5);
            this.splitContainer1.Panel1.Controls.Add(this.pic7);
            this.splitContainer1.Panel1.Controls.Add(this.pic9);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnRestart);
            this.splitContainer1.Panel2.Controls.Add(this.btnStop);
            this.splitContainer1.Panel2.Controls.Add(this.btnStart);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.imbVideo);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Size = new System.Drawing.Size(1295, 828);
            this.splitContainer1.SplitterDistance = 269;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(489, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Personas registradas";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(494, 37);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(789, 486);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Cámara";
            // 
            // pic1
            // 
            this.pic1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pic1.Image = global::WhoIsDemo.Properties.Resources.account;
            this.pic1.Location = new System.Drawing.Point(563, 12);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(170, 230);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 9;
            this.pic1.TabStop = false;
            this.pic1.Paint += new System.Windows.Forms.PaintEventHandler(this.pic1_Paint);
            // 
            // pic8
            // 
            this.pic8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pic8.Image = ((System.Drawing.Image)(resources.GetObject("pic8.Image")));
            this.pic8.Location = new System.Drawing.Point(1117, 187);
            this.pic8.Name = "pic8";
            this.pic8.Size = new System.Drawing.Size(40, 54);
            this.pic8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic8.TabIndex = 8;
            this.pic8.TabStop = false;
            this.pic8.Paint += new System.Windows.Forms.PaintEventHandler(this.pic8_Paint);
            // 
            // pic6
            // 
            this.pic6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pic6.Image = ((System.Drawing.Image)(resources.GetObject("pic6.Image")));
            this.pic6.Location = new System.Drawing.Point(1031, 133);
            this.pic6.Name = "pic6";
            this.pic6.Size = new System.Drawing.Size(80, 108);
            this.pic6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic6.TabIndex = 7;
            this.pic6.TabStop = false;
            this.pic6.Paint += new System.Windows.Forms.PaintEventHandler(this.pic6_Paint);
            // 
            // pic4
            // 
            this.pic4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pic4.Image = ((System.Drawing.Image)(resources.GetObject("pic4.Image")));
            this.pic4.Location = new System.Drawing.Point(905, 80);
            this.pic4.Name = "pic4";
            this.pic4.Size = new System.Drawing.Size(120, 162);
            this.pic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic4.TabIndex = 6;
            this.pic4.TabStop = false;
            this.pic4.Paint += new System.Windows.Forms.PaintEventHandler(this.pic4_Paint);
            // 
            // pic2
            // 
            this.pic2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pic2.Image = ((System.Drawing.Image)(resources.GetObject("pic2.Image")));
            this.pic2.Location = new System.Drawing.Point(739, 26);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(160, 216);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 5;
            this.pic2.TabStop = false;
            this.pic2.Paint += new System.Windows.Forms.PaintEventHandler(this.pic2_Paint);
            // 
            // pic3
            // 
            this.pic3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pic3.Image = ((System.Drawing.Image)(resources.GetObject("pic3.Image")));
            this.pic3.Location = new System.Drawing.Point(397, 26);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(160, 216);
            this.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic3.TabIndex = 4;
            this.pic3.TabStop = false;
            this.pic3.Paint += new System.Windows.Forms.PaintEventHandler(this.pic3_Paint);
            // 
            // pic5
            // 
            this.pic5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pic5.Image = ((System.Drawing.Image)(resources.GetObject("pic5.Image")));
            this.pic5.Location = new System.Drawing.Point(271, 79);
            this.pic5.Name = "pic5";
            this.pic5.Size = new System.Drawing.Size(120, 162);
            this.pic5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic5.TabIndex = 3;
            this.pic5.TabStop = false;
            this.pic5.Paint += new System.Windows.Forms.PaintEventHandler(this.pic5_Paint);
            // 
            // pic7
            // 
            this.pic7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pic7.Image = ((System.Drawing.Image)(resources.GetObject("pic7.Image")));
            this.pic7.Location = new System.Drawing.Point(185, 133);
            this.pic7.Name = "pic7";
            this.pic7.Size = new System.Drawing.Size(80, 108);
            this.pic7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic7.TabIndex = 2;
            this.pic7.TabStop = false;
            this.pic7.Paint += new System.Windows.Forms.PaintEventHandler(this.pic7_Paint);
            // 
            // pic9
            // 
            this.pic9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pic9.Image = ((System.Drawing.Image)(resources.GetObject("pic9.Image")));
            this.pic9.Location = new System.Drawing.Point(139, 187);
            this.pic9.Name = "pic9";
            this.pic9.Size = new System.Drawing.Size(40, 54);
            this.pic9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic9.TabIndex = 0;
            this.pic9.TabStop = false;
            this.pic9.Paint += new System.Windows.Forms.PaintEventHandler(this.pic9_Paint);
            // 
            // btnRestart
            // 
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnRestart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Image = global::WhoIsDemo.Properties.Resources.cctvR;
            this.btnRestart.Location = new System.Drawing.Point(228, 424);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(68, 43);
            this.btnRestart.TabIndex = 15;
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnStop
            // 
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Image = global::WhoIsDemo.Properties.Resources.cctvX;
            this.btnStop.Location = new System.Drawing.Point(122, 424);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(68, 43);
            this.btnStop.TabIndex = 14;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Image = global::WhoIsDemo.Properties.Resources.cctv;
            this.btnStart.Location = new System.Drawing.Point(16, 424);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(68, 43);
            this.btnStart.TabIndex = 13;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // imbVideo
            // 
            this.imbVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imbVideo.Location = new System.Drawing.Point(16, 37);
            this.imbVideo.Name = "imbVideo";
            this.imbVideo.Size = new System.Drawing.Size(471, 352);
            this.imbVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imbVideo.TabIndex = 2;
            this.imbVideo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::WhoIsDemo.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(419, 424);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 43);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1295, 828);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmEntryControl";
            this.Text = "Control de entrada";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntryControl_FormClosing);
            this.Load += new System.EventHandler(this.frmEntryControl_Load);
            this.Resize += new System.EventHandler(this.frmEntryControl_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imbVideo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.PictureBox pic8;
        private System.Windows.Forms.PictureBox pic6;
        private System.Windows.Forms.PictureBox pic4;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic3;
        private System.Windows.Forms.PictureBox pic5;
        private System.Windows.Forms.PictureBox pic7;
        private System.Windows.Forms.PictureBox pic9;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Emgu.CV.UI.ImageBox imbVideo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
    }
}