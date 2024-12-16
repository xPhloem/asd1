namespace PayrollSys
{
    partial class dashboard
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
            this.btnemp = new System.Windows.Forms.Button();
            this.btnpayroll = new System.Windows.Forms.Button();
            this.btnattendance = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnreport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnemp
            // 
            this.btnemp.Location = new System.Drawing.Point(31, 62);
            this.btnemp.Name = "btnemp";
            this.btnemp.Size = new System.Drawing.Size(128, 23);
            this.btnemp.TabIndex = 0;
            this.btnemp.Text = "Employee Management";
            this.btnemp.UseVisualStyleBackColor = true;
            this.btnemp.Click += new System.EventHandler(this.btnemp_Click);
            // 
            // btnpayroll
            // 
            this.btnpayroll.Location = new System.Drawing.Point(165, 62);
            this.btnpayroll.Name = "btnpayroll";
            this.btnpayroll.Size = new System.Drawing.Size(128, 23);
            this.btnpayroll.TabIndex = 1;
            this.btnpayroll.Text = "Payroll";
            this.btnpayroll.UseVisualStyleBackColor = true;
            this.btnpayroll.Click += new System.EventHandler(this.btnpayroll_Click);
            // 
            // btnattendance
            // 
            this.btnattendance.Location = new System.Drawing.Point(299, 62);
            this.btnattendance.Name = "btnattendance";
            this.btnattendance.Size = new System.Drawing.Size(128, 23);
            this.btnattendance.TabIndex = 2;
            this.btnattendance.Text = "Attendance";
            this.btnattendance.UseVisualStyleBackColor = true;
            this.btnattendance.Click += new System.EventHandler(this.btnattendance_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(192, 106);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "LOG OUT";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnreport
            // 
            this.btnreport.Location = new System.Drawing.Point(322, 160);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(128, 23);
            this.btnreport.TabIndex = 4;
            this.btnreport.Text = "GET PAYSLIP";
            this.btnreport.UseVisualStyleBackColor = true;
            this.btnreport.Click += new System.EventHandler(this.btnreport_Click);
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 195);
            this.Controls.Add(this.btnreport);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnattendance);
            this.Controls.Add(this.btnpayroll);
            this.Controls.Add(this.btnemp);
            this.Name = "dashboard";
            this.Text = "dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnemp;
        private System.Windows.Forms.Button btnpayroll;
        private System.Windows.Forms.Button btnattendance;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnreport;
    }
}