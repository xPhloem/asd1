using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSys
{
    internal class ReportForm : Form
    {
        private string dataToReport;
        private RichTextBox richTextBox;

        // Constructor that accepts the report data
        public ReportForm(string dataToReport)
        {
            this.dataToReport = dataToReport;

            // Initialize the RichTextBox
            richTextBox = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Text = dataToReport // Set the text to the report data
            };

            // Add the RichTextBox to the form
            this.Controls.Add(richTextBox);

            // Set form properties
            this.Text = "Report";
            this.Size = new System.Drawing.Size(400, 300);
        }

        // Override the OnLoad method to customize the form's behavior when it loads
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // You can add additional initialization here if needed
        }

        // You can also override the OnShown method if you want to perform actions when the form is shown
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // Additional actions can be performed here
        }
    }
}

