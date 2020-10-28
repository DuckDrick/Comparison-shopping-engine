using System;
using System.Windows.Forms;
using Comparison_shopping_engine.Forms;

namespace Comparison_shopping_engine
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Initializer.GetProductListFromDatabase();
            Form formMain = new MainForm();
            Application.Run(formMain);
        }
    }
}