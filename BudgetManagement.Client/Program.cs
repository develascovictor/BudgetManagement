using System;
using WindowsFormApplication = System.Windows.Forms.Application;

namespace BudgetManagement.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindowsFormApplication.EnableVisualStyles();
            WindowsFormApplication.SetCompatibleTextRenderingDefault(false);
            WindowsFormApplication.Run(new MainForm());
        }
    }
}