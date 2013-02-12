namespace MSS.WinMobile.UI.Presenters
{
    public class MenuPresenter : Presenter
    {
        private readonly IMenuView _view;

        public MenuPresenter(ILayout layout, IMenuView view)
            :base(layout)
        {
            _view = view;
        }

        public void Route()
        {
        }

        public void Customers()
        {
            Layout.Navigate<ICustomersView>();
        }

        public void Synchronization()
        {
            Layout.Navigate<ISynchronizationView>();
        }

        public void BaliBali()
        {
        }
    }
}
