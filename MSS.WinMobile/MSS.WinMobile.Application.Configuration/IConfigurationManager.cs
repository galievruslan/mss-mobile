namespace MSS.WinMobile.Application.Configuration {
    public interface IConfigurationManager {
        IConfig GetConfig(string name);
    }
}