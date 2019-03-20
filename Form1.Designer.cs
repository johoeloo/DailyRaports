namespace DailyReports
{
    partial class Form1
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
            this.btnCollectData = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnSplitData = new System.Windows.Forms.Button();
            this.btnZipData = new System.Windows.Forms.Button();
            this.btnCreateDrafts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProductType = new System.Windows.Forms.Label();
            this.btnListsOfFiles = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCollectData
            // 
            this.btnCollectData.Location = new System.Drawing.Point(24, 76);
            this.btnCollectData.Name = "btnCollectData";
            this.btnCollectData.Size = new System.Drawing.Size(117, 25);
            this.btnCollectData.TabIndex = 0;
            this.btnCollectData.Text = "zbierz raporty";
            this.btnCollectData.UseVisualStyleBackColor = true;
            this.btnCollectData.Click += new System.EventHandler(this.btnCollectData_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(9, 18);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(66, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "data danych";
            // 
            // btnSplitData
            // 
            this.btnSplitData.Location = new System.Drawing.Point(23, 106);
            this.btnSplitData.Name = "btnSplitData";
            this.btnSplitData.Size = new System.Drawing.Size(117, 25);
            this.btnSplitData.TabIndex = 3;
            this.btnSplitData.Text = "podziel raporty";
            this.btnSplitData.UseVisualStyleBackColor = true;
            this.btnSplitData.Click += new System.EventHandler(this.btnSplitData_Click);
            // 
            // btnZipData
            // 
            this.btnZipData.Location = new System.Drawing.Point(23, 164);
            this.btnZipData.Name = "btnZipData";
            this.btnZipData.Size = new System.Drawing.Size(117, 25);
            this.btnZipData.TabIndex = 4;
            this.btnZipData.Text = "zipuj";
            this.btnZipData.UseVisualStyleBackColor = true;
            this.btnZipData.Click += new System.EventHandler(this.btnZipData_Click);
            // 
            // btnCreateDrafts
            // 
            this.btnCreateDrafts.Location = new System.Drawing.Point(23, 193);
            this.btnCreateDrafts.Name = "btnCreateDrafts";
            this.btnCreateDrafts.Size = new System.Drawing.Size(117, 25);
            this.btnCreateDrafts.TabIndex = 5;
            this.btnCreateDrafts.Text = "przygotuj maile";
            this.btnCreateDrafts.UseVisualStyleBackColor = true;
            this.btnCreateDrafts.Click += new System.EventHandler(this.btnCreateDrafts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 173);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 9;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(86, 18);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker.TabIndex = 12;
            this.dateTimePicker.Value = new System.DateTime(2019, 1, 21, 12, 0, 16, 0);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(268, 76);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 15;
            this.progressBar1.Visible = false;
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(268, 57);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(0, 13);
            this.lblProductType.TabIndex = 16;
            // 
            // btnListsOfFiles
            // 
            this.btnListsOfFiles.Location = new System.Drawing.Point(23, 135);
            this.btnListsOfFiles.Name = "btnListsOfFiles";
            this.btnListsOfFiles.Size = new System.Drawing.Size(117, 25);
            this.btnListsOfFiles.TabIndex = 17;
            this.btnListsOfFiles.Text = "stwórz listy plików";
            this.btnListsOfFiles.UseVisualStyleBackColor = true;
            this.btnListsOfFiles.Click += new System.EventHandler(this.btnListsOfFiles_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 143);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 235);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnListsOfFiles);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreateDrafts);
            this.Controls.Add(this.btnZipData);
            this.Controls.Add(this.btnSplitData);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnCollectData);
            this.Name = "Form1";
            this.Text = "DOK - raporty dzienne";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCollectData;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnSplitData;
        private System.Windows.Forms.Button btnZipData;
        private System.Windows.Forms.Button btnCreateDrafts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Button btnListsOfFiles;
        private System.Windows.Forms.Label label5;
    }
}

