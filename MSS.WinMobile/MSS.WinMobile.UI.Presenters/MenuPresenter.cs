using System;
using System.Collections.Generic;
using System.Text;

namespace MSS.WinMobile.UI.Presenters
{
    public class MenuPresenter : Presenter
    {
        private readonly IMenuView _view;

        public MenuPresenter(IMenuView view)
        {
            _view = view;
        }

        public void Route()
        {
        }

        public void Customers()
        {
        }

        public void Synchronization()
        {
            _view.NavigateTo<ISynchronizationView>();
        }

        public void BaliBali()
        {
        }
    }
}
