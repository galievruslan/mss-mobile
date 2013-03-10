using System;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.UI.Views;
using log4net.Config;

namespace MSS.WinMobile.Application
{
    static class Program
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            //Load Config.xml to setup log4net
            string path = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly()
               .GetModules()[0].FullyQualifiedName)
               + "\\log4net.xml";
            if (System.IO.File.Exists(path))
            {
                XmlConfigurator.Configure(new System.IO.FileInfo(path));
            }

            Log.Info("Application start");
            ActiveRecordBase.Initialize(false);
            System.Windows.Forms.Application.Run(new MenuView());
            Log.Info("Application finish");
        }
    }
}