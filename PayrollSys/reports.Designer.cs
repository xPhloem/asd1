namespace PayrollSys
{
    partial class reports
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.richTextBoxReport = new System.Windows.Forms.RichTextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(25, 297);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 28);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(133, 297);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // richTextBoxReport
            // 
            this.richTextBoxReport.Location = new System.Drawing.Point(25, 90);
            this.richTextBoxReport.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxReport.Name = "richTextBoxReport";
            this.richTextBoxReport.Size = new System.Drawing.Size(559, 135);
            this.richTextBoxReport.TabIndex = 3;
            this.richTextBoxReport.Text = "";
            this.richTextBoxReport.TextChanged += new System.EventHandler(this.richTextBoxReport_TextChanged_1);
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(133, 25);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(131, 22);
            this.textBoxID.TabIndex = 4;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "EmployeeCode:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::PayrollSys.Properties.Resources.BOLDBLUE;
            this.ClientSize = new System.Drawing.Size(597, 338);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.richTextBoxReport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPrint);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.reports_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox richTextBoxReport;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label1;
    }
}