using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems {
    public class NewProductPriceListBoxItem : NewVirtualListBoxItem {
        private string _description;
        private string _formatedQuantity;
        private string _formatedPrice;

        readonly StringFormat _qauntityFormat = new StringFormat();
        readonly StringFormat _priceFormat = new StringFormat();

        public NewProductPriceListBoxItem()
        {
            InitializeComponent();
            Resize += NewProductPriceListBoxItem_Resize;

            _qauntityFormat.Alignment = StringAlignment.Far;
            _priceFormat.Alignment = StringAlignment.Far;
        }
        
        RectangleF _descriptionRectangle;
        RectangleF _quantityRectangle;
        RectangleF _priceRectangle;

        const float DescriptionXPos = 0;
        const float DescriptionYPos = 0;
        const float QuantityYPos = 0;

        void NewProductPriceListBoxItem_Resize(object sender, System.EventArgs e) {
            float descriptionWidth = Width * 0.7f;
            float descriptionHeight = Height;
            float quantityWidth = Width * 0.3f;
            float quantityHeight = Height * 0.5f;
            float priceWidth = quantityWidth;
            float priceHeight = quantityHeight;

            float quantityXPos = descriptionWidth;
            float priceXPos = descriptionWidth;
            float priceYPos = quantityHeight;

            _descriptionRectangle = new RectangleF(DescriptionXPos, DescriptionYPos,
                                                   descriptionWidth,
                                                   descriptionHeight);

            _quantityRectangle = new RectangleF(quantityXPos, QuantityYPos, quantityWidth,
                                                quantityHeight);

            _priceRectangle = new RectangleF(priceXPos, priceYPos, priceWidth,
                                             priceHeight);
        }

        private PickUpProductViewModel _viewModel;

        public PickUpProductViewModel ViewModel
        {
            get { return _viewModel; }
            set {
                _viewModel = value;
                _description = _viewModel.ProductName;

                if (LocalizationManager != null) {
                    _formatedQuantity = _viewModel.Quantity.ToString(
                        LocalizationManager.Localization.GetLocalizedValue("intformat"));
                    _formatedPrice = _viewModel.Price.ToString(
                        LocalizationManager.Localization.GetLocalizedValue("decimalformat"));
                }
                else {
                    _formatedQuantity = _viewModel.Quantity.ToString(CultureInfo.InvariantCulture);
                    _formatedPrice = _viewModel.Price.ToString(CultureInfo.InvariantCulture);
                }
            }
        }
        
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (Selected) {
                BackColor = ColorSelected;
            }
            else if (_viewModel != null && _viewModel.Quantity > 0) {
                BackColor = Color.LightGreen;
            }
            else {
                BackColor = ColorUnselected;
            }

            Brush fontBrush = new SolidBrush(ForeColor);
            e.Graphics.DrawString(_description, Font, fontBrush,
                                  _descriptionRectangle);
            e.Graphics.DrawString(_formatedQuantity, Font, fontBrush,
                                  _quantityRectangle, _qauntityFormat);
            e.Graphics.DrawString(_formatedPrice, Font, fontBrush,
                                  _priceRectangle, _priceFormat);
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // NewProductPriceListBoxItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "NewProductPriceListBoxItem";
            this.Size = new System.Drawing.Size(200, 29);
            this.ResumeLayout(false);
        }
    }
}
