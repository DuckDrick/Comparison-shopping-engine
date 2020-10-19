using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comparison_shopping_engine.Forms;

namespace Comparison_shopping_engine
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
            var initializer = Initializer.Instance;
            initializer.Init();
            Form formMain = new MainForm();
            Application.Run(formMain);
        }
    }
}
