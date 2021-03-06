﻿using System.Drawing;
using System.Globalization;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems {
    public class ProductPriceListBoxItem : VirtualListBoxItem {
        private System.Windows.Forms.LinkLabel _priceLabel;
        private System.Windows.Forms.LinkLabel _descriptionLabel;
        private System.Windows.Forms.LinkLabel _quantityLabel;

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
                if (LocalizationManager != null) {
                    _priceLabel.Text =
                        _viewModel.Price.ToString(
                            LocalizationManager.Localization.GetLocalizedValue("decimalformat"));
                    _quantityLabel.Text =
                        _viewModel.Quantity.ToString(
                            LocalizationManager.Localization.GetLocalizedValue("intformat"));
                }
                else {
                    _priceLabel.Text =
                        _viewModel.Price.ToString(CultureInfo.InvariantCulture);
                    _quantityLabel.Text =
                        _viewModel.Quantity.ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            _descriptionLabel.BackColor =
                _priceLabel.BackColor =
                _quantityLabel.BackColor = IsSelected ? ColorSelected : ColorUnselected;

            if (!IsSelected && _viewModel.Quantity > 0) {
                _descriptionLabel.BackColor =
                _priceLabel.BackColor =
                _quantityLabel.BackColor = Color.LightGreen;
            }

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
            this._priceLabel.Location = new System.Drawing.Point(145, 14);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(52, 14);
            this._priceLabel.TabIndex = 1;
            this._priceLabel.TabStop = false;
            this._priceLabel.Text = "150,15";
            this._priceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this._priceLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // _quantityLabel
            // 
            this._quantityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._quantityLabel.BackColor = System.Drawing.Color.White;
            this._quantityLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._quantityLabel.ForeColor = System.Drawing.Color.Black;
            this._quantityLabel.Location = new System.Drawing.Point(145, 0);
            this._quantityLabel.Name = "_quantityLabel";
            this._quantityLabel.Size = new System.Drawing.Size(52, 14);
            this._quantityLabel.TabIndex = 2;
            this._quantityLabel.TabStop = false;
            this._quantityLabel.Text = "100000";
            this._quantityLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this._descriptionLabel.Size = new System.Drawing.Size(147, 28);
            this._descriptionLabel.TabIndex = 0;
            this._descriptionLabel.TabStop = false;
            this._descriptionLabel.Text = "very long item description with something additional information";
            this._descriptionLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // ProductPriceListBoxItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._priceLabel);
            this.Controls.Add(this._quantityLabel);
            this.Controls.Add(this._descriptionLabel);
            this.Name = "ProductPriceListBoxItem";
            this.Size = new System.Drawing.Size(200, 29);
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
