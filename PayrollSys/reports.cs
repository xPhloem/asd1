using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PayrollSys
{
    public partial class reports : Form
    {
        string connectionString = "server = 127.0.0.1; user=root; database=payrollsysdb; password="; //importante to sa lahat para maconnect sa sql

        public static object SpecialFolder { get; internal set; }
        public string dataToReport { get; }

        public reports()
        {
            InitializeComponent();

            richTextBoxReport.Text = dataToReport;
        }

        private void reports_Load(object sender, EventArgs e)
        {

            using (var connection = new MySqlConnection(connectionString))
            {

                connection.Open();
                string query = "SELECT empLastName, empFirstName, empMiddleName, pay, empDailyRate FROM empdata WHERE empID = @empID";


                using (var cmd = new MySqlCommand(query, connection))
                {



       
                    }
                }
            }
        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Printing logic (can be extended with PrintDocument)
                MessageBox.Show("Print functionality not implemented yet.", "Info");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {



            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                DefaultExt = "txt",
                FileName = "PayrollReport.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, richTextBoxReport.Text);
                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void richTextBoxReport_TextChanged(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {

        }

        private void richTextBoxReport_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            {
                string mysqlCon = "server=127.0.0.1; user=root; database=payrollsysdb; password=";
                MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);
                mySqlConnection.Open();
                if (textBoxID.Text != "")
                {
                    MySqlCommand command = new MySqlCommand("SELECT workDay, payRate, rateWage, overtimeHour, holidayDaily, holidayPay,grossInc, netInc, deducPagibig,deducPhillhealth, deducSSS, deducLate, deducAbsent FROM emppay WHERE empID = @empID", mySqlConnection);
                    command.Parameters.AddWithValue("@empID", int.Parse(textBoxID.Text));
                    MySqlDataReader da = command.ExecuteReader();
                    while (da.Read())
                    {
                        decimal grossInc = da.GetDecimal(6);
                        decimal OThour = da.GetDecimal(3);
                        decimal HolidayPay = da.GetDecimal(4);
                        decimal TotalPayment = OThour + HolidayPay + grossInc;

                        decimal Pagibig = da.GetDecimal(8);
                        decimal PhilHealth = da.GetDecimal(9);
                        decimal SSS = da.GetDecimal(10);
                        decimal Late = da.GetDecimal(11);
                        decimal Absent = da.GetDecimal(12);

                        decimal TotalDeduction = Pagibig + PhilHealth + SSS +Late + Absent;

                        decimal NetSalary = TotalPayment - TotalDeduction;


                        richTextBoxReport.Text = $"TotalSalary: {TotalPayment}, DEDUCTION: {TotalDeduction}, NetSALARY: {NetSalary}";

                    }
                    mySqlConnection.Close();
                }
            }
        }
    }
}

