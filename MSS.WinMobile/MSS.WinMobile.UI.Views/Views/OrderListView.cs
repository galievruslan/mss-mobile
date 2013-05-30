using System;
using MSS.WinMobile.Resources;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class OrderListView : View, IOrderListView {
        public OrderListView() {
            InitializeComponent();
        }
        
        private readonly IPresentersFactory _presentersFactory;
        private readonly ILocalizator _localizator;

        private OrderListPresenter _presenter;
        private readonly DateTime _date;

        public OrderListView(IPresentersFactory presentersFactory, ILocalizator localizator,
                             DateTime date)
            : this() {
            _presentersFactory = presentersFactory;
            _localizator = localizator;
            _date = date;

            datePicker.CustomFormat = _localizator.Localization.GetLocalizedValue("dateformat");
            _orderListBox.Localizator = _localizator;
        }

        private void OrderListViewLoad(object sender, EventArgs e) {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateOrderListPresenter(this);
                _presenter.GetOrdersOnDate(_date);
                _orderListBox.ItemDataNeeded += ItemDataNeeded;
                _orderListBox.ItemSelected += ItemSelected;
                _orderListBox.SetListSize(_presenter.InitializeListSize());

                ViewContainer.RegisterLeftAction(new StubAction());
                ViewContainer.RegisterRightAction(new Back(_presenter));
            }
        }

        void ItemSelected(object sender, VirtualListBoxItem item) {
            _presenter.Select(item.Index);
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item) {
            var orderListBoxItem = item as OrderListBoxItem;
            if (orderListBoxItem != null) {
                orderListBoxItem.ViewModel = _presenter.GetItem(item.Index);
            }
        }

        private void EditOrderClick(object sender, EventArgs e) {
            _presenter.EditOrder();
        }

        private void DatePickerValueChanged(object sender, EventArgs e) {
            _presenter.GetOrdersOnDate(datePicker.Value);
            _orderListBox.SetListSize(_presenter.InitializeListSize());
        }

        private class Back : IViewAction {
            private readonly OrderListPresenter _presenter;
            public Back(OrderListPresenter presenter) {
                _presenter = presenter;
            }

            public string Caption {
                get { return "Back"; }
            }
            public void Do(object sender, EventArgs e) {
                _presenter.GoToMenuView();
            }
        }
    }
}
