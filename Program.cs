using System;
using System.IO;
using System.Windows.Forms;

namespace MascotPrintingUtility
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DirectoryInfo _dir1 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\" + "Log");
            if (_dir1.Exists == false)
            {
                _dir1.Create();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginScreen());
        }
    }
}
