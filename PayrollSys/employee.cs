using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using static Org.BouncyCastle.Math.EC.ECCurve;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data.SqlClient;

namespace PayrollSys
{
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }

        //just in case madelete to anywhere sa code spare naten
        //MySqlConnection mySqlConnection = new MySqlConnection("server = 127.0.0.1; user=root; database=payrollsysdb; password=");

        string query;
        string rdo;
        private void btnempsave_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button2.BackColor = Color.White;

            btnempsave.Enabled = false;
            btnempsave.BackColor = Color.Gray;

            if (string.IsNullOrEmpty(txtcode.Text) || string.IsNullOrEmpty(txtfname.Text) ||
                string.IsNullOrEmpty(txtlname.Text) || string.IsNullOrEmpty(txtmname.Text) ||
                string.IsNullOrEmpty(txtaddress.Text) || string.IsNullOrEmpty(txtcontact.Text) ||
                string.IsNullOrEmpty(txtstatus.Text) || string.IsNullOrEmpty(txtbplace.Text) ||
                string.IsNullOrEmpty(txtage.Text) || string.IsNullOrEmpty(txtemerg.Text) ||
                string.IsNullOrEmpty(txtdrate.Text) || string.IsNullOrEmpty(txtposition.Text) || 
                string.IsNullOrEmpty(txtpay.Text) || string.IsNullOrEmpty(employstat.Text))
                
            {
                MessageBox.Show("One of the boxes is empty. Data is required.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

           
            string gender = rdomale.Checked ? "Male" : "Female";

            
            string query = @"
    INSERT INTO empdata (
        empID, empFirstName, empLastName, empMiddleName, empCon, empStat, empPlaceb, 
        empGen, empBirth, empAge, empEmerg, empDailyRate, empPos, empHire, pay, workstat
    ) VALUES (
        @empID, @empFirstName, @empLastName, @empMiddleName, @empCon, @empStat, @empPlaceb, 
        @empGen, @empBirth, @empAge, @empEmerg, @empDailyRate, @empPos, @empHire, @pay, @workstat
    )";

            
            string connectionString = "server = 127.0.0.1; user=root; database=payrollsysdb; password="; //importante to sa lahat para maconnect sa sql

            try
            {
                DateTime birthDate = dateTimePicker1.Value;

                
                if (!int.TryParse(txtage.Text, out int age))
                {
                    MessageBox.Show("Invalid age. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                if (!decimal.TryParse(txtdrate.Text, out decimal dailyRate))
                {
                    MessageBox.Show("Invalid daily rate. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open(); 

                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@empID", txtcode.Text);
                        cmd.Parameters.AddWithValue("@empFirstName", txtfname.Text);
                        cmd.Parameters.AddWithValue("@empLastName", txtlname.Text);
                        cmd.Parameters.AddWithValue("@empMiddleName", txtmname.Text);
                        cmd.Parameters.AddWithValue("@empCon", txtcontact.Text);
                        cmd.Parameters.AddWithValue("@empStat", txtstatus.Text);
                        cmd.Parameters.AddWithValue("@empPlaceb", txtbplace.Text);
                        cmd.Parameters.AddWithValue("@empGen", gender);
                        cmd.Parameters.AddWithValue("@empBirth", birthDate);
                        cmd.Parameters.AddWithValue("@empAge", age);
                        cmd.Parameters.AddWithValue("@empEmerg", txtemerg.Text);
                        cmd.Parameters.AddWithValue("@empDailyRate", dailyRate);
                        cmd.Parameters.AddWithValue("@empPos", txtposition.Text);
                        cmd.Parameters.AddWithValue("@empHire", DateTime.Now);
                        cmd.Parameters.AddWithValue("@pay", txtpay.Text);
                        cmd.Parameters.AddWithValue("@workstat", employstat.Text);
                        cmd.Parameters.AddWithValue("@empAdd", txtaddress.Text);

                        cmd.ExecuteNonQuery(); 
                    }
                }

                MessageBox.Show("Employee data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnempnew_Click(object sender, EventArgs e)
        {
            txtcode.Text = string.Empty;
            txtfname.Text = string.Empty;
            txtlname.Text = string.Empty;
            txtmname.Text = string.Empty;
            txtcontact.Text = string.Empty;
            txtstatus.Text = string.Empty;

            txtbplace.Text = string.Empty;
            txtaddress.Text = string.Empty;

            rdomale.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            txtage.Text = string.Empty;
            txtemerg.Text = string.Empty;
            txtdrate.Text = string.Empty;
            txtposition.Text = string.Empty;
            txtpay.Text = string.Empty;
            employstat.Text = string.Empty;

            txtfname.Focus();

            button2.Enabled = false;
            button2.BackColor = Color.Gray;

            btnempsave.Enabled = true;
            btnempsave.BackColor = Color.White;
        }





        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "server = 127.0.0.1; user=root; database=payrollsysdb; password="; //importante to sa lahat para maconnect sa sql

            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();

                    
                    if (string.IsNullOrEmpty(txtcode.Text))
                    {
                        MessageBox.Show("Please enter an Employee ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                   
                    string updateQuery = BuildUpdateQuery(out List<MySqlParameter> parameters);

                    if (string.IsNullOrEmpty(updateQuery))
                    {
                        MessageBox.Show("No data was changed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    
                    updateQuery += " WHERE empID = @empID";
                    parameters.Add(new MySqlParameter("@empID", txtcode.Text));

                   
                    ExecuteUpdateQuery(mySqlConnection, updateQuery, parameters);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildUpdateQuery(out List<MySqlParameter> parameters)
        {
            StringBuilder queryBuilder = new StringBuilder("UPDATE empdata SET ");
            parameters = new List<MySqlParameter>();

            
            AppendField(ref queryBuilder, parameters, "@empFirstName", txtfname.Text, "empFirstName");
            AppendField(ref queryBuilder, parameters, "@empLastName", txtlname.Text, "empLastName");
            AppendField(ref queryBuilder, parameters, "@empMiddleName", txtmname.Text, "empMiddleName");
            AppendField(ref queryBuilder, parameters, "@empCon", txtcontact.Text, "empCon");
            AppendField(ref queryBuilder, parameters, "@empStat", txtstatus.Text, "empStat");
            AppendField(ref queryBuilder, parameters, "@empPlaceb", txtbplace.Text, "empPlaceb");
            AppendField(ref queryBuilder, parameters, "@empGen", rdomale.Checked ? "Male" : "Female", "empGen");
            AppendField(ref queryBuilder, parameters, "@empBirth", dateTimePicker1.Value != DateTime.MinValue ? (object)dateTimePicker1.Value : null, "empBirth");
            AppendField(ref queryBuilder, parameters, "@empAge", txtage.Text, "empAge");
            AppendField(ref queryBuilder, parameters, "@empEmerg", txtemerg.Text, "empEmerg");
            AppendField(ref queryBuilder, parameters, "@empDailyRate", txtdrate.Text, "empDailyRate");
            AppendField(ref queryBuilder, parameters, "@empPos", txtposition.Text, "empPos");
            AppendField(ref queryBuilder, parameters, "@pay", txtpay.Text, "pay");
            AppendField(ref queryBuilder, parameters, "@workstat", employstat.Text, "workstat");


            if (queryBuilder.ToString().EndsWith(", "))
            {
                queryBuilder.Remove(queryBuilder.Length - 2, 2);  
            }
            else
            {
                return string.Empty; 
            }

            return queryBuilder.ToString();
        }

        private void AppendField(ref StringBuilder queryBuilder, List<MySqlParameter> parameters, string paramName, object value, string fieldName)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                queryBuilder.Append($"{fieldName} = {paramName}, ");
                parameters.Add(new MySqlParameter(paramName, value));
            }
        }

        private void ExecuteUpdateQuery(MySqlConnection mySqlConnection, string updateQuery, List<MySqlParameter> parameters)
        {
            try
            {
                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, mySqlConnection))
                {
                    updateCmd.Parameters.AddRange(parameters.ToArray());
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee data updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No changes were made to the data.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






    }
}

