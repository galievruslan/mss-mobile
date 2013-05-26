using System.Drawing;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems
{
    public class RoutePointListBoxItem : VirtualListBoxItem {
        private System.Windows.Forms.LinkLabel _nameLabel;
        private System.Windows.Forms.LinkLabel _statusLabel;
        private System.Windows.Forms.LinkLabel _addressLabel;
    
        public RoutePointListBoxItem(){
            InitializeComponent();
        }

        private RoutePointViewModel _viewModel;
        public RoutePointViewModel ViewModel {
            get { return _viewModel; }
            set {
                _viewModel = value;
                _nameLabel.Text = ViewModel.ShippinAddressName;
                _addressLabel.Text = ViewModel.ShippinAddressAddress;
                _statusLabel.Text = ViewModel.StatusName;

                if (_viewModel.Color == Color.Empty)
                    _viewModel.Color = ColorUnselected;
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            _nameLabel.BackColor =
                _addressLabel.BackColor =
                _statusLabel.BackColor = IsSelected ? ColorSelected : _viewModel.Color;

            base.OnPaint(e);
            DrawDivisor(e.Graphics);
        }

        private void InitializeComponent()
        {
            this._nameLabel = new System.Windows.Forms.LinkLabel();
            this._addressLabel = new System.Windows.Forms.LinkLabel();
            this._statusLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // _nameLabel
            // 
            this._nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._nameLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._nameLabel.ForeColor = System.Drawing.Color.Black;
            this._nameLabel.Location = new System.Drawing.Point(0, 0);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(200, 14);
            this._nameLabel.TabIndex = 0;
            this._nameLabel.TabStop = false;
            this._nameLabel.Text = "linkLabel1";
            this._nameLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // _addressLabel
            // 
            this._addressLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._addressLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._addressLabel.ForeColor = System.Drawing.Color.Black;
            this._addressLabel.Location = new System.Drawing.Point(0, 14);
            this._addressLabel.Name = "_addressLabel";
            this._addressLabel.Size = new System.Drawing.Size(200, 14);
            this._addressLabel.TabIndex = 1;
            this._addressLabel.TabStop = false;
            this._addressLabel.Text = "linkLabel1";
            this._addressLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // _statusLabel
            // 
            this._statusLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._statusLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._statusLabel.ForeColor = System.Drawing.Color.Black;
            this._statusLabel.Location = new System.Drawing.Point(0, 28);
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(200, 14);
            this._statusLabel.TabIndex = 2;
            this._statusLabel.TabStop = false;
            this._statusLabel.Text = "linkLabel1";
            this._statusLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // RoutePointListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._statusLabel);
            this.Controls.Add(this._addressLabel);
            this.Controls.Add(this._nameLabel);
            this.Name = "RoutePointListBoxItem";
            this.Size = new System.Drawing.Size(200, 43);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ListBoxItemPaint);
            this.ResumeLayout(false);

        }

        private void LabelClick(object sender, System.EventArgs e) {
            VirtualListBoxItemClick(sender, e);
        }

        private void ListBoxItemPaint(object sender, System.Windows.Forms.PaintEventArgs e) {
            DrawDivisor(e.Graphics);
        }
    }
}
