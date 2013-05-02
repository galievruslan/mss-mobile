using System.Linq;

namespace MSS.WinMobile.UI.Presenters.ViewModels
{
    public class LogonViewModel : ViewModel
    {
        public string ServerAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override bool Validate() {
            base.Validate();
            if (string.IsNullOrEmpty(ServerAddress)) 
                ErrorList.Add("Server address can't be empty!");

            if (string.IsNullOrEmpty(Username)) 
                ErrorList.Add("Account can't be empty!");

            if (string.IsNullOrEmpty(Password)) 
                ErrorList.Add("Password can't be empty!");

            return !ErrorList.Any();
        }
    }
}
