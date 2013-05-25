using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems {
    public class CustomerListBoxItem : VirtualListBoxItem {
        private System.Windows.Forms.LinkLabel _nameLabel;

        public CustomerListBoxItem() {
            InitializeComponent();
        }

        public delegate void OnInformationNeeded(VirtualListBoxItem item);

        public event OnInformationNeeded InformationNeeded;

        private CustomerViewModel _viewModel;

        public CustomerViewModel ViewModel {
            get { return _viewModel; }
            set {
                _viewModel = value;
                _nameLabel.Text = ViewModel.Name;
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            _nameLabel.BackColor = IsSelected ? ColorSelected : ColorUnselected;
            base.OnPaint(e);
            DrawDivisor(e.Graphics);
        }

        private void InitializeComponent() {
            this._nameLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // _nameLabel
            // 
            this._nameLabel.BackColor = System.Drawing.Color.Transparent;
            this._nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._nameLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._nameLabel.ForeColor = System.Drawing.Color.Black;
            this._nameLabel.Location = new System.Drawing.Point(0, 0);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(200, 28);
            this._nameLabel.TabIndex = 0;
            this._nameLabel.Text = "Customer name";
            this._nameLabel.Click += new System.EventHandler(this.NameLabelClick);
            // 
            // CustomerListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._nameLabel);
            this.Name = "CustomerListBoxItem";
            this.Size = new System.Drawing.Size(200, 29);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CustomerListBoxItemPaint);
            this.ResumeLayout(false);

        }

        private void NameLabelClick(object sender, System.EventArgs e) {
            VirtualListBoxItemClick(sender, e);
        }

        private void CustomerListBoxItemPaint(object sender, System.Windows.Forms.PaintEventArgs e) {
            DrawDivisor(e.Graphics);
        }

        private void InformationButtonClick(object sender, System.EventArgs e) {
            VirtualListBoxItemClick(sender, e);
            if (InformationNeeded != null)
                InformationNeeded.Invoke(this);
        }
    }
}
