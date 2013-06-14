namespace MSS.WinMobile.Application.Configuration {
    public interface IConfig {
        ISection GetSection(string name);
        void AddSection(string name);
        void Save();
    }
}