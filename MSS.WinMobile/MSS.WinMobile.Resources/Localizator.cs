using System;
using System.Collections.Generic;
using System.IO;
using log4net;

namespace MSS.WinMobile.Resources {
    public class Localizator : ILocalizator {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Localizator));

        public void SetupLocalization(ILocalization localization) {
            Localization = localization;
            Localization.Load();
        }

        public ILocalization Localization { get; private set; }

        private const string LocalizationFolder = @"Resources\Localizations";

        public List<ILocalization> GetAvailableLocalizations(string applicationPath) {
            var localizations = new List<ILocalization>();

            string fullPath = Path.Combine(applicationPath, LocalizationFolder);
            string[] localizationFiles = Directory.GetFiles(fullPath, "*.xml");
            foreach (var localizationFile in localizationFiles) {
                try {
                    localizations.Add(new Localization(localizationFile));
                }
                catch (Exception exception) {
                    Log.Error(exception);
                }
            }

            return localizations;
        }
    }
}
