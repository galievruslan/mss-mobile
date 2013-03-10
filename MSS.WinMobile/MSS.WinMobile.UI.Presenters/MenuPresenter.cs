namespace MSS.WinMobile.UI.Presenters
{
    public class MenuPresenter : IPresenter
    {
        private readonly IMenuView _view;

        public MenuPresenter(IMenuView view)
        {
            _view = view;
        }

        public void InitializeView()
        {
            
        }
    }
}
