using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems {
    public class OrderListBoxItem : VirtualListBoxItem {
        private System.Windows.Forms.LinkLabel _descriptionLabel;
        private System.Windows.Forms.LinkLabel _priceLabel;
        private System.Windows.Forms.BindingSource _orderViewModelBindingSource;
        private System.ComponentModel.IContainer components;

        public OrderListBoxItem() {
            InitializeComponent();
        }

        private OrderViewModel _viewModel;

        public OrderViewModel ViewModel {
            get { return _viewModel; }
            set {
                _viewModel = value;
                _orderViewModelBindingSource.DataSource = _viewModel;
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            _descriptionLabel.BackColor = _priceLabel.BackColor = IsSelected ? ColorSelected : ColorUnselected;
            base.OnPaint(e);
            DrawDivisor(e.Graphics);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this._descriptionLabel = new System.Windows.Forms.LinkLabel();
            this._priceLabel = new System.Windows.Forms.LinkLabel();
            this._orderViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize) (this._orderViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                                                                                     this._orderViewModelBindingSource,
                                                                                     "Description", true));
            this._descriptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._descriptionLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._descriptionLabel.ForeColor = System.Drawing.Color.Black;
            this._descriptionLabel.Location = new System.Drawing.Point(0, 0);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(200, 14);
            this._descriptionLabel.TabIndex = 0;
            this._descriptionLabel.Text = "linkLabel1";
            this._descriptionLabel.Click += new System.EventHandler(this.NameLabelClick);
            // 
            // _priceLabel
            // 
            this._priceLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._orderViewModelBindingSource,
                                                                               "PriceListName", true));
            this._priceLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._priceLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._priceLabel.ForeColor = System.Drawing.Color.Black;
            this._priceLabel.Location = new System.Drawing.Point(0, 14);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(200, 14);
            this._priceLabel.TabIndex = 1;
            this._priceLabel.Text = "linkLabel1";
            this._priceLabel.Click += new System.EventHandler(this.NameLabelClick);
            // 
            // _orderViewModelBindingSource
            // 
            this._orderViewModelBindingSource.DataSource =
                typeof (MSS.WinMobile.UI.Presenters.ViewModels.OrderViewModel);
            // 
            // OrderListBoxItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._priceLabel);
            this.Controls.Add(this._descriptionLabel);
            this.Name = "OrderListBoxItem";
            this.Size = new System.Drawing.Size(200, 30);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CustomerListBoxItemPaint);
            ((System.ComponentModel.ISupportInitialize) (this._orderViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        private void NameLabelClick(object sender, System.EventArgs e) {
            VirtualListBoxItemClick(sender, e);
        }

        private void CustomerListBoxItemPaint(object sender, System.Windows.Forms.PaintEventArgs e) {
            DrawDivisor(e.Graphics);
        }
    }
}
