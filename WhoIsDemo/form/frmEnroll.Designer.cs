using WhoIsDemo.view.tool;

namespace WhoIsDemo.form
{
    partial class frmEnroll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnroll));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFrontVideo = new System.Windows.Forms.Button();
            this.btnBackVideo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.pic8 = new System.Windows.Forms.PictureBox();
            this.pic6 = new System.Windows.Forms.PictureBox();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.pic5 = new System.Windows.Forms.PictureBox();
            this.pic7 = new System.Windows.Forms.PictureBox();
            this.pic9 = new System.Windows.Forms.PictureBox();
            this.btnStopLoadFile = new System.Windows.Forms.Button();
            this.flpDatabase = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic9)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
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
            this.splitContainer1.Panel2.Controls.Add(this.btnStopLoadFile);
            this.splitContainer1.Panel2.Controls.Add(this.flpDatabase);
            this.splitContainer1.Panel2.Controls.Add(this.btnLoadFile);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(1095, 844);
            this.splitContainer1.SplitterDistance = 306;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(478, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Enrolamiento";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.btnRestart);
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Location = new System.Drawing.Point(57, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 57);
            this.panel2.TabIndex = 11;
            // 
            // btnRestart
            // 
            this.btnRestart.Enabled = false;
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnRestart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Image = global::WhoIsDemo.Properties.Resources.cctvR;
            this.btnRestart.Location = new System.Drawing.Point(163, 7);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(60, 43);
            this.btnRestart.TabIndex = 16;
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Image = global::WhoIsDemo.Properties.Resources.cctvX;
            this.btnStop.Location = new System.Drawing.Point(82, 7);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(60, 43);
            this.btnStop.TabIndex = 15;
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
            this.btnStart.Location = new System.Drawing.Point(1, 7);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(60, 43);
            this.btnStart.TabIndex = 14;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.btnFrontVideo);
            this.panel1.Controls.Add(this.btnBackVideo);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(805, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 57);
            this.panel1.TabIndex = 10;
            // 
            // btnFrontVideo
            // 
            this.btnFrontVideo.Enabled = false;
            this.btnFrontVideo.FlatAppearance.BorderSize = 0;
            this.btnFrontVideo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnFrontVideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnFrontVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrontVideo.Image = global::WhoIsDemo.Properties.Resources.eye_on;
            this.btnFrontVideo.Location = new System.Drawing.Point(3, 6);
            this.btnFrontVideo.Name = "btnFrontVideo";
            this.btnFrontVideo.Size = new System.Drawing.Size(60, 43);
            this.btnFrontVideo.TabIndex = 3;
            this.btnFrontVideo.UseVisualStyleBackColor = true;
            this.btnFrontVideo.Click += new System.EventHandler(this.btnFrontVideo_Click);
            // 
            // btnBackVideo
            // 
            this.btnBackVideo.Enabled = false;
            this.btnBackVideo.FlatAppearance.BorderSize = 0;
            this.btnBackVideo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnBackVideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnBackVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackVideo.Image = global::WhoIsDemo.Properties.Resources.eye_off;
            this.btnBackVideo.Location = new System.Drawing.Point(87, 6);
            this.btnBackVideo.Name = "btnBackVideo";
            this.btnBackVideo.Size = new System.Drawing.Size(60, 43);
            this.btnBackVideo.TabIndex = 2;
            this.btnBackVideo.UseVisualStyleBackColor = true;
            this.btnBackVideo.Click += new System.EventHandler(this.btnBackVideo_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::WhoIsDemo.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(171, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 43);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pic1
            // 
            this.pic1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pic1.Image = global::WhoIsDemo.Properties.Resources.account;
            this.pic1.Location = new System.Drawing.Point(463, 62);
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
            this.pic8.Location = new System.Drawing.Point(1017, 237);
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
            this.pic6.Location = new System.Drawing.Point(931, 183);
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
            this.pic4.Location = new System.Drawing.Point(805, 130);
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
            this.pic2.Location = new System.Drawing.Point(639, 76);
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
            this.pic3.Location = new System.Drawing.Point(297, 76);
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
            this.pic5.Location = new System.Drawing.Point(171, 129);
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
            this.pic7.Location = new System.Drawing.Point(85, 183);
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
            this.pic9.Location = new System.Drawing.Point(39, 237);
            this.pic9.Name = "pic9";
            this.pic9.Size = new System.Drawing.Size(40, 54);
            this.pic9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic9.TabIndex = 0;
            this.pic9.TabStop = false;
            this.pic9.Paint += new System.Windows.Forms.PaintEventHandler(this.pic9_Paint);
            // 
            // btnStopLoadFile
            // 
            this.btnStopLoadFile.Enabled = false;
            this.btnStopLoadFile.FlatAppearance.BorderSize = 0;
            this.btnStopLoadFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnStopLoadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnStopLoadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopLoadFile.Image = global::WhoIsDemo.Properties.Resources.timer_off;
            this.btnStopLoadFile.Location = new System.Drawing.Point(586, 4);
            this.btnStopLoadFile.Name = "btnStopLoadFile";
            this.btnStopLoadFile.Size = new System.Drawing.Size(39, 30);
            this.btnStopLoadFile.TabIndex = 18;
            this.btnStopLoadFile.UseVisualStyleBackColor = true;
            this.btnStopLoadFile.Click += new System.EventHandler(this.btnStopLoadFile_Click);
            // 
            // flpDatabase
            // 
            this.flpDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpDatabase.AutoScroll = true;
            this.flpDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpDatabase.Location = new System.Drawing.Point(12, 37);
            this.flpDatabase.Name = "flpDatabase";
            this.flpDatabase.Size = new System.Drawing.Size(346, 465);
            this.flpDatabase.TabIndex = 13;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.FlatAppearance.BorderSize = 0;
            this.btnLoadFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnLoadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnLoadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadFile.Image = global::WhoIsDemo.Properties.Resources.file;
            this.btnLoadFile.Location = new System.Drawing.Point(541, 4);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(39, 30);
            this.btnLoadFile.TabIndex = 17;
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(378, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Personas nuevas";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(377, 37);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(706, 465);
            this.flowLayoutPanel1.TabIndex = 11;
            this.flowLayoutPanel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flowLayoutPanel1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Resultados de vigilancia";
            // 
            // frmEnroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(126)))));
            this.ClientSize = new System.Drawing.Size(1095, 844);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmEnroll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Enrolamiento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEnroll_FormClosing);
            this.Load += new System.EventHandler(this.frmEnroll_Load);
            this.Shown += new System.EventHandler(this.frmEnroll_Shown);
            this.Resize += new System.EventHandler(this.frmEnroll_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pic8;
        private System.Windows.Forms.PictureBox pic6;
        private System.Windows.Forms.PictureBox pic4;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic3;
        private System.Windows.Forms.PictureBox pic5;
        private System.Windows.Forms.PictureBox pic7;
        private System.Windows.Forms.PictureBox pic9;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFrontVideo;
        private System.Windows.Forms.Button btnBackVideo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FlowLayoutPanel flpDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnStopLoadFile;
    }
}