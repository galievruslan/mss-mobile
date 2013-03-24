using System;

using System.Collections.Generic;
using System.Text;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Presenters.DataRetrievers;
using log4net;

namespace MSS.WinMobile.UI.Presenters
{
    public class OrderPresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OrderPresenter));

        private readonly IOrderView _view;
        private readonly Order _order;

        public OrderPresenter(IOrderView view, RoutePoint routePoint)
        {
            _view = view;
            _order = new Order(routePoint);
        }

        public void InitializeView()
        {
            _view.SetOrder(_order);
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Cancel()
        {
            throw new NotImplementedException();
        }
    }
}
