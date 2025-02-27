using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Un4seen.Bass;

namespace iRemember_KeyGen
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
            
        }
        
    }
}
