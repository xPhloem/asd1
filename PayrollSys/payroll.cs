using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSys
{
    public partial class payroll : Form
    {
        string connectionString = "server = 127.0.0.1; user=root; database=payrollsysdb; password="; //importante to sa lahat para maconnect sa sql

        
        private double YearToDateGross;
        private double YearToDateNet;

        public payroll()
        {
            InitializeComponent();
            InitializeEmployeeIds();





            domainUpDown1.SelectedItemChanged += DomainUpDown1_SelectedItemChanged;
        }


        private void InitializeEmployeeIds()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT empID FROM empdata";

                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            domainUpDown1.Items.Add(reader["empID"].ToString());
                        }
                    }
                }

                domainUpDown1.SelectedIndex = 0; 
                UpdateEmployeeDetails(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee IDs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DomainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            UpdateEmployeeDetails();
        }

        private void UpdateEmployeeDetails()
        {
            try
            {
                string employeeId = domainUpDown1.SelectedItem?.ToString() ?? ""; 
                if (string.IsNullOrEmpty(employeeId)) return;

                
                label20.Text = ""; 
                textBox1.Text = ""; 
                textBox2.Text = ""; 

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT empLastName, empFirstName, empMiddleName, pay, empDailyRate FROM empdata WHERE empID = @empID";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@empID", employeeId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string lastName = reader["empLastName"].ToString();
                                string firstName = reader["empFirstName"].ToString();
                                string middleName = reader["empMiddleName"].ToString();
                                string pay = reader["pay"].ToString();
                                string empDailyRate = reader["empDailyRate"].ToString();

                                
                                label20.Text = $"{lastName}, {firstName} {middleName}";

                                
                                textBox1.Text = pay;

                                
                                textBox2.Text = empDailyRate;
                            }
                            else
                            {
                                label20.Text = "No data found"; 
                                textBox1.Text = "0.00"; 
                                textBox2.Text = "0.00"; 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              string employeeId = domainUpDown1.Text;
                string query = @"
            INSERT INTO emppay (
                empID, pay, workDay, payRate, rateWage, overtimeHour, overtimeRegular, holidayDaily, 
              holidayPay, grossInc, netInc, deducPagibig, deducPhillhealth, deducSSS, deducLate, deducAbsent) 
            VALUES (
                @empID, @pay, @workDay, @payRate, @rateWage, @overtimeHour, @overtimeRegular, @holidayDaily, 
               @holidayPay, @grossInc, @netInc, @deducPagibig, @deducPhillhealth, @deducSSS, @deducLate, @deducAbsent)";
              
                using (var connection = new MySqlConnection(connectionString))
                {
                   connection.Open();
                   using (var cmd = new MySqlCommand(query, connection))
                    {
                       cmd.Parameters.AddWithValue("@empID", employeeId);
                        cmd.Parameters.AddWithValue("@pay", textBox1.Text);
                        cmd.Parameters.AddWithValue("@workDay", textBox3.Text);
                       cmd.Parameters.AddWithValue("@payRate", textBox2.Text);
                    cmd.Parameters.AddWithValue("@rateWage", textBox4.Text);
                        cmd.Parameters.AddWithValue("@overtimeHour", textBox5.Text);
                      cmd.Parameters.AddWithValue("@overtimeRegular", textBox7.Text);
                   cmd.Parameters.AddWithValue("@holidayDaily", textBox6.Text);
                      cmd.Parameters.AddWithValue("@holidayPay", textBox8.Text);
                      cmd.Parameters.AddWithValue("@grossInc", textBox9.Text);
                      cmd.Parameters.AddWithValue("@netInc", textBox10.Text);
                    cmd.Parameters.AddWithValue("@deducPagibig", textBox12.Text);
                     cmd.Parameters.AddWithValue("@deducPhillhealth", textBox13.Text);
                       cmd.Parameters.AddWithValue("@deducSSS", textBox14.Text);
                        cmd.Parameters.AddWithValue("@deducLate", textBox11.Text);
                     cmd.Parameters.AddWithValue("@deducAbsent", textBox15.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Payment data saved successfully for Employee ID: {employeeId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving payment data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            domainUpDown1.SelectedIndex = 0;
            label20.Text = "";
            textBox3.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox6.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox11.Clear();
            textBox15.Clear();
        }

        private void payroll_Load(object sender, EventArgs e)
        {

        }

        private void SaveToFile_Click(object sender, EventArgs e)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Define the file name (you can change "payroll_data.txt" to any desired name)
            string fileName = Path.Combine(docPath, "payroll_data.txt");

            try
            {
                // Collect data from the form controls
                string employeeCode = domainUpDown1.Text;
                string employeeName = label20.Text;
                string payMethod = textBox1.Text;
                string workingDays = textBox3.Text;
                string ratePerDay = textBox2.Text;
                string rateWage = textBox4.Text;

                string hourlyOT = textBox5.Text;
                string regularOT = textBox7.Text;
                string holidayPay = textBox8.Text;
                string dailyHolidayPay = textBox6.Text;

                string grossIncome = textBox9.Text;
                string netIncome = textBox10.Text;

                string pagibig = textBox12.Text;
                string philhealth = textBox13.Text;
                string sss = textBox14.Text;
                string late = textBox11.Text;
                string absent = textBox15.Text;



                // Create the report content
                string reportContent = $"Employee Code: {employeeCode}\n" +
                                       $"Employee Name: {employeeName}\n" +
                                       $"Pay Method: {payMethod}\n" +
                                       $"Working Days: {workingDays}\n" +
                                       $"Rate Per Day: {ratePerDay}\n" +
                                       $"Rate Wage: {rateWage}\n\n" +
                                       "Overtime:\n" +
                                       $"  Hourly OT: {hourlyOT}\n" +
                                       $"  Regular OT: {regularOT}\n" +
                                       $"  Holiday Pay: {holidayPay}\n" +
                                       $"  Daily Holiday Pay: {dailyHolidayPay}\n\n" +
                                       "Deductions:\n" +
                                       $"  Pagibig: {pagibig}\n" +
                                       $"  PhilHealth: {philhealth}\n" +
                                       $"  SSS: {sss}\n" +
                                       $"  Late: {late}\n" +
                                       $"  Absent: {absent}\n\n" +
                                       "Income:\n" +
                                       $"  Gross Income: {grossIncome}\n" +
                                       $"  Net Income: {netIncome}\n";


                // Open the ReportForm with the content
                reports reportForm = new ReportsForm(reportContent);
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Define the file name (you can change "payroll_data.txt" to any desired name)
            string fileName = Path.Combine(docPath, "payroll_data.txt");

            // Create the data string that will be saved to the file
            string dataToSave = "";
            dataToSave += "Employee Code: " + domainUpDown1.Text + Environment.NewLine;
            dataToSave += "Employee Name: " + label20.Text + Environment.NewLine;
            dataToSave += "Payment Method: " + textBox1.Text + Environment.NewLine;
            dataToSave += "Rate Per Day: " + textBox2.Text + Environment.NewLine;
            dataToSave += "Rate Wage: " + textBox4.Text + Environment.NewLine;
            dataToSave += "Working Days: " + textBox3.Text + Environment.NewLine;
            dataToSave += "Hourly OT: " + textBox5.Text + Environment.NewLine;
            dataToSave += "Regular OT: " + textBox7.Text + Environment.NewLine;
            dataToSave += "Holiday Pay: " + textBox8.Text + Environment.NewLine;
            dataToSave += "Pagibig: " + textBox12.Text + Environment.NewLine;
            dataToSave += "PhilHealth: " + textBox13.Text + Environment.NewLine;
            dataToSave += "SSS: " + textBox14.Text + Environment.NewLine;
            dataToSave += "Late: " + textBox11.Text + Environment.NewLine;
            dataToSave += "Absent: " + textBox15.Text + Environment.NewLine;
            dataToSave += "Gross Income: " + textBox9.Text + Environment.NewLine;
            dataToSave += "Net Income: " + textBox10.Text + Environment.NewLine;
            dataToSave += "------------------------------------------------------------" + Environment.NewLine;


           

            try
            {
                // Using StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(fileName, true)) // 'true' to append to the file
                {
                    writer.WriteLine(dataToSave);
                }

                // Notify the user that data was saved successfully
                MessageBox.Show("Payroll data saved successfully to " + fileName);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the file writing process
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {

        }

        internal static void show()
        {
            throw new NotImplementedException();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Remove the redundant event subscription
            // this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            try
            {
                double ratePerDay = Convert.ToDouble(textBox2.Text);
                double workingDays = Convert.ToDouble(textBox3.Text);
                double hourlyOT = Convert.ToDouble(textBox5.Text);
                double regularOT = Convert.ToDouble(textBox7.Text);
                double holidayPay = Convert.ToDouble(textBox8.Text);
                double sss = Convert.ToDouble(textBox14.Text);
                double pagibig = Convert.ToDouble(textBox12.Text);
                double philHealth = Convert.ToDouble(textBox13.Text);
                double lateDeductions = Convert.ToDouble(textBox11.Text);
                double absentDeductions = Convert.ToDouble(textBox15.Text);

                // Step 2: Calculate Total Payment (Gross Income + Overtime Pay + Holiday Pay)
                double grossIncome = ratePerDay * workingDays;
                double totalPayment = grossIncome + hourlyOT + regularOT + holidayPay;

                // Step 3: Calculate Total Deductions (SSS + Pagibig + PhilHealth + Late + Absent)
                double totalDeductions = sss + pagibig + philHealth + lateDeductions + absentDeductions;

                // Step 4: Calculate Net Pay (Total Payment - Total Deductions)
                double netPay = totalPayment - totalDeductions;

                // Step 5: Calculate Year to Date (YTD) values
                YearToDateGross += grossIncome;
                YearToDateNet += netPay;

                // Step 6: Prepare the report data
                string dataToReport = "";
                dataToReport += "Employee Code: " + domainUpDown1.Text + Environment.NewLine;
                dataToReport += "Employee Name: " + label20.Text + Environment.NewLine;
                dataToReport += "Payment Method: " + textBox1.Text + Environment.NewLine;
                dataToReport += "Rate Per Day: " + ratePerDay + Environment.NewLine;
                dataToReport += "Working Days: " + workingDays + Environment.NewLine;
                dataToReport += "Hourly OT: " + hourlyOT + Environment.NewLine;
                dataToReport += "Regular OT: " + regularOT + Environment.NewLine;
                dataToReport += "Holiday Pay: " + holidayPay + Environment.NewLine;
                dataToReport += "SSS: " + sss + Environment.NewLine;
                dataToReport += "Pagibig: " + pagibig + Environment.NewLine;
                dataToReport += "PhilHealth: " + philHealth + Environment.NewLine;
                dataToReport += "Late: " + lateDeductions + Environment.NewLine;
                dataToReport += "Absent: " + absentDeductions + Environment.NewLine;
                dataToReport += "Gross Income: " + grossIncome.ToString("F2") + Environment.NewLine;
                dataToReport += "Total Payment: " + totalPayment.ToString("F2") + Environment.NewLine;
                dataToReport += "Total Deductions: " + totalDeductions.ToString("F2") + Environment.NewLine;
                dataToReport += "Net Pay: " + netPay.ToString("F2") + Environment.NewLine;
                dataToReport += "Year To Date Gross Income: " + YearToDateGross.ToString("F2") + Environment.NewLine;
                dataToReport += "Year To Date Net Income: " + YearToDateNet.ToString("F2") + Environment.NewLine;

                // Step 7: Set the data to the RichTextBox in the Report Form
                ReportForm reportForm = new ReportForm(dataToReport);
                reportForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
    

    internal class ReportsForm : PayrollSys.reports
    {
        private string reportContent;

        public ReportsForm(string reportContent)
        {
            this.reportContent = reportContent;
        }
    }

