namespace MSS.WinMobile.Application.Configuration {
    public interface IConfigurationManager {
        string Path { get;}
        IConfig GetConfig(string name);
    }
}