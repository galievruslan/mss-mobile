using System.Globalization;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems {
    public class ProductPriceListBoxItem : VirtualListBoxItem {
        private System.Windows.Forms.LinkLabel _descriptionLabel;
        private System.Windows.Forms.LinkLabel _priceLabel;
        private System.Windows.Forms.LinkLabel _quantityLabel;
        private System.Windows.Forms.Panel _leftPanel;

        public ProductPriceListBoxItem()
        {
            InitializeComponent();
        }

        private PickUpProductViewModel _viewModel;

        public PickUpProductViewModel ViewModel
        {
            get { return _viewModel; }
            set {
                _viewModel = value;
                _descriptionLabel.Text = _viewModel.ProductName;
                _priceLabel.Text = _viewModel.Price.ToString("G");
                _quantityLabel.Text = _viewModel.Quantity.ToString(CultureInfo.InvariantCulture);
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            _descriptionLabel.BackColor = _priceLabel.BackColor = IsSelected ? ColorSelected : ColorUnselected;
            base.OnPaint(e);
            DrawDivisor(e.Graphics);
        }

        private void InitializeComponent() {
            this._descriptionLabel = new System.Windows.Forms.LinkLabel();
            this._priceLabel = new System.Windows.Forms.LinkLabel();
            this._quantityLabel = new System.Windows.Forms.LinkLabel();
            this._leftPanel = new System.Windows.Forms.Panel();
            this._leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._descriptionLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._descriptionLabel.ForeColor = System.Drawing.Color.Black;
            this._descriptionLabel.Location = new System.Drawing.Point(0, 0);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(200, 14);
            this._descriptionLabel.TabIndex = 0;
            this._descriptionLabel.Text = "linkLabel1";
            this._descriptionLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // _priceLabel
            // 
            this._priceLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._priceLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._priceLabel.ForeColor = System.Drawing.Color.Black;
            this._priceLabel.Location = new System.Drawing.Point(0, 14);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(200, 14);
            this._priceLabel.TabIndex = 1;
            this._priceLabel.Text = "linkLabel1";
            this._priceLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // _quantityLabel
            // 
            this._quantityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._quantityLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this._quantityLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._quantityLabel.ForeColor = System.Drawing.Color.Black;
            this._quantityLabel.Location = new System.Drawing.Point(156, 7);
            this._quantityLabel.Name = "_quantityLabel";
            this._quantityLabel.Size = new System.Drawing.Size(44, 14);
            this._quantityLabel.TabIndex = 2;
            this._quantityLabel.Text = "100000";
            this._quantityLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this._quantityLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // _leftPanel
            // 
            this._leftPanel.Controls.Add(this._priceLabel);
            this._leftPanel.Controls.Add(this._descriptionLabel);
            this._leftPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._leftPanel.Location = new System.Drawing.Point(0, 0);
            this._leftPanel.Name = "_leftPanel";
            this._leftPanel.Size = new System.Drawing.Size(200, 28);
            // 
            // ProductPriceListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._quantityLabel);
            this.Controls.Add(this._leftPanel);
            this.Name = "ProductPriceListBoxItem";
            this.Size = new System.Drawing.Size(200, 30);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ListBoxItemPaint);
            this._leftPanel.ResumeLayout(false);
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
