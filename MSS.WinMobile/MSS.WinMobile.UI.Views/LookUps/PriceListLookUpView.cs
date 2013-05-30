using System;
using MSS.WinMobile.Resources;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Views.LookUps
{
    public partial class PriceListLookUpView : LookUpView, IPriceListLookUpView
    {
        private readonly IPresentersFactory _presentersFactory;
        private PriceListLookUpPresenter _presenter;

        public PriceListLookUpView()
        {
            InitializeComponent();
        }

        public PriceListLookUpView(IPresentersFactory presentersFactory, 
                                   ILocalizator localizator)
            : base(localizator) {
            InitializeComponent();
            _presentersFactory = presentersFactory;

            Text = localizator.Localization.GetLocalizedValue(Text);
            _priceListListBox.Localizator = Localizator;
            searchPanel.Localizator = Localizator;
        }

        private void ViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                _priceListListBox.ItemDataNeeded += ItemDataNeeded;
                _priceListListBox.ItemSelected += ItemSelected;
                _presenter = _presentersFactory.CreatePriceListLookUpPresenter(this);
                _priceListListBox.SetListSize(_presenter.InitializeListSize());
            }
        }

        void ItemSelected(object sender, VirtualListBoxItem item)
        {
            _presenter.Select(item.Index);
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            var priceListListBoxItem = item as PriceListListBoxItem;
            if (priceListListBoxItem != null)
            {
                priceListListBoxItem.ViewModel =_presenter.GetItem(item.Index);
            }
        }

        public PriceListViewModel SelectedPriceList
        {
            get { return _presenter.SelectedModel; }
        }

        private void DoSearchClick(object sender, string criteria) {
            _presenter.Search(criteria);
            _priceListListBox.SetListSize(_presenter.InitializeListSize());
        }

        private void ClearSearchClick(object sender) {
            _presenter.ClearSearch();
            _priceListListBox.SetListSize(_presenter.InitializeListSize());
        }

        private void InformationButtonClick(object sender, EventArgs e) {
            _presenter.ShowDetails();
        }
    }
}