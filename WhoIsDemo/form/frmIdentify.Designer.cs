namespace WhoIsDemo.form
{
    partial class frmIdentify
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvImages = new System.Windows.Forms.DataGridView();
            this.btnFast = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvNew = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRepeat = new System.Windows.Forms.DataGridView();
            this.imbVideo = new Emgu.CV.UI.ImageBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imbVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.label3);
            this.splitContainer.Panel1.Controls.Add(this.dgvImages);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.btnFast);
            this.splitContainer.Panel2.Controls.Add(this.label4);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Panel2.Controls.Add(this.dgvNew);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Controls.Add(this.dgvRepeat);
            this.splitContainer.Panel2.Controls.Add(this.imbVideo);
            this.splitContainer.Panel2.Controls.Add(this.btnClose);
            this.splitContainer.Panel2.Controls.Add(this.btnRestart);
            this.splitContainer.Panel2.Controls.Add(this.btnStop);
            this.splitContainer.Panel2.Controls.Add(this.btnStart);
            this.splitContainer.Size = new System.Drawing.Size(1262, 843);
            this.splitContainer.SplitterDistance = 336;
            this.splitContainer.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Personas Detectadas";
            // 
            // dgvImages
            // 
            this.dgvImages.AllowUserToAddRows = false;
            this.dgvImages.AllowUserToDeleteRows = false;
            this.dgvImages.AllowUserToResizeColumns = false;
            this.dgvImages.AllowUserToResizeRows = false;
            this.dgvImages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvImages.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvImages.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImages.ColumnHeadersVisible = false;
            this.dgvImages.Location = new System.Drawing.Point(16, 38);
            this.dgvImages.MultiSelect = false;
            this.dgvImages.Name = "dgvImages";
            this.dgvImages.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvImages.RowHeadersVisible = false;
            this.dgvImages.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvImages.ShowCellErrors = false;
            this.dgvImages.ShowEditingIcon = false;
            this.dgvImages.ShowRowErrors = false;
            this.dgvImages.Size = new System.Drawing.Size(1235, 280);
            this.dgvImages.TabIndex = 0;
            // 
            // btnFast
            // 
            this.btnFast.BackgroundImage = global::WhoIsDemo.Properties.Resources.fast;
            this.btnFast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFast.Location = new System.Drawing.Point(609, 426);
            this.btnFast.Name = "btnFast";
            this.btnFast.Size = new System.Drawing.Size(51, 51);
            this.btnFast.TabIndex = 10;
            this.btnFast.UseVisualStyleBackColor = true;
            
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cámara";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(930, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Personas Nuevas";
            // 
            // dgvNew
            // 
            this.dgvNew.AllowUserToAddRows = false;
            this.dgvNew.AllowUserToDeleteRows = false;
            this.dgvNew.AllowUserToResizeColumns = false;
            this.dgvNew.AllowUserToResizeRows = false;
            this.dgvNew.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvNew.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNew.ColumnHeadersVisible = false;
            this.dgvNew.EnableHeadersVisualStyles = false;
            this.dgvNew.Location = new System.Drawing.Point(933, 46);
            this.dgvNew.MultiSelect = false;
            this.dgvNew.Name = "dgvNew";
            this.dgvNew.RowHeadersVisible = false;
            this.dgvNew.ShowCellErrors = false;
            this.dgvNew.ShowEditingIcon = false;
            this.dgvNew.ShowRowErrors = false;
            this.dgvNew.Size = new System.Drawing.Size(318, 362);
            this.dgvNew.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(606, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Personas Registradas";
            // 
            // dgvRepeat
            // 
            this.dgvRepeat.AllowUserToAddRows = false;
            this.dgvRepeat.AllowUserToDeleteRows = false;
            this.dgvRepeat.AllowUserToResizeColumns = false;
            this.dgvRepeat.AllowUserToResizeRows = false;
            this.dgvRepeat.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvRepeat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRepeat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepeat.ColumnHeadersVisible = false;
            this.dgvRepeat.EnableHeadersVisualStyles = false;
            this.dgvRepeat.Location = new System.Drawing.Point(609, 46);
            this.dgvRepeat.MultiSelect = false;
            this.dgvRepeat.Name = "dgvRepeat";
            this.dgvRepeat.RowHeadersVisible = false;
            this.dgvRepeat.ShowCellErrors = false;
            this.dgvRepeat.ShowEditingIcon = false;
            this.dgvRepeat.ShowRowErrors = false;
            this.dgvRepeat.Size = new System.Drawing.Size(318, 362);
            this.dgvRepeat.TabIndex = 5;
            // 
            // imbVideo
            // 
            this.imbVideo.Location = new System.Drawing.Point(12, 48);
            this.imbVideo.Name = "imbVideo";
            this.imbVideo.Size = new System.Drawing.Size(576, 360);
            this.imbVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imbVideo.TabIndex = 2;
            this.imbVideo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1089, 425);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(162, 52);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnRestart
            // 
            this.btnRestart.Enabled = false;
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.Location = new System.Drawing.Point(426, 425);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(162, 52);
            this.btnRestart.TabIndex = 3;
            this.btnRestart.Text = "Restaurar";
            this.btnRestart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(218, 425);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(162, 52);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Detener";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(12, 425);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(162, 52);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Inicio";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // frmIdentify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 843);
            this.Controls.Add(this.splitContainer);
            this.Name = "frmIdentify";
            this.Text = "Detección y Registro";
            this.Load += new System.EventHandler(this.frmIdentify_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imbVideo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvImages;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnClose;
        private Emgu.CV.UI.ImageBox imbVideo;
        private System.Windows.Forms.DataGridView dgvRepeat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvNew;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnFast;
    }
}