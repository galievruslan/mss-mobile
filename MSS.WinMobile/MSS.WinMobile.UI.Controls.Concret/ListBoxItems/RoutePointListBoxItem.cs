using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems
{
    public class RoutePointListBoxItem : VirtualListBoxItem {
        private System.Windows.Forms.BindingSource _routePointViewModelBindingSource;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.LinkLabel _routePointShippingAddressLabel;
    
        public RoutePointListBoxItem(){
            InitializeComponent();
        }

        private RoutePointViewModel _viewModel;
        public RoutePointViewModel ViewModel {
            get { return _viewModel; }
            set {
                _viewModel = value;
                _routePointViewModelBindingSource.DataSource = _viewModel;
            }
        }

        private void RoutePointShippingAddressLabelClick(object sender, System.EventArgs e) {
            RefreshData();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._routePointShippingAddressLabel = new System.Windows.Forms.LinkLabel();
            this._routePointViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._routePointViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _routePointShippingAddressLabel
            // 
            this._routePointShippingAddressLabel.BackColor = System.Drawing.Color.White;
            this._routePointShippingAddressLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._routePointViewModelBindingSource, "ShippinAddressName", true));
            this._routePointShippingAddressLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._routePointShippingAddressLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._routePointShippingAddressLabel.ForeColor = System.Drawing.Color.Black;
            this._routePointShippingAddressLabel.Location = new System.Drawing.Point(0, 0);
            this._routePointShippingAddressLabel.Name = "_routePointShippingAddressLabel";
            this._routePointShippingAddressLabel.Size = new System.Drawing.Size(200, 30);
            this._routePointShippingAddressLabel.TabIndex = 0;
            this._routePointShippingAddressLabel.Text = "Some route point shipping address";
            this._routePointShippingAddressLabel.Click += new System.EventHandler(this.RoutePointShippingAddressLabelClick);
            // 
            // _routePointViewModelBindingSource
            // 
            this._routePointViewModelBindingSource.AllowNew = false;
            this._routePointViewModelBindingSource.DataSource = typeof(MSS.WinMobile.UI.Presenters.ViewModels.RoutePointViewModel);
            // 
            // RoutePointListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this._routePointShippingAddressLabel);
            this.Name = "RoutePointListBoxItem";
            this.Size = new System.Drawing.Size(200, 30);
            ((System.ComponentModel.ISupportInitialize)(this._routePointViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
