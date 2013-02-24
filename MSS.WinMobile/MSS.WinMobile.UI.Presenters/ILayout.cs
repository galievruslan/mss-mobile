namespace MSS.WinMobile.UI.Presenters
{
    public interface ILayout
    {
        void Navigate<T>();

        void ShowInfoDialog(string message);

        void ShowErrorDialog(string message);

        bool ShowConfirmDialog(string question);

        void Exit();
    }
}
