namespace MSS.WinMobile.UI.Presenters.Views
{
    public interface ILogonView : IView
    {
        string Account { get; set; }

        string Password { get; set; }

        void Logon();

        void Cancel();
    }
}
