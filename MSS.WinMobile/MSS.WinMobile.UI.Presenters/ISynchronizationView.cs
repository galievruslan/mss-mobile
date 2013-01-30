namespace MSS.WinMobile.UI.Presenters
{
    public interface ISynchronizationView : IView
    {
        void Start();

        void Cancel();

        void Exit();
    }
}
