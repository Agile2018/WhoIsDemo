namespace WhoIsDemo.form
{
    partial class frmConfiguration
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
            this.tcConfiguration = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.cboLevelResolution = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblVideoOk = new System.Windows.Forms.Label();
            this.btnSaveVideosFile = new System.Windows.Forms.Button();
            this.lvwVideo = new System.Windows.Forms.ListView();
            this.txtIpVideo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSaveVideoList = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClearDatabase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveDatabase = new System.Windows.Forms.Button();
            this.txtConnect = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNameDatabase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tcConfiguration.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcConfiguration
            // 
            this.tcConfiguration.Controls.Add(this.tabPage1);
            this.tcConfiguration.Controls.Add(this.tabPage2);
            this.tcConfiguration.Controls.Add(this.tabPage3);
            this.tcConfiguration.Location = new System.Drawing.Point(12, 6);
            this.tcConfiguration.Name = "tcConfiguration";
            this.tcConfiguration.SelectedIndex = 0;
            this.tcConfiguration.Size = new System.Drawing.Size(714, 494);
            this.tcConfiguration.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.cboLevelResolution);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(706, 468);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Face";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblOkDetect);
            this.groupBox3.Controls.Add(this.btnDetect);
            this.groupBox3.Controls.Add(this.txtAccurancy);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtMinEye);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtMaxEye);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtMaxDetect);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(89, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 318);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detect";
            // 
            // lblOkDetect
            // 
            this.lblOkDetect.AutoSize = true;
            this.lblOkDetect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkDetect.ForeColor = System.Drawing.Color.Red;
            this.lblOkDetect.Location = new System.Drawing.Point(75, 265);
            this.lblOkDetect.Name = "lblOkDetect";
            this.lblOkDetect.Size = new System.Drawing.Size(0, 20);
            this.lblOkDetect.TabIndex = 54;
            // 
            // btnDetect
            // 
            this.btnDetect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDetect.BackgroundImage = global::WhoIsDemo.Properties.Resources.ic_save_black_48dp;
            this.btnDetect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetect.Location = new System.Drawing.Point(127, 251);
            this.btnDetect.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(55, 51);
            this.btnDetect.TabIndex = 53;
            this.btnDetect.UseVisualStyleBackColor = false;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // txtAccurancy
            // 
            this.txtAccurancy.Location = new System.Drawing.Point(146, 78);
            this.txtAccurancy.Name = "txtAccurancy";
            this.txtAccurancy.Size = new System.Drawing.Size(36, 20);
            this.txtAccurancy.TabIndex = 52;
            this.txtAccurancy.Text = "600";
            this.txtAccurancy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccurancy_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(76, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Accurancy:";
            // 
            // txtMinEye
            // 
            this.txtMinEye.Location = new System.Drawing.Point(146, 184);
            this.txtMinEye.Name = "txtMinEye";
            this.txtMinEye.Size = new System.Drawing.Size(36, 20);
            this.txtMinEye.TabIndex = 50;
            this.txtMinEye.Text = "25";
            this.txtMinEye.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinEye_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Min Eye Distance:";
            // 
            // txtMaxEye
            // 
            this.txtMaxEye.Location = new System.Drawing.Point(146, 131);
            this.txtMaxEye.Name = "txtMaxEye";
            this.txtMaxEye.Size = new System.Drawing.Size(36, 20);
            this.txtMaxEye.TabIndex = 48;
            this.txtMaxEye.Text = "200";
            this.txtMaxEye.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxEye_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Max Eye Distance:";
            // 
            // txtMaxDetect
            // 
            this.txtMaxDetect.Location = new System.Drawing.Point(146, 25);
            this.txtMaxDetect.Name = "txtMaxDetect";
            this.txtMaxDetect.Size = new System.Drawing.Size(36, 20);
            this.txtMaxDetect.TabIndex = 46;
            this.txtMaxDetect.Text = "1";
            this.txtMaxDetect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxDetect_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Max Detect:";
            // 
            // cboLevelResolution
            // 
            this.cboLevelResolution.FormattingEnabled = true;
            this.cboLevelResolution.Items.AddRange(new object[] {
            "Standard",
            "High definition",
            "High definition plus"});
            this.cboLevelResolution.Location = new System.Drawing.Point(469, 25);
            this.cboLevelResolution.Name = "cboLevelResolution";
            this.cboLevelResolution.Size = new System.Drawing.Size(159, 21);
            this.cboLevelResolution.TabIndex = 47;
            this.cboLevelResolution.SelectedIndexChanged += new System.EventHandler(this.cboLevelResolution_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Level resolution:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblVideoOk);
            this.tabPage2.Controls.Add(this.btnSaveVideosFile);
            this.tabPage2.Controls.Add(this.lvwVideo);
            this.tabPage2.Controls.Add(this.txtIpVideo);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.btnSaveVideoList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(706, 468);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Video";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblVideoOk
            // 
            this.lblVideoOk.AutoSize = true;
            this.lblVideoOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoOk.ForeColor = System.Drawing.Color.Red;
            this.lblVideoOk.Location = new System.Drawing.Point(567, 415);
            this.lblVideoOk.Name = "lblVideoOk";
            this.lblVideoOk.Size = new System.Drawing.Size(0, 20);
            this.lblVideoOk.TabIndex = 55;
            // 
            // btnSaveVideosFile
            // 
            this.btnSaveVideosFile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveVideosFile.BackgroundImage = global::WhoIsDemo.Properties.Resources.ic_save_black_48dp;
            this.btnSaveVideosFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveVideosFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveVideosFile.Location = new System.Drawing.Point(621, 401);
            this.btnSaveVideosFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveVideosFile.Name = "btnSaveVideosFile";
            this.btnSaveVideosFile.Size = new System.Drawing.Size(55, 51);
            this.btnSaveVideosFile.TabIndex = 41;
            this.btnSaveVideosFile.UseVisualStyleBackColor = false;
            this.btnSaveVideosFile.Click += new System.EventHandler(this.btnSaveVideosFile_Click);
            // 
            // lvwVideo
            // 
            this.lvwVideo.FullRowSelect = true;
            this.lvwVideo.GridLines = true;
            this.lvwVideo.HideSelection = false;
            this.lvwVideo.Location = new System.Drawing.Point(31, 62);
            this.lvwVideo.Name = "lvwVideo";
            this.lvwVideo.Size = new System.Drawing.Size(645, 320);
            this.lvwVideo.TabIndex = 40;
            this.lvwVideo.UseCompatibleStateImageBehavior = false;
            this.lvwVideo.View = System.Windows.Forms.View.Details;
            this.lvwVideo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwVideo_KeyDown);
            // 
            // txtIpVideo
            // 
            this.txtIpVideo.Location = new System.Drawing.Point(98, 21);
            this.txtIpVideo.Name = "txtIpVideo";
            this.txtIpVideo.Size = new System.Drawing.Size(542, 20);
            this.txtIpVideo.TabIndex = 38;
            this.txtIpVideo.Text = "rtsp://root:admin@192.168.0.10:554/axis-media/media.amp?videocodec=h264&resolutio" +
    "n=640x480";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Path Video:";
            // 
            // btnSaveVideoList
            // 
            this.btnSaveVideoList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveVideoList.BackgroundImage = global::WhoIsDemo.Properties.Resources.done;
            this.btnSaveVideoList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveVideoList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveVideoList.Location = new System.Drawing.Point(649, 15);
            this.btnSaveVideoList.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveVideoList.Name = "btnSaveVideoList";
            this.btnSaveVideoList.Size = new System.Drawing.Size(31, 31);
            this.btnSaveVideoList.TabIndex = 39;
            this.btnSaveVideoList.UseVisualStyleBackColor = false;
            this.btnSaveVideoList.Click += new System.EventHandler(this.btnSaveVideoList_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(706, 468);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Database";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClearDatabase);
            this.groupBox2.Location = new System.Drawing.Point(123, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 113);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clear database";
            // 
            // btnClearDatabase
            // 
            this.btnClearDatabase.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClearDatabase.BackgroundImage = global::WhoIsDemo.Properties.Resources.cached;
            this.btnClearDatabase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearDatabase.Location = new System.Drawing.Point(212, 31);
            this.btnClearDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearDatabase.Name = "btnClearDatabase";
            this.btnClearDatabase.Size = new System.Drawing.Size(55, 51);
            this.btnClearDatabase.TabIndex = 48;
            this.btnClearDatabase.UseVisualStyleBackColor = false;
            this.btnClearDatabase.Click += new System.EventHandler(this.btnClearDatabase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveDatabase);
            this.groupBox1.Controls.Add(this.txtConnect);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNameDatabase);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(123, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 215);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change database";
            // 
            // btnSaveDatabase
            // 
            this.btnSaveDatabase.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveDatabase.BackgroundImage = global::WhoIsDemo.Properties.Resources.lock_reset;
            this.btnSaveDatabase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDatabase.Location = new System.Drawing.Point(366, 125);
            this.btnSaveDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveDatabase.Name = "btnSaveDatabase";
            this.btnSaveDatabase.Size = new System.Drawing.Size(55, 51);
            this.btnSaveDatabase.TabIndex = 47;
            this.btnSaveDatabase.UseVisualStyleBackColor = false;
            this.btnSaveDatabase.Click += new System.EventHandler(this.btnSaveDatabase_Click);
            // 
            // txtConnect
            // 
            this.txtConnect.Location = new System.Drawing.Point(162, 83);
            this.txtConnect.Name = "txtConnect";
            this.txtConnect.Size = new System.Drawing.Size(259, 20);
            this.txtConnect.TabIndex = 46;
            this.txtConnect.Text = "mongodb://localhost:27017";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Connect String:";
            // 
            // txtNameDatabase
            // 
            this.txtNameDatabase.Location = new System.Drawing.Point(162, 57);
            this.txtNameDatabase.Name = "txtNameDatabase";
            this.txtNameDatabase.Size = new System.Drawing.Size(153, 20);
            this.txtNameDatabase.TabIndex = 44;
            this.txtNameDatabase.Text = "dbass";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Name Database:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.BackgroundImage = global::WhoIsDemo.Properties.Resources.ic_clear_black_48dp;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(667, 518);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 51);
            this.btnClose.TabIndex = 54;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 584);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcConfiguration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfiguration";
            this.Text = "Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfiguration_FormClosing);
            this.Load += new System.EventHandler(this.frmConfiguration_Load);
            this.tcConfiguration.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcConfiguration;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cboLevelResolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveVideosFile;
        private System.Windows.Forms.ListView lvwVideo;
        private System.Windows.Forms.Button btnSaveVideoList;
        private System.Windows.Forms.TextBox txtIpVideo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveDatabase;
        private System.Windows.Forms.TextBox txtConnect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNameDatabase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClearDatabase;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.TextBox txtAccurancy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMinEye;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaxEye;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaxDetect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblOkDetect;
        private System.Windows.Forms.Label lblVideoOk;
    }
}