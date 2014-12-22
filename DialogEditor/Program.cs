using System;
using System.Windows.Forms;

namespace DialogEditor
{
    internal static class Program
    {
        /// <summary>
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dialog());
        }
    }
}