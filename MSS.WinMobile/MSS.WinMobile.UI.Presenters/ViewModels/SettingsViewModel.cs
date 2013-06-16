using System.Linq;

namespace MSS.WinMobile.UI.Presenters.ViewModels
{
    public class SettingsViewModel : ViewModel
    {
        public string ServerAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Localization { get; set; }

        public int SynchronizationBatchSize { get; set; }

        public override bool Validate() {
            base.Validate();
            
            if (string.IsNullOrEmpty(ServerAddress))
                ErrorList.Add("Server address can't be empty!");

            if (string.IsNullOrEmpty(Username))
                ErrorList.Add("Account can't be empty!");

            if (string.IsNullOrEmpty(Password))
                ErrorList.Add("Password can't be empty!");

            if (SynchronizationBatchSize == 0)
                ErrorList.Add("Batch size can't equal 0!");

            if (string.IsNullOrEmpty(Localization))
                ErrorList.Add("Localization must be selected!");

            return !ErrorList.Any();
        }
    }
}
