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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblOkDatabase = new System.Windows.Forms.Label();
            this.btnSaveDatabase = new System.Windows.Forms.Button();
            this.txtConnect = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNameDatabase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOkDatabase);
            this.groupBox1.Controls.Add(this.btnSaveDatabase);
            this.groupBox1.Controls.Add(this.txtConnect);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNameDatabase);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base de datos";
            // 
            // lblOkDatabase
            // 
            this.lblOkDatabase.AutoSize = true;
            this.lblOkDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkDatabase.ForeColor = System.Drawing.Color.Red;
            this.lblOkDatabase.Location = new System.Drawing.Point(300, 86);
            this.lblOkDatabase.Name = "lblOkDatabase";
            this.lblOkDatabase.Size = new System.Drawing.Size(0, 20);
            this.lblOkDatabase.TabIndex = 36;
            // 
            // btnSaveDatabase
            // 
            this.btnSaveDatabase.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveDatabase.BackgroundImage = global::WhoIsDemo.Properties.Resources.done;
            this.btnSaveDatabase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDatabase.Location = new System.Drawing.Point(342, 81);
            this.btnSaveDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveDatabase.Name = "btnSaveDatabase";
            this.btnSaveDatabase.Size = new System.Drawing.Size(31, 31);
            this.btnSaveDatabase.TabIndex = 35;
            this.btnSaveDatabase.UseVisualStyleBackColor = false;
            this.btnSaveDatabase.Click += new System.EventHandler(this.btnSaveDatabase_Click);
            // 
            // txtConnect
            // 
            this.txtConnect.Location = new System.Drawing.Point(114, 45);
            this.txtConnect.Name = "txtConnect";
            this.txtConnect.Size = new System.Drawing.Size(259, 20);
            this.txtConnect.TabIndex = 5;
            this.txtConnect.Text = "mongodb://localhost:27017";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Connect String:";
            // 
            // txtNameDatabase
            // 
            this.txtNameDatabase.Location = new System.Drawing.Point(114, 19);
            this.txtNameDatabase.Name = "txtNameDatabase";
            this.txtNameDatabase.Size = new System.Drawing.Size(153, 20);
            this.txtNameDatabase.TabIndex = 3;
            this.txtNameDatabase.Text = "dbass";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Name Database:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(296, 138);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 35);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Salir";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 189);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfiguration";
            this.Text = "Configuration Static";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfiguration_FormClosing);
            this.Load += new System.EventHandler(this.frmConfiguration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtConnect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNameDatabase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOkDatabase;
        private System.Windows.Forms.Button btnSaveDatabase;
    }
}