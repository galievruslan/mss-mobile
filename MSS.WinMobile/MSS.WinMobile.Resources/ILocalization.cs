namespace MSS.WinMobile.Resources {
    public interface ILocalization {
        string Name { get; }
        string Path { get; }
        void Load();
        string GetLocalizedValue(string valueToLocalizate);
    }
}