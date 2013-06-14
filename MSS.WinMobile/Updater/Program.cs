using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MSS.WinMobile.Localization;
using MSS.WinMobile.Resources;
using MSS.WinMobile.Application.Configuration;
using log4net.Config;

namespace Updater {
    static class Program {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main(string[] args) {
            try {
                if (args.Length < 2)
                    throw new ArgumentException("Two arguments are expected");

                var updaterConfig = new TargetConfig {
                    Target = args[0],
                    TargetVersion = args[1]
                };

                // Load Config.xml to setup log4net
                string path = Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly()
                          .GetModules()[0].FullyQualifiedName)
                              + "\\log4net.xml";
                if (File.Exists(path)) {
                    XmlConfigurator.Configure(new FileInfo(path));
                }

                // Setup storage manager
                string configsPath = Path.Combine(MSS.WinMobile.Application.Environment.Environment.AppPath, @"..\Config");
                var configurationManager = new ConfigurationManager(configsPath);

                // Setup localization
                string localizationsPath =
                    Path.Combine(MSS.WinMobile.Application.Environment.Environment.AppPath,
                                 @"..\Resources\Localizations");
                ILocalizationManager localizationManager = new LocalizationManager(localizationsPath);
                try {
                    var localization = configurationManager.GetConfig("Common")
                                                           .GetSection("Localization")
                                                           .GetSetting("Current")
                                                           .Value;

                    List<ILocalization> localizations =
                        localizationManager.GetAvailableLocalizations(
                            MSS.WinMobile.Application.Environment.Environment.AppPath);
                    ILocalization current = null;
                    if (!string.IsNullOrEmpty(localization)) {
                        current =
                            localizations.FirstOrDefault(
                                l => l.Path.ToUpper() == localization.ToUpper());
                    }

                    if (current == null) {
                        current =
                            localizations.LastOrDefault();
                    }
                    localizationManager.SetupLocalization(current);
                }
                catch (Exception exception) {
                    Log.Error(exception);
                }

                Application.Run(new Updater(updaterConfig, configurationManager, localizationManager));
            }
            catch (Exception exception) {
                Log.Error(exception);
            }
        }
    }
}