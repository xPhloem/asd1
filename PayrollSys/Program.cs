using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PayrollSys
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            string employeeName = "John Doe";
            decimal grossPay = 950.00m;
            decimal totalDeductions = 281.68m;
            decimal netPay = 668.32m;
            decimal ytdGrossIncome = 3800.00m;
            decimal ytdNetIncome = 2673.28m;
        }

    }
}
