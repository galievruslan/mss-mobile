namespace MSS.WinMobile.UI.Presenters.Views
{
    public interface IInitializationView : IView
    {
        void UpdateStatus(string status);

        void UpdateProgress(int percents);
    }
}
