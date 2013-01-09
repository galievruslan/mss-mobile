namespace MSS.WinMobile.UI.Presenters
{
    public interface IView
    {
        void NavigateTo<T>() where T : IView;

        void ShowInformationDialog(string message);

        bool ShowConfirmationDialog(string question);
    }
}
