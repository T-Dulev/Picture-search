namespace Picture_search
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCurrFolder = new System.Windows.Forms.Label();
            this.lblSearchFolder = new System.Windows.Forms.Label();
            this.btnSearchFolder = new System.Windows.Forms.Button();
            this.listProgress = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileLenght = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.M = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTotalFound = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.checkDay = new System.Windows.Forms.CheckBox();
            this.checkMonth = new System.Windows.Forms.CheckBox();
            this.checkYear = new System.Windows.Forms.CheckBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.buttonCopyImage = new System.Windows.Forms.Button();
            this.lblDataInfo = new System.Windows.Forms.Label();
            this.buttonCopyBMP = new System.Windows.Forms.Button();
            this.checkAfter = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCurrFolder);
            this.panel1.Location = new System.Drawing.Point(11, 447);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 36);
            this.panel1.TabIndex = 31;
            // 
            // lblCurrFolder
            // 
            this.lblCurrFolder.Location = new System.Drawing.Point(15, 11);
            this.lblCurrFolder.Name = "lblCurrFolder";
            this.lblCurrFolder.Size = new System.Drawing.Size(643, 13);
            this.lblCurrFolder.TabIndex = 0;
            // 
            // lblSearchFolder
            // 
            this.lblSearchFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSearchFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSearchFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.lblSearchFolder.Location = new System.Drawing.Point(114, 44);
            this.lblSearchFolder.Name = "lblSearchFolder";
            this.lblSearchFolder.Size = new System.Drawing.Size(309, 20);
            this.lblSearchFolder.TabIndex = 30;
            // 
            // btnSearchFolder
            // 
            this.btnSearchFolder.Location = new System.Drawing.Point(12, 41);
            this.btnSearchFolder.Name = "btnSearchFolder";
            this.btnSearchFolder.Size = new System.Drawing.Size(96, 23);
            this.btnSearchFolder.TabIndex = 29;
            this.btnSearchFolder.Text = "Търсене в:";
            this.btnSearchFolder.UseVisualStyleBackColor = true;
            this.btnSearchFolder.Click += new System.EventHandler(this.btnSearchFolder_Click);
            // 
            // listProgress
            // 
            this.listProgress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.FileLenght,
            this.M});
            this.listProgress.GridLines = true;
            this.listProgress.Location = new System.Drawing.Point(12, 133);
            this.listProgress.Name = "listProgress";
            this.listProgress.Size = new System.Drawing.Size(670, 308);
            this.listProgress.TabIndex = 28;
            this.listProgress.UseCompatibleStateImageBehavior = false;
            this.listProgress.View = System.Windows.Forms.View.Details;
            this.listProgress.SelectedIndexChanged += new System.EventHandler(this.listProgress_SelectedIndexChanged);
            // 
            // FileName
            // 
            this.FileName.Text = "FileName";
            this.FileName.Width = 487;
            // 
            // FileLenght
            // 
            this.FileLenght.Text = "FileLenght";
            this.FileLenght.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FileLenght.Width = 91;
            // 
            // M
            // 
            this.M.Text = "TakenDateTime";
            this.M.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.M.Width = 141;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 104);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 23);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "Търсене";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTotalFound
            // 
            this.lblTotalFound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTotalFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.lblTotalFound.Location = new System.Drawing.Point(114, 104);
            this.lblTotalFound.Name = "lblTotalFound";
            this.lblTotalFound.Size = new System.Drawing.Size(189, 20);
            this.lblTotalFound.TabIndex = 33;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePicker.Location = new System.Drawing.Point(446, 65);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(105, 20);
            this.dateTimePicker.TabIndex = 34;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // checkDay
            // 
            this.checkDay.AutoSize = true;
            this.checkDay.Checked = true;
            this.checkDay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkDay.Location = new System.Drawing.Point(446, 41);
            this.checkDay.Name = "checkDay";
            this.checkDay.Size = new System.Drawing.Size(35, 18);
            this.checkDay.TabIndex = 35;
            this.checkDay.Text = " ";
            this.checkDay.UseVisualStyleBackColor = true;
            this.checkDay.CheckedChanged += new System.EventHandler(this.checkDay_CheckedChanged);
            // 
            // checkMonth
            // 
            this.checkMonth.AutoSize = true;
            this.checkMonth.Checked = true;
            this.checkMonth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkMonth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkMonth.Location = new System.Drawing.Point(466, 41);
            this.checkMonth.Name = "checkMonth";
            this.checkMonth.Size = new System.Drawing.Size(35, 18);
            this.checkMonth.TabIndex = 36;
            this.checkMonth.Text = " ";
            this.checkMonth.UseVisualStyleBackColor = true;
            this.checkMonth.CheckedChanged += new System.EventHandler(this.checkMonth_CheckedChanged);
            // 
            // checkYear
            // 
            this.checkYear.AutoSize = true;
            this.checkYear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkYear.Location = new System.Drawing.Point(487, 41);
            this.checkYear.Name = "checkYear";
            this.checkYear.Size = new System.Drawing.Size(35, 18);
            this.checkYear.TabIndex = 37;
            this.checkYear.Text = " ";
            this.checkYear.UseVisualStyleBackColor = true;
            this.checkYear.CheckedChanged += new System.EventHandler(this.checkYear_CheckedChanged);
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picPreview.Location = new System.Drawing.Point(688, 12);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(500, 500);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 38;
            this.picPreview.TabStop = false;
            // 
            // buttonCopyImage
            // 
            this.buttonCopyImage.Location = new System.Drawing.Point(564, 489);
            this.buttonCopyImage.Name = "buttonCopyImage";
            this.buttonCopyImage.Size = new System.Drawing.Size(117, 23);
            this.buttonCopyImage.TabIndex = 39;
            this.buttonCopyImage.Text = "Копирай снимката";
            this.buttonCopyImage.UseVisualStyleBackColor = true;
            this.buttonCopyImage.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDataInfo
            // 
            this.lblDataInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDataInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDataInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.lblDataInfo.Location = new System.Drawing.Point(309, 104);
            this.lblDataInfo.Name = "lblDataInfo";
            this.lblDataInfo.Size = new System.Drawing.Size(280, 20);
            this.lblDataInfo.TabIndex = 40;
            // 
            // buttonCopyBMP
            // 
            this.buttonCopyBMP.Location = new System.Drawing.Point(441, 489);
            this.buttonCopyBMP.Name = "buttonCopyBMP";
            this.buttonCopyBMP.Size = new System.Drawing.Size(117, 23);
            this.buttonCopyBMP.TabIndex = 41;
            this.buttonCopyBMP.Text = "Копирай BMP";
            this.buttonCopyBMP.UseVisualStyleBackColor = true;
            this.buttonCopyBMP.Click += new System.EventHandler(this.buttonCopyBMP_Click);
            // 
            // checkAfter
            // 
            this.checkAfter.AutoSize = true;
            this.checkAfter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkAfter.Location = new System.Drawing.Point(564, 65);
            this.checkAfter.Name = "checkAfter";
            this.checkAfter.Size = new System.Drawing.Size(41, 18);
            this.checkAfter.TabIndex = 42;
            this.checkAfter.Text = " <";
            this.checkAfter.UseVisualStyleBackColor = true;
            this.checkAfter.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(595, 101);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(86, 23);
            this.btnRefresh.TabIndex = 43;
            this.btnRefresh.Text = "Refresh 1/2";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 518);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.checkAfter);
            this.Controls.Add(this.buttonCopyBMP);
            this.Controls.Add(this.lblDataInfo);
            this.Controls.Add(this.buttonCopyImage);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.checkYear);
            this.Controls.Add(this.checkMonth);
            this.Controls.Add(this.checkDay);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.lblTotalFound);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSearchFolder);
            this.Controls.Add(this.btnSearchFolder);
            this.Controls.Add(this.listProgress);
            this.Name = "MainForm";
            this.Text = "Picture search";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCurrFolder;
        private System.Windows.Forms.Label lblSearchFolder;
        internal System.Windows.Forms.Button btnSearchFolder;
        private System.Windows.Forms.ListView listProgress;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader FileLenght;
        private System.Windows.Forms.ColumnHeader M;
        internal System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblTotalFound;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.CheckBox checkDay;
        private System.Windows.Forms.CheckBox checkMonth;
        private System.Windows.Forms.CheckBox checkYear;
        private System.Windows.Forms.PictureBox picPreview;
        internal System.Windows.Forms.Button buttonCopyImage;
        private System.Windows.Forms.Label lblDataInfo;
        internal System.Windows.Forms.Button buttonCopyBMP;
        private System.Windows.Forms.CheckBox checkAfter;
        internal System.Windows.Forms.Button btnRefresh;
    }
}

