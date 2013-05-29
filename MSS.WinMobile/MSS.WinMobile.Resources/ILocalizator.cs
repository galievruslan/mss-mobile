using System.Collections.Generic;

namespace MSS.WinMobile.Resources {
    public interface ILocalizator {
        void SetupLocalization(ILocalization localization);
        ILocalization Localization { get; }
        List<ILocalization> GetAvailableLocalizations(string applicationPath);
    }
}