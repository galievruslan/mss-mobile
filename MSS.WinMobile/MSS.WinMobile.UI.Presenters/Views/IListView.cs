namespace MSS.WinMobile.UI.Presenters.Views
{
    public interface IListView : IView
    {
        void SetItemCount(int count);
        int GetSelectedId();
    }
}
