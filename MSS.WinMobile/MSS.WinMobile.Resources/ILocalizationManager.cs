using System.Collections.Generic;

namespace MSS.WinMobile.Localization {
    public interface ILocalizationManager {
        void SetupLocalization(ILocalization localization);
        ILocalization Localization { get; }
        List<ILocalization> GetAvailableLocalizations();
    }
}