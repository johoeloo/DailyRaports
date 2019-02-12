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
            this.cbNDF = new System.Windows.Forms.CheckBox();
            this.cbPWC = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCollectData
            // 
            this.btnCollectData.Location = new System.Drawing.Point(32, 94);
            this.btnCollectData.Margin = new System.Windows.Forms.Padding(4);
            this.btnCollectData.Name = "btnCollectData";
            this.btnCollectData.Size = new System.Drawing.Size(130, 28);
            this.btnCollectData.TabIndex = 0;
            this.btnCollectData.Text = "zbierz raporty";
            this.btnCollectData.UseVisualStyleBackColor = true;
            this.btnCollectData.Click += new System.EventHandler(this.btnCollectData_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 22);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(86, 17);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "data danych";
            // 
            // btnSplitData
            // 
            this.btnSplitData.Location = new System.Drawing.Point(31, 130);
            this.btnSplitData.Margin = new System.Windows.Forms.Padding(4);
            this.btnSplitData.Name = "btnSplitData";
            this.btnSplitData.Size = new System.Drawing.Size(130, 28);
            this.btnSplitData.TabIndex = 3;
            this.btnSplitData.Text = "podziel raporty";
            this.btnSplitData.UseVisualStyleBackColor = true;
            this.btnSplitData.Click += new System.EventHandler(this.btnSplitData_Click);
            // 
            // btnZipData
            // 
            this.btnZipData.Location = new System.Drawing.Point(32, 166);
            this.btnZipData.Margin = new System.Windows.Forms.Padding(4);
            this.btnZipData.Name = "btnZipData";
            this.btnZipData.Size = new System.Drawing.Size(130, 28);
            this.btnZipData.TabIndex = 4;
            this.btnZipData.Text = "zipuj";
            this.btnZipData.UseVisualStyleBackColor = true;
            this.btnZipData.Click += new System.EventHandler(this.btnZipData_Click);
            // 
            // btnCreateDrafts
            // 
            this.btnCreateDrafts.Location = new System.Drawing.Point(32, 202);
            this.btnCreateDrafts.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateDrafts.Name = "btnCreateDrafts";
            this.btnCreateDrafts.Size = new System.Drawing.Size(130, 28);
            this.btnCreateDrafts.TabIndex = 5;
            this.btnCreateDrafts.Text = "przygotuj maile";
            this.btnCreateDrafts.UseVisualStyleBackColor = true;
            this.btnCreateDrafts.Click += new System.EventHandler(this.btnCreateDrafts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 9;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(115, 22);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker.TabIndex = 12;
            this.dateTimePicker.Value = new System.DateTime(2019, 1, 21, 12, 0, 16, 0);
            // 
            // cbNDF
            // 
            this.cbNDF.AutoSize = true;
            this.cbNDF.Location = new System.Drawing.Point(358, 12);
            this.cbNDF.Name = "cbNDF";
            this.cbNDF.Size = new System.Drawing.Size(127, 21);
            this.cbNDF.TabIndex = 13;
            this.cbNDF.Text = "uwzględnij NDF";
            this.cbNDF.UseVisualStyleBackColor = true;
            // 
            // cbPWC
            // 
            this.cbPWC.AutoSize = true;
            this.cbPWC.Location = new System.Drawing.Point(358, 42);
            this.cbPWC.Name = "cbPWC";
            this.cbPWC.Size = new System.Drawing.Size(130, 21);
            this.cbPWC.TabIndex = 14;
            this.cbPWC.Text = "uwzględnij PWC";
            this.cbPWC.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 271);
            this.Controls.Add(this.cbPWC);
            this.Controls.Add(this.cbNDF);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.CheckBox cbNDF;
        private System.Windows.Forms.CheckBox cbPWC;
    }
}

