using System;
using System.Windows.Forms;

namespace HW2
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
            Model model = new Model();
            Form1 form = new Form1(model);
            Application.Run(form);
        }
    }
}