using MySql.Data.MySqlClient;
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
    public partial class attendance : Form
    {
        string connectionString = "server = 127.0.0.1; user=root; database=payrollsysdb; password="; //importante to sa lahat para maconnect sa sql

        public attendance()
        {
            InitializeComponent();
            InitializeEmployeeIds();
            InitializeTimePickers();
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
                            empcode.Items.Add(reader["empID"].ToString());
                        }
                    }
                }

                empcode.SelectedIndex = 0; //wag mo to galawin, eto lang dahilan para mag cycle lahat nun empID
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee IDs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeTimePickers()
        {
            timein.Value = DateTime.Now;
            timeout.Value = DateTime.Now.AddHours(8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employeeId = empcode.Text;
            DateTime date = empdate.Value.Date;
            TimeSpan timeIn = timein.Value.TimeOfDay;
            TimeSpan timeOut = timeout.Value.TimeOfDay;

            if (timeOut <= timeIn)
            {
                MessageBox.Show("Time Out must be after Time In.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = @"
                        INSERT INTO empattendance (empID, timeIN, timeOUT)
                        VALUES (@empID, @timeIN, @timeOUT)";

                    using (var cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@empID", employeeId);
                        cmd.Parameters.AddWithValue("@timeIN", timeIn);
                        cmd.Parameters.AddWithValue("@timeOUT", timeOut);
                        cmd.ExecuteNonQuery();
                    }
                }

                string message = $"Attendance recorded:\nEmployee ID: {employeeId}\nDate: {date.ToShortDateString()}\nTime In: {timeIn:hh\\:mm}\nTime Out: {timeOut:hh\\:mm}";
                MessageBox.Show(message, "Attendance Recorded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error recording attendance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            empcode.SelectedIndex = 0;
            timein.Value = DateTime.Now;
            timeout.Value = DateTime.Now.AddHours(8);
        }
    }
}

