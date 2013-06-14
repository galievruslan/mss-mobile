namespace MSS.WinMobile.Application.Configuration {
    public interface ISection {
        ISetting GetSetting(string name);
        void AddSetting(string name);
    }
}