namespace MSS.WinMobile.UI.ViewModel
{
    public class LogonModel : ViewModel
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value;
                IsDirty = true;
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value;
                IsDirty = true;
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrEmpty(Username))
                Errors.AddError("Username is mandatory");
            if (string.IsNullOrEmpty(Password))
                Errors.AddError("Password is mandatory");

            return base.Validate();
        }
    }
}
