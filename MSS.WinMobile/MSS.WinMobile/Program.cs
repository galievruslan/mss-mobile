using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Activities;

namespace MSS.WinMobile
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new Layout());
        }
    }
}