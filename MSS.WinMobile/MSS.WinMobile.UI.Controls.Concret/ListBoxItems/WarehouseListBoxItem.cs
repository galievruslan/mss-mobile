using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems {
    public class WarehouseListBoxItem : VirtualListBoxItem {
        private System.Windows.Forms.LinkLabel _addressLabel;

        public WarehouseListBoxItem() {
            InitializeComponent();
        }

        private WarehouseViewModel _viewModel;

        public WarehouseViewModel ViewModel {
            get { return _viewModel; }
            set {
                _viewModel = value;
                _addressLabel.Text = ViewModel.Address;
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            _addressLabel.BackColor = IsSelected ? ColorSelected : ColorUnselected;
            base.OnPaint(e);
            DrawDivisor(e.Graphics);
        }

        private void InitializeComponent() {
            this._addressLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // _addressLabel
            // 
            this._addressLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._addressLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._addressLabel.ForeColor = System.Drawing.Color.Black;
            this._addressLabel.Location = new System.Drawing.Point(0, 0);
            this._addressLabel.Name = "_addressLabel";
            this._addressLabel.Size = new System.Drawing.Size(200, 28);
            this._addressLabel.TabIndex = 0;
            this._addressLabel.TabStop = false;
            this._addressLabel.Text = "linkLabel1";
            this._addressLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // WarehouseListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._addressLabel);
            this.Name = "WarehouseListBoxItem";
            this.Size = new System.Drawing.Size(200, 30);
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
