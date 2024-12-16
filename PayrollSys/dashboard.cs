using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSys
{
    public partial class dashboard : Form
    {
        private bool isAdmin;

        public bool IsAdmin
        {
            get { return isAdmin; }
            set
            {
                isAdmin = value;
                UpdateButtonStates();
            }
        }

        public dashboard()
        {
            InitializeComponent();
        }

        private void UpdateButtonStates()
        {
            // Enable/disable buttons eto un isAdmin flag haup na yan
            if (isAdmin)
            {
                
                btnpayroll.Enabled = true;  
                btnattendance.Enabled = true;  
                btnemp.Enabled = true;  
                btnreport.Enabled = false;
               
                btnpayroll.BackColor = SystemColors.Control;
                btnattendance.BackColor = SystemColors.Control;
                btnemp.BackColor = SystemColors.Control;
                btnreport.BackColor = Color.Gray;
            }
            else
            {
                
                btnpayroll.Enabled = true;  
                btnattendance.Enabled = true; 
                btnemp.Enabled = false;  
                btnreport.Enabled = true;
                
                btnpayroll.BackColor = SystemColors.Control;
                btnattendance.BackColor = SystemColors.Control;
                btnemp.BackColor = Color.Gray;
                btnreport.BackColor = SystemColors.Control;
            }
        }

        private void btnpayroll_Click(object sender, EventArgs e)
        {
            payroll payrollForm = new payroll();
            payrollForm.Show();
        }

        private void btnattendance_Click(object sender, EventArgs e)
        {
            attendance attendanceForm = new attendance();
            attendanceForm.Show();
        }

        private void btnemp_Click(object sender, EventArgs e)
        {
            
            if (btnemp.Enabled)
            {
                employee employeeForm = new employee();
                employeeForm.Show();
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
           
            this.Hide();

            
            Form1 loginForm = new Form1();
            loginForm.Show();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            reports reportsForm = new reports();
            reportsForm.Show();
        }
    }

}
