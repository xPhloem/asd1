using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PayrollSys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //TODO: If button click sql connection initialize
        private void button1_Click(object sender, EventArgs e)
        {
            string SQLConnectkana = "server = 127.0.0.1; user=root; database=payrollsysdb; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(SQLConnectkana);
            string username = txtuser.Text.ToString();  // Username input (either admin or empID)
            string password = txtpass.Text.ToString();  // Password input (either admin or empLastName)

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("No empty fields allowed.");
                return;
            }

            try
            {
                mySqlConnection.Open();

                // Admin login check (both username and password must be 'user')
                if (username.Equals("user") && password.Equals("user"))
                {
                    // Admin login logic: Set IsAdmin to true
                    Form1 mainForm = new Form1();
                    dashboard dashboardForm = new dashboard();
                    dashboardForm.IsAdmin = true; // Set flag to true for admin login
                    this.Hide();
                    mainForm.FormClosed += (s, args) => this.Close();
                    dashboardForm.Show();
                    return; // Skip employee login logic if it's admin
                }

                // Employee login check (using empID and empLastName from the empdata table)
                string query = "SELECT * FROM empdata WHERE empID = @empID AND empLastName = @empLastName";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@empID", username);  // Check empID against username
                mySqlCommand.Parameters.AddWithValue("@empLastName", password);  // Check empLastName against password

                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                if (reader.Read()) // If an employee is found with matching empID and empLastName
                {
                    // Employee login logic: Set IsAdmin to false
                    Form1 mainForm = new Form1();
                    dashboard dashboardForm = new dashboard();
                    dashboardForm.IsAdmin = false; // Set flag to false for employee login
                    this.Hide();
                    mainForm.FormClosed += (s, args) => this.Close();
                    dashboardForm.Show();
                }
                else
                {
                    // If no matching user is found
                    MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
