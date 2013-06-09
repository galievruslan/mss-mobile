using System;

using System.Collections.Generic;
using System.Windows.Forms;

namespace Updater {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main(string[] args) {
            Application.Run(new Updater());
        }
    }
}