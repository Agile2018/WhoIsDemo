﻿namespace WhoIsDemo.form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntryControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFrontVideo = new System.Windows.Forms.Button();
            this.btnBackVideo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pic8 = new System.Windows.Forms.PictureBox();
            this.pic6 = new System.Windows.Forms.PictureBox();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.pic5 = new System.Windows.Forms.PictureBox();
            this.pic7 = new System.Windows.Forms.PictureBox();
            this.pic9 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
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
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnFrontVideo);
            this.splitContainer1.Panel1.Controls.Add(this.btnBackVideo);
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.btnRestart);
            this.splitContainer1.Panel1.Controls.Add(this.pic1);
            this.splitContainer1.Panel1.Controls.Add(this.btnStop);
            this.splitContainer1.Panel1.Controls.Add(this.btnStart);
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
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Name = "label2";
            // 
            // btnFrontVideo
            // 
            resources.ApplyResources(this.btnFrontVideo, "btnFrontVideo");
            this.btnFrontVideo.FlatAppearance.BorderSize = 0;
            this.btnFrontVideo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnFrontVideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnFrontVideo.Image = global::WhoIsDemo.Properties.Resources.eye_on;
            this.btnFrontVideo.Name = "btnFrontVideo";
            this.btnFrontVideo.UseVisualStyleBackColor = true;
            this.btnFrontVideo.Click += new System.EventHandler(this.btnFrontVideo_Click);
            // 
            // btnBackVideo
            // 
            resources.ApplyResources(this.btnBackVideo, "btnBackVideo");
            this.btnBackVideo.FlatAppearance.BorderSize = 0;
            this.btnBackVideo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnBackVideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnBackVideo.Image = global::WhoIsDemo.Properties.Resources.eye_off;
            this.btnBackVideo.Name = "btnBackVideo";
            this.btnBackVideo.UseVisualStyleBackColor = true;
            this.btnBackVideo.Click += new System.EventHandler(this.btnBackVideo_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnClose.Image = global::WhoIsDemo.Properties.Resources.close;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRestart
            // 
            resources.ApplyResources(this.btnRestart, "btnRestart");
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnRestart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnRestart.Image = global::WhoIsDemo.Properties.Resources.cctvR;
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // pic1
            // 
            resources.ApplyResources(this.pic1, "pic1");
            this.pic1.Image = global::WhoIsDemo.Properties.Resources.account;
            this.pic1.Name = "pic1";
            this.pic1.TabStop = false;
            this.pic1.Paint += new System.Windows.Forms.PaintEventHandler(this.pic1_Paint);
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnStop.Image = global::WhoIsDemo.Properties.Resources.cctvX;
            this.btnStop.Name = "btnStop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnStart.Image = global::WhoIsDemo.Properties.Resources.cctv;
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pic8
            // 
            resources.ApplyResources(this.pic8, "pic8");
            this.pic8.Name = "pic8";
            this.pic8.TabStop = false;
            this.pic8.Paint += new System.Windows.Forms.PaintEventHandler(this.pic8_Paint);
            // 
            // pic6
            // 
            resources.ApplyResources(this.pic6, "pic6");
            this.pic6.Name = "pic6";
            this.pic6.TabStop = false;
            this.pic6.Paint += new System.Windows.Forms.PaintEventHandler(this.pic6_Paint);
            // 
            // pic4
            // 
            resources.ApplyResources(this.pic4, "pic4");
            this.pic4.Name = "pic4";
            this.pic4.TabStop = false;
            this.pic4.Paint += new System.Windows.Forms.PaintEventHandler(this.pic4_Paint);
            // 
            // pic2
            // 
            resources.ApplyResources(this.pic2, "pic2");
            this.pic2.Name = "pic2";
            this.pic2.TabStop = false;
            this.pic2.Paint += new System.Windows.Forms.PaintEventHandler(this.pic2_Paint);
            // 
            // pic3
            // 
            resources.ApplyResources(this.pic3, "pic3");
            this.pic3.Name = "pic3";
            this.pic3.TabStop = false;
            this.pic3.Paint += new System.Windows.Forms.PaintEventHandler(this.pic3_Paint);
            // 
            // pic5
            // 
            resources.ApplyResources(this.pic5, "pic5");
            this.pic5.Name = "pic5";
            this.pic5.TabStop = false;
            this.pic5.Paint += new System.Windows.Forms.PaintEventHandler(this.pic5_Paint);
            // 
            // pic7
            // 
            resources.ApplyResources(this.pic7, "pic7");
            this.pic7.Name = "pic7";
            this.pic7.TabStop = false;
            this.pic7.Paint += new System.Windows.Forms.PaintEventHandler(this.pic7_Paint);
            // 
            // pic9
            // 
            resources.ApplyResources(this.pic9, "pic9");
            this.pic9.Name = "pic9";
            this.pic9.TabStop = false;
            this.pic9.Paint += new System.Windows.Forms.PaintEventHandler(this.pic9_Paint);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Name = "label1";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // frmEntryControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(81)))));
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmEntryControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntryControl_FormClosing);
            this.Load += new System.EventHandler(this.frmEntryControl_Load);
            this.Shown += new System.EventHandler(this.frmEntryControl_Shown);
            this.Resize += new System.EventHandler(this.frmEntryControl_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
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
        private System.Windows.Forms.Button btnFrontVideo;
        private System.Windows.Forms.Button btnBackVideo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
    }
}