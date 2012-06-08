using System;
using System.Windows.Forms;

namespace SilviaPlayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            var mainForm = new MainForm();//new _OldMainForm();
            Application.Run(mainForm);
        }
    }
}
