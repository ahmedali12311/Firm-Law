using System;
using System.Windows.Forms;
using LegalCaseManagementSystem.Models;

namespace Firm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            SystemUser s = new SystemUser();
            s.FirstName = "sadas";
            s.Username="SADASD";
            Application.Run(new MainForm(s));
        }
    }
}
