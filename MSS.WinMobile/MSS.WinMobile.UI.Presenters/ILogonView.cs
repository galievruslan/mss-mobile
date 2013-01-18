namespace MSS.WinMobile.UI.Presenters
{
    public interface ILogonView : IView
    {
        string Account { get; set; }

        string Password { get; set; }

        void Logon();

        void Cancel();

        void Exit();
    }
}
