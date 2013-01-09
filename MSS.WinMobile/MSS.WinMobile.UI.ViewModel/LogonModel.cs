namespace MSS.WinMobile.UI.ViewModel
{
    public class LogonModel : ViewModel
    {
        private string _account;

        public string Account
        {
            get { return _account; }
            set { _account = value;
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
            if (string.IsNullOrEmpty(Account))
                Errors.AddError("Account is mandatory");
            if (string.IsNullOrEmpty(Password))
                Errors.AddError("Password is mandatory");

            return base.Validate();
        }
    }
}
