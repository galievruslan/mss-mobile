using System.IO;

namespace MSS.WinMobile.Localization {
    public interface ILocalization {
        FileInfo FileInfo { get; }
        void Load();
        string GetLocalizedValue(string valueToLocalizate);
    }
}