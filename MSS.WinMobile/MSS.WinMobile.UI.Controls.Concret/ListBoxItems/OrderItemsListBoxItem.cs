using System.Globalization;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems {
    public class OrderItemListBoxItem : VirtualListBoxItem {

        public OrderItemListBoxItem()
        {
            InitializeComponent();
        }

        private System.Windows.Forms.LinkLabel _priceLabel;
        private System.Windows.Forms.LinkLabel _quantityLabel;
        private System.Windows.Forms.LinkLabel _descriptionLabel;

        private OrderItemViewModel _viewModel;

        public OrderItemViewModel ViewModel {
            get { return _viewModel; }
            set {
                _viewModel = value;
                _descriptionLabel.Text = _viewModel.ProductName;
                _priceLabel.Text = _viewModel.Price.ToString("G");
                _quantityLabel.Text = _viewModel.Quantity.ToString(CultureInfo.InvariantCulture);
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            _descriptionLabel.BackColor =
                _priceLabel.BackColor =
                _quantityLabel.BackColor = IsSelected ? ColorSelected : ColorUnselected;
            base.OnPaint(e);
            DrawDivisor(e.Graphics);
        }

        private void InitializeComponent() {
            this._priceLabel = new System.Windows.Forms.LinkLabel();
            this._quantityLabel = new System.Windows.Forms.LinkLabel();
            this._descriptionLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // _priceLabel
            // 
            this._priceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._priceLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._priceLabel.ForeColor = System.Drawing.Color.Black;
            this._priceLabel.Location = new System.Drawing.Point(153, 14);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(44, 14);
            this._priceLabel.TabIndex = 4;
            this._priceLabel.TabStop = false;
            this._priceLabel.Text = "150,15";
            this._priceLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // _quantityLabel
            // 
            this._quantityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._quantityLabel.BackColor = System.Drawing.Color.White;
            this._quantityLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._quantityLabel.ForeColor = System.Drawing.Color.Black;
            this._quantityLabel.Location = new System.Drawing.Point(153, 0);
            this._quantityLabel.Name = "_quantityLabel";
            this._quantityLabel.Size = new System.Drawing.Size(44, 14);
            this._quantityLabel.TabIndex = 5;
            this._quantityLabel.TabStop = false;
            this._quantityLabel.Text = "100000";
            this._quantityLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._descriptionLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._descriptionLabel.ForeColor = System.Drawing.Color.Black;
            this._descriptionLabel.Location = new System.Drawing.Point(0, 0);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(157, 28);
            this._descriptionLabel.TabIndex = 3;
            this._descriptionLabel.TabStop = false;
            this._descriptionLabel.Text = "very long item description with something additional information";
            this._descriptionLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // OrderItemListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._priceLabel);
            this.Controls.Add(this._quantityLabel);
            this.Controls.Add(this._descriptionLabel);
            this.Name = "OrderItemListBoxItem";
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
