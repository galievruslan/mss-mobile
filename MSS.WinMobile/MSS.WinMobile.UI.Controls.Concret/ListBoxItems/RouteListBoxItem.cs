using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems
{
    public class RouteListBoxItem : VirtualListBoxItem {
        private System.Windows.Forms.BindingSource _routeViewModelBindingSource;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.LinkLabel _routeDateLabel;
    
        public RouteListBoxItem(){
            InitializeComponent();
        }

        private RouteViewModel _viewModel;
        public RouteViewModel ViewModel {
            get { return _viewModel; }
            set {
                _viewModel = value;
                _routeViewModelBindingSource.DataSource = _viewModel;
            }
        }

        private void RoutePointShippingAddressLabelClick(object sender, System.EventArgs e) {
            RefreshData();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._routeDateLabel = new System.Windows.Forms.LinkLabel();
            this._routeViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._routeViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _routeDateLabel
            // 
            this._routeDateLabel.BackColor = System.Drawing.Color.White;
            this._routeDateLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._routeViewModelBindingSource, "Date", true));
            this._routeDateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._routeDateLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._routeDateLabel.ForeColor = System.Drawing.Color.Black;
            this._routeDateLabel.Location = new System.Drawing.Point(0, 0);
            this._routeDateLabel.Name = "_routeDateLabel";
            this._routeDateLabel.Size = new System.Drawing.Size(200, 30);
            this._routeDateLabel.TabIndex = 0;
            this._routeDateLabel.Text = "01.01.2013";
            this._routeDateLabel.Click += new System.EventHandler(this.RoutePointShippingAddressLabelClick);
            // 
            // routeViewModelBindingSource
            // 
            this._routeViewModelBindingSource.DataSource = typeof(MSS.WinMobile.UI.Presenters.ViewModels.RouteViewModel);
            // 
            // RouteListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this._routeDateLabel);
            this.Name = "RouteListBoxItem";
            this.Size = new System.Drawing.Size(200, 30);
            ((System.ComponentModel.ISupportInitialize)(this._routeViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
