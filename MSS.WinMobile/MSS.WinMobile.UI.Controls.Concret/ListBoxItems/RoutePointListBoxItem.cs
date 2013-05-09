using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems
{
    public class RoutePointListBoxItem : VirtualListBoxItem {
        private System.Windows.Forms.BindingSource _routePointViewModelBindingSource;
        private TransparentLabel _label;
        private System.ComponentModel.IContainer components;
    
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._routePointViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._label = new MSS.WinMobile.UI.Controls.TransparentLabel();
            ((System.ComponentModel.ISupportInitialize)(this._routePointViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _routePointViewModelBindingSource
            // 
            this._routePointViewModelBindingSource.AllowNew = false;
            this._routePointViewModelBindingSource.DataSource = typeof(MSS.WinMobile.UI.Presenters.ViewModels.RoutePointViewModel);
            // 
            // _label
            // 
            this._label.BackColor = System.Drawing.SystemColors.Control;
            this._label.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._routePointViewModelBindingSource, "ShippinAddressName", true));
            this._label.Dock = System.Windows.Forms.DockStyle.Fill;
            this._label.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._label.Location = new System.Drawing.Point(0, 0);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(200, 30);
            this._label.TabIndex = 0;
            this._label.Text = "Some shipping address ";
            this._label.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this._label.TransparentBackground = true;
            this._label.Click += new System.EventHandler(this.LabelClick);
            // 
            // RoutePointListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._label);
            this.Name = "RoutePointListBoxItem";
            this.Size = new System.Drawing.Size(200, 30);
            ((System.ComponentModel.ISupportInitialize)(this._routePointViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        private void LabelClick(object sender, System.EventArgs e) {
            VirtualListBoxItemClick(sender, e);
        }
    }
}
