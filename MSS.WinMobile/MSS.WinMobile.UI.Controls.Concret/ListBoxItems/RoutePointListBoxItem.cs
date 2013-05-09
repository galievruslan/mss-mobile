using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems
{
    public class RoutePointListBoxItem : VirtualListBoxItem {
        private System.Windows.Forms.BindingSource _routePointViewModelBindingSource;
        private System.Windows.Forms.LinkLabel _nameLabel;
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

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            _nameLabel.BackColor = IsSelected ? ColorSelected : ColorUnselected;
            base.OnPaint(e);
            DrawDivisor(e.Graphics);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._routePointViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._nameLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this._routePointViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _routePointViewModelBindingSource
            // 
            this._routePointViewModelBindingSource.AllowNew = false;
            this._routePointViewModelBindingSource.DataSource = typeof(MSS.WinMobile.UI.Presenters.ViewModels.RoutePointViewModel);
            // 
            // _nameLabel
            // 
            this._nameLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._routePointViewModelBindingSource, "ShippinAddressName", true));
            this._nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._nameLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._nameLabel.ForeColor = System.Drawing.Color.Black;
            this._nameLabel.Location = new System.Drawing.Point(0, 0);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(200, 28);
            this._nameLabel.TabIndex = 0;
            this._nameLabel.Text = "linkLabel1";
            this._nameLabel.Click += new System.EventHandler(this.NameLabelClick);
            // 
            // RoutePointListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._nameLabel);
            this.Name = "RoutePointListBoxItem";
            this.Size = new System.Drawing.Size(200, 30);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RoutePointListBoxItemPaint);
            ((System.ComponentModel.ISupportInitialize)(this._routePointViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        private void NameLabelClick(object sender, System.EventArgs e) {
            VirtualListBoxItemClick(sender, e);
        }

        private void RoutePointListBoxItemPaint(object sender, System.Windows.Forms.PaintEventArgs e) {
            DrawDivisor(e.Graphics);
        }
    }
}
