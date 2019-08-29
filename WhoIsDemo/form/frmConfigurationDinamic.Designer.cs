namespace WhoIsDemo.form
{
    partial class frmConfigurationDinamic
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblOkDetect = new System.Windows.Forms.Label();
            this.btnDetect = new System.Windows.Forms.Button();
            this.txtAccurancy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMinEye = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaxEye = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaxDetect = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSaveVideos = new System.Windows.Forms.Button();
            this.lvwVideo = new System.Windows.Forms.ListView();
            this.btnSaveVideo = new System.Windows.Forms.Button();
            this.txtIpVideo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblOkDetect);
            this.groupBox2.Controls.Add(this.btnDetect);
            this.groupBox2.Controls.Add(this.txtAccurancy);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtMinEye);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtMaxEye);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtMaxDetect);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(667, 63);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detección";
            // 
            // lblOkDetect
            // 
            this.lblOkDetect.AutoSize = true;
            this.lblOkDetect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkDetect.ForeColor = System.Drawing.Color.Red;
            this.lblOkDetect.Location = new System.Drawing.Point(599, 20);
            this.lblOkDetect.Name = "lblOkDetect";
            this.lblOkDetect.Size = new System.Drawing.Size(0, 20);
            this.lblOkDetect.TabIndex = 34;
            // 
            // btnDetect
            // 
            this.btnDetect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDetect.BackgroundImage = global::WhoIsDemo.Properties.Resources.done;
            this.btnDetect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetect.Location = new System.Drawing.Point(631, 13);
            this.btnDetect.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(31, 31);
            this.btnDetect.TabIndex = 33;
            this.btnDetect.UseVisualStyleBackColor = false;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // txtAccurancy
            // 
            this.txtAccurancy.Location = new System.Drawing.Point(204, 19);
            this.txtAccurancy.Name = "txtAccurancy";
            this.txtAccurancy.Size = new System.Drawing.Size(36, 20);
            this.txtAccurancy.TabIndex = 11;
            this.txtAccurancy.Text = "600";
            this.txtAccurancy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccurancy_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(133, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Accurancy:";
            // 
            // txtMinEye
            // 
            this.txtMinEye.Location = new System.Drawing.Point(526, 19);
            this.txtMinEye.Name = "txtMinEye";
            this.txtMinEye.Size = new System.Drawing.Size(36, 20);
            this.txtMinEye.TabIndex = 9;
            this.txtMinEye.Text = "25";
            this.txtMinEye.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinEye_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(421, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Min Eye Distance:";
            // 
            // txtMaxEye
            // 
            this.txtMaxEye.Location = new System.Drawing.Point(364, 19);
            this.txtMaxEye.Name = "txtMaxEye";
            this.txtMaxEye.Size = new System.Drawing.Size(36, 20);
            this.txtMaxEye.TabIndex = 7;
            this.txtMaxEye.Text = "200";
            this.txtMaxEye.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxEye_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Max Eye Distance:";
            // 
            // txtMaxDetect
            // 
            this.txtMaxDetect.Location = new System.Drawing.Point(83, 19);
            this.txtMaxDetect.Name = "txtMaxDetect";
            this.txtMaxDetect.Size = new System.Drawing.Size(36, 20);
            this.txtMaxDetect.TabIndex = 5;
            this.txtMaxDetect.Text = "1";
            this.txtMaxDetect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxDetect_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Max Detect:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSaveVideos);
            this.groupBox3.Controls.Add(this.lvwVideo);
            this.groupBox3.Controls.Add(this.btnSaveVideo);
            this.groupBox3.Controls.Add(this.txtIpVideo);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(12, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(667, 245);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Video";
            // 
            // btnSaveVideos
            // 
            this.btnSaveVideos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveVideos.BackgroundImage = global::WhoIsDemo.Properties.Resources.save;
            this.btnSaveVideos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveVideos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveVideos.Location = new System.Drawing.Point(631, 204);
            this.btnSaveVideos.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveVideos.Name = "btnSaveVideos";
            this.btnSaveVideos.Size = new System.Drawing.Size(31, 31);
            this.btnSaveVideos.TabIndex = 36;
            this.btnSaveVideos.UseVisualStyleBackColor = false;
            this.btnSaveVideos.Click += new System.EventHandler(this.btnSaveVideos_Click);
            // 
            // lvwVideo
            // 
            this.lvwVideo.FullRowSelect = true;
            this.lvwVideo.GridLines = true;
            this.lvwVideo.HideSelection = false;
            this.lvwVideo.Location = new System.Drawing.Point(11, 49);
            this.lvwVideo.Name = "lvwVideo";
            this.lvwVideo.Size = new System.Drawing.Size(645, 143);
            this.lvwVideo.TabIndex = 35;
            this.lvwVideo.UseCompatibleStateImageBehavior = false;
            this.lvwVideo.View = System.Windows.Forms.View.Details;
            this.lvwVideo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwVideo_KeyDown);
            // 
            // btnSaveVideo
            // 
            this.btnSaveVideo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveVideo.BackgroundImage = global::WhoIsDemo.Properties.Resources.done;
            this.btnSaveVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveVideo.Location = new System.Drawing.Point(631, 13);
            this.btnSaveVideo.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveVideo.Name = "btnSaveVideo";
            this.btnSaveVideo.Size = new System.Drawing.Size(31, 31);
            this.btnSaveVideo.TabIndex = 34;
            this.btnSaveVideo.UseVisualStyleBackColor = false;
            this.btnSaveVideo.Click += new System.EventHandler(this.btnSaveVideo_Click);
            // 
            // txtIpVideo
            // 
            this.txtIpVideo.Location = new System.Drawing.Point(80, 19);
            this.txtIpVideo.Name = "txtIpVideo";
            this.txtIpVideo.Size = new System.Drawing.Size(542, 20);
            this.txtIpVideo.TabIndex = 5;
            this.txtIpVideo.Text = "rtsp://root:admin@192.168.0.10:554/axis-media/media.amp?videocodec=h264&resolutio" +
    "n=640x480";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Path Video:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(576, 350);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Salir";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmConfigurationDinamic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 403);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfigurationDinamic";
            this.Text = "Configuration Dinamic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfigurationDinamic_FormClosing);
            this.Load += new System.EventHandler(this.frmConfigurationDinamic_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblOkDetect;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.TextBox txtAccurancy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMinEye;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaxEye;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaxDetect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvwVideo;
        private System.Windows.Forms.Button btnSaveVideo;
        private System.Windows.Forms.TextBox txtIpVideo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveVideos;
    }
}