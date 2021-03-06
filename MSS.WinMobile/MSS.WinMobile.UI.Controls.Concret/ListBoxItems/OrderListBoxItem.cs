﻿using System.Drawing;
using System.Globalization;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret.ListBoxItems {
    public class OrderListBoxItem : VirtualListBoxItem {
        private System.Windows.Forms.LinkLabel _descriptionLabel;
        private System.Windows.Forms.LinkLabel _ammountLabel;
        private System.Windows.Forms.LinkLabel _shippingLabel;

        public OrderListBoxItem() {
            InitializeComponent();
        }

        private OrderViewModel _viewModel;

        public OrderViewModel ViewModel {
            get { return _viewModel; }
            set {
                _viewModel = value;
                _descriptionLabel.Text = _viewModel.CustomerName;
                if (LocalizationManager != null) {
                    _shippingLabel.Text = string.Format("{0} {1}",
                                                           LocalizationManager.Localization
                                                                          .GetLocalizedValue(
                                                                              "shipping at"),
                                                        ViewModel.ShippingDate.ToString(
                                                            LocalizationManager.Localization
                                                                       .GetLocalizedValue(
                                                                           "dateformat")));
                    _ammountLabel.Text = string.Format("{0} {1}",
                                                           LocalizationManager.Localization
                                                                          .GetLocalizedValue(
                                                                              "amount"),
                                                       ViewModel.Amount.ToString(
                                                           LocalizationManager.Localization
                                                                      .GetLocalizedValue(
                                                                          "decimalformat")));
                }
                else {
                    _shippingLabel.Text = string.Format("shipping at {0}",
                                                        ViewModel.ShippingDate.ToString(CultureInfo.InvariantCulture));
                    _ammountLabel.Text = string.Format("amount: {0}",
                                                       ViewModel.Amount.ToString(CultureInfo.InvariantCulture));
                }
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            _descriptionLabel.BackColor =
                _shippingLabel.BackColor = _ammountLabel.BackColor = IsSelected ? ColorSelected : ColorUnselected;

            if (!IsSelected && _viewModel.Synchronized) {
                _descriptionLabel.BackColor = _shippingLabel.BackColor = _ammountLabel.BackColor = Color.LightGreen;
            }

            base.OnPaint(e);
            DrawDivisor(e.Graphics);
        }

        private void InitializeComponent() {
            this._descriptionLabel = new System.Windows.Forms.LinkLabel();
            this._shippingLabel = new System.Windows.Forms.LinkLabel();
            this._ammountLabel = new System.Windows.Forms.LinkLabel();
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
            this._descriptionLabel.TabStop = false;
            this._descriptionLabel.Text = "linkLabel1";
            this._descriptionLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // _shippingLabel
            // 
            this._shippingLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._shippingLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._shippingLabel.ForeColor = System.Drawing.Color.Black;
            this._shippingLabel.Location = new System.Drawing.Point(0, 14);
            this._shippingLabel.Name = "_shippingLabel";
            this._shippingLabel.Size = new System.Drawing.Size(200, 14);
            this._shippingLabel.TabIndex = 1;
            this._shippingLabel.TabStop = false;
            this._shippingLabel.Text = "linkLabel1";
            this._shippingLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // _ammountLabel
            // 
            this._ammountLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._ammountLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._ammountLabel.ForeColor = System.Drawing.Color.Black;
            this._ammountLabel.Location = new System.Drawing.Point(0, 28);
            this._ammountLabel.Name = "_ammountLabel";
            this._ammountLabel.Size = new System.Drawing.Size(200, 14);
            this._ammountLabel.TabIndex = 2;
            this._ammountLabel.TabStop = false;
            this._ammountLabel.Text = "linkLabel1";
            this._ammountLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // OrderListBoxItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._ammountLabel);
            this.Controls.Add(this._shippingLabel);
            this.Controls.Add(this._descriptionLabel);
            this.Name = "OrderListBoxItem";
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
