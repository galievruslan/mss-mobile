using MSS.WinMobile.UI.Controls.Concret;

namespace MSS.WinMobile.UI.Views.Views {
    partial class OrderView {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderView));
            this.itemsActionPanel = new System.Windows.Forms.Panel();
            this._deleteButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.vericalLine1 = new MSS.WinMobile.UI.Controls.VericalLine();
            this._amountLabel = new System.Windows.Forms.Label();
            this._amountValueLable = new System.Windows.Forms.Label();
            this.addButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this._generalTab = new System.Windows.Forms.TabPage();
            this._orderDateTextBox = new System.Windows.Forms.TextBox();
            this.warehousePanel = new System.Windows.Forms.Panel();
            this._warehouseTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._warehouseResetButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._warehouseLookUpButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.pricePanel = new System.Windows.Forms.Panel();
            this._priceListTextBox = new System.Windows.Forms.TextBox();
            this._buttonPanel = new System.Windows.Forms.Panel();
            this._priceListResetButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._priceListLookUpButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._shippingDatePicker = new System.Windows.Forms.DateTimePicker();
            this._shippingDateLabel = new System.Windows.Forms.Label();
            this._shippingAddressTextBox = new System.Windows.Forms.TextBox();
            this._customerTextBox = new System.Windows.Forms.TextBox();
            this._warehouseLabel = new System.Windows.Forms.Label();
            this._priceLabel = new System.Windows.Forms.Label();
            this._addressLabel = new System.Windows.Forms.Label();
            this._customerLabel = new System.Windows.Forms.Label();
            this._orderDateLabel = new System.Windows.Forms.Label();
            this._detailsTab = new System.Windows.Forms.TabPage();
            this.orderItemListBox = new MSS.WinMobile.UI.Controls.Concret.OrderItemListBox();
            this._notesTab = new System.Windows.Forms.TabPage();
            this._notesTextBox = new System.Windows.Forms.TextBox();
            this.itemsActionPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this._generalTab.SuspendLayout();
            this.warehousePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pricePanel.SuspendLayout();
            this._buttonPanel.SuspendLayout();
            this._detailsTab.SuspendLayout();
            this._notesTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemsActionPanel
            // 
            this.itemsActionPanel.Controls.Add(this._deleteButton);
            this.itemsActionPanel.Controls.Add(this.vericalLine1);
            this.itemsActionPanel.Controls.Add(this._amountLabel);
            this.itemsActionPanel.Controls.Add(this._amountValueLable);
            this.itemsActionPanel.Controls.Add(this.addButton);
            this.itemsActionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemsActionPanel.Location = new System.Drawing.Point(0, 0);
            this.itemsActionPanel.Name = "itemsActionPanel";
            this.itemsActionPanel.Size = new System.Drawing.Size(232, 24);
            // 
            // _deleteButton
            // 
            this._deleteButton.BackColor = System.Drawing.Color.White;
            this._deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_deleteButton.BackgroundImage")));
            this._deleteButton.Location = new System.Drawing.Point(24, 2);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("_deleteButton.PressedImage")));
            this._deleteButton.Size = new System.Drawing.Size(20, 20);
            this._deleteButton.TabIndex = 6;
            this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
            // 
            // vericalLine1
            // 
            this.vericalLine1.BackColor = System.Drawing.Color.White;
            this.vericalLine1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vericalLine1.LineColor = System.Drawing.Color.DarkGray;
            this.vericalLine1.Location = new System.Drawing.Point(103, 0);
            this.vericalLine1.Name = "vericalLine1";
            this.vericalLine1.Size = new System.Drawing.Size(5, 24);
            this.vericalLine1.TabIndex = 3;
            // 
            // _amountLabel
            // 
            this._amountLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this._amountLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._amountLabel.Location = new System.Drawing.Point(108, 0);
            this._amountLabel.Name = "_amountLabel";
            this._amountLabel.Size = new System.Drawing.Size(52, 24);
            this._amountLabel.Text = "Amount";
            // 
            // _amountValueLable
            // 
            this._amountValueLable.Dock = System.Windows.Forms.DockStyle.Right;
            this._amountValueLable.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._amountValueLable.Location = new System.Drawing.Point(160, 0);
            this._amountValueLable.Name = "_amountValueLable";
            this._amountValueLable.Size = new System.Drawing.Size(72, 24);
            this._amountValueLable.Text = "0";
            this._amountValueLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.White;
            this.addButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addButton.BackgroundImage")));
            this.addButton.Location = new System.Drawing.Point(2, 2);
            this.addButton.Name = "addButton";
            this.addButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("addButton.PressedImage")));
            this.addButton.Size = new System.Drawing.Size(20, 20);
            this.addButton.TabIndex = 0;
            this.addButton.Click += new System.EventHandler(this.AddClick);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this._generalTab);
            this.tabControl.Controls.Add(this._detailsTab);
            this.tabControl.Controls.Add(this._notesTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 268);
            this.tabControl.TabIndex = 2;
            // 
            // _generalTab
            // 
            this._generalTab.Controls.Add(this._orderDateTextBox);
            this._generalTab.Controls.Add(this.warehousePanel);
            this._generalTab.Controls.Add(this.pricePanel);
            this._generalTab.Controls.Add(this._shippingDatePicker);
            this._generalTab.Controls.Add(this._shippingDateLabel);
            this._generalTab.Controls.Add(this._shippingAddressTextBox);
            this._generalTab.Controls.Add(this._customerTextBox);
            this._generalTab.Controls.Add(this._warehouseLabel);
            this._generalTab.Controls.Add(this._priceLabel);
            this._generalTab.Controls.Add(this._addressLabel);
            this._generalTab.Controls.Add(this._customerLabel);
            this._generalTab.Controls.Add(this._orderDateLabel);
            this._generalTab.Location = new System.Drawing.Point(0, 0);
            this._generalTab.Name = "_generalTab";
            this._generalTab.Size = new System.Drawing.Size(240, 244);
            this._generalTab.Text = "General";
            // 
            // _orderDateTextBox
            // 
            this._orderDateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._orderDateTextBox.Location = new System.Drawing.Point(107, 4);
            this._orderDateTextBox.Name = "_orderDateTextBox";
            this._orderDateTextBox.ReadOnly = true;
            this._orderDateTextBox.Size = new System.Drawing.Size(125, 21);
            this._orderDateTextBox.TabIndex = 59;
            // 
            // warehousePanel
            // 
            this.warehousePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.warehousePanel.Controls.Add(this._warehouseTextBox);
            this.warehousePanel.Controls.Add(this.panel1);
            this.warehousePanel.Location = new System.Drawing.Point(77, 160);
            this.warehousePanel.Name = "warehousePanel";
            this.warehousePanel.Size = new System.Drawing.Size(155, 48);
            // 
            // _warehouseTextBox
            // 
            this._warehouseTextBox.BackColor = System.Drawing.Color.White;
            this._warehouseTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._warehouseTextBox.Location = new System.Drawing.Point(0, 0);
            this._warehouseTextBox.Multiline = true;
            this._warehouseTextBox.Name = "_warehouseTextBox";
            this._warehouseTextBox.ReadOnly = true;
            this._warehouseTextBox.Size = new System.Drawing.Size(133, 48);
            this._warehouseTextBox.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this._warehouseResetButton);
            this.panel1.Controls.Add(this._warehouseLookUpButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(133, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(22, 48);
            // 
            // _warehouseResetButton
            // 
            this._warehouseResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._warehouseResetButton.BackColor = System.Drawing.Color.White;
            this._warehouseResetButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_warehouseResetButton.BackgroundImage")));
            this._warehouseResetButton.Location = new System.Drawing.Point(0, 24);
            this._warehouseResetButton.Name = "_warehouseResetButton";
            this._warehouseResetButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("_warehouseResetButton.PressedImage")));
            this._warehouseResetButton.Size = new System.Drawing.Size(22, 24);
            this._warehouseResetButton.TabIndex = 1;
            this._warehouseResetButton.Click += new System.EventHandler(this.WarehouseReset);
            // 
            // _warehouseLookUpButton
            // 
            this._warehouseLookUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._warehouseLookUpButton.BackColor = System.Drawing.Color.White;
            this._warehouseLookUpButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_warehouseLookUpButton.BackgroundImage")));
            this._warehouseLookUpButton.Location = new System.Drawing.Point(0, 0);
            this._warehouseLookUpButton.Name = "_warehouseLookUpButton";
            this._warehouseLookUpButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("_warehouseLookUpButton.PressedImage")));
            this._warehouseLookUpButton.Size = new System.Drawing.Size(22, 24);
            this._warehouseLookUpButton.TabIndex = 0;
            this._warehouseLookUpButton.Click += new System.EventHandler(this.WarehouseLookUp);
            // 
            // pricePanel
            // 
            this.pricePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pricePanel.Controls.Add(this._priceListTextBox);
            this.pricePanel.Controls.Add(this._buttonPanel);
            this.pricePanel.Location = new System.Drawing.Point(77, 106);
            this.pricePanel.Name = "pricePanel";
            this.pricePanel.Size = new System.Drawing.Size(155, 48);
            // 
            // _priceListTextBox
            // 
            this._priceListTextBox.BackColor = System.Drawing.Color.White;
            this._priceListTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._priceListTextBox.Location = new System.Drawing.Point(0, 0);
            this._priceListTextBox.Multiline = true;
            this._priceListTextBox.Name = "_priceListTextBox";
            this._priceListTextBox.ReadOnly = true;
            this._priceListTextBox.Size = new System.Drawing.Size(133, 48);
            this._priceListTextBox.TabIndex = 4;
            // 
            // _buttonPanel
            // 
            this._buttonPanel.BackColor = System.Drawing.Color.White;
            this._buttonPanel.Controls.Add(this._priceListResetButton);
            this._buttonPanel.Controls.Add(this._priceListLookUpButton);
            this._buttonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._buttonPanel.Location = new System.Drawing.Point(133, 0);
            this._buttonPanel.Name = "_buttonPanel";
            this._buttonPanel.Size = new System.Drawing.Size(22, 48);
            // 
            // _priceListResetButton
            // 
            this._priceListResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._priceListResetButton.BackColor = System.Drawing.Color.White;
            this._priceListResetButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_priceListResetButton.BackgroundImage")));
            this._priceListResetButton.Location = new System.Drawing.Point(0, 24);
            this._priceListResetButton.Name = "_priceListResetButton";
            this._priceListResetButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("_priceListResetButton.PressedImage")));
            this._priceListResetButton.Size = new System.Drawing.Size(23, 24);
            this._priceListResetButton.TabIndex = 1;
            this._priceListResetButton.Click += new System.EventHandler(this.PriceListReset);
            // 
            // _priceListLookUpButton
            // 
            this._priceListLookUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._priceListLookUpButton.BackColor = System.Drawing.Color.White;
            this._priceListLookUpButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_priceListLookUpButton.BackgroundImage")));
            this._priceListLookUpButton.Location = new System.Drawing.Point(0, 0);
            this._priceListLookUpButton.Name = "_priceListLookUpButton";
            this._priceListLookUpButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("_priceListLookUpButton.PressedImage")));
            this._priceListLookUpButton.Size = new System.Drawing.Size(22, 24);
            this._priceListLookUpButton.TabIndex = 0;
            this._priceListLookUpButton.Click += new System.EventHandler(this.PriceListlookUp);
            // 
            // _shippingDatePicker
            // 
            this._shippingDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._shippingDatePicker.CustomFormat = "dd.MM.yyyy";
            this._shippingDatePicker.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._shippingDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._shippingDatePicker.Location = new System.Drawing.Point(107, 29);
            this._shippingDatePicker.Name = "_shippingDatePicker";
            this._shippingDatePicker.Size = new System.Drawing.Size(125, 22);
            this._shippingDatePicker.TabIndex = 52;
            this._shippingDatePicker.ValueChanged += new System.EventHandler(this.ShippingDatePickerValueChanged);
            // 
            // _shippingDateLabel
            // 
            this._shippingDateLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._shippingDateLabel.Location = new System.Drawing.Point(7, 31);
            this._shippingDateLabel.Name = "_shippingDateLabel";
            this._shippingDateLabel.Size = new System.Drawing.Size(94, 20);
            this._shippingDateLabel.Text = "Shipping Date";
            // 
            // _shippingAddressTextBox
            // 
            this._shippingAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._shippingAddressTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._shippingAddressTextBox.Location = new System.Drawing.Point(77, 81);
            this._shippingAddressTextBox.Name = "_shippingAddressTextBox";
            this._shippingAddressTextBox.ReadOnly = true;
            this._shippingAddressTextBox.Size = new System.Drawing.Size(155, 21);
            this._shippingAddressTextBox.TabIndex = 41;
            // 
            // _customerTextBox
            // 
            this._customerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._customerTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._customerTextBox.Location = new System.Drawing.Point(77, 55);
            this._customerTextBox.Name = "_customerTextBox";
            this._customerTextBox.ReadOnly = true;
            this._customerTextBox.Size = new System.Drawing.Size(155, 21);
            this._customerTextBox.TabIndex = 40;
            // 
            // _warehouseLabel
            // 
            this._warehouseLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._warehouseLabel.Location = new System.Drawing.Point(7, 164);
            this._warehouseLabel.Name = "_warehouseLabel";
            this._warehouseLabel.Size = new System.Drawing.Size(64, 20);
            this._warehouseLabel.Text = "Warehouse";
            // 
            // _priceLabel
            // 
            this._priceLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._priceLabel.Location = new System.Drawing.Point(7, 110);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(64, 20);
            this._priceLabel.Text = "Price list";
            // 
            // _addressLabel
            // 
            this._addressLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._addressLabel.Location = new System.Drawing.Point(7, 83);
            this._addressLabel.Name = "_addressLabel";
            this._addressLabel.Size = new System.Drawing.Size(64, 20);
            this._addressLabel.Text = "Address";
            // 
            // _customerLabel
            // 
            this._customerLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._customerLabel.Location = new System.Drawing.Point(7, 56);
            this._customerLabel.Name = "_customerLabel";
            this._customerLabel.Size = new System.Drawing.Size(64, 20);
            this._customerLabel.Text = "Customer";
            // 
            // _orderDateLabel
            // 
            this._orderDateLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._orderDateLabel.Location = new System.Drawing.Point(7, 4);
            this._orderDateLabel.Name = "_orderDateLabel";
            this._orderDateLabel.Size = new System.Drawing.Size(94, 20);
            this._orderDateLabel.Text = "Order Date";
            // 
            // _detailsTab
            // 
            this._detailsTab.Controls.Add(this.orderItemListBox);
            this._detailsTab.Controls.Add(this.itemsActionPanel);
            this._detailsTab.Location = new System.Drawing.Point(0, 0);
            this._detailsTab.Name = "_detailsTab";
            this._detailsTab.Size = new System.Drawing.Size(232, 242);
            this._detailsTab.Text = "Details";
            // 
            // orderItemListBox
            // 
            this.orderItemListBox.BackColor = System.Drawing.Color.White;
            this.orderItemListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderItemListBox.Location = new System.Drawing.Point(0, 24);
            this.orderItemListBox.Name = "orderItemListBox";
            this.orderItemListBox.Size = new System.Drawing.Size(232, 218);
            this.orderItemListBox.TabIndex = 1;
            // 
            // _notesTab
            // 
            this._notesTab.Controls.Add(this._notesTextBox);
            this._notesTab.Location = new System.Drawing.Point(0, 0);
            this._notesTab.Name = "_notesTab";
            this._notesTab.Size = new System.Drawing.Size(240, 244);
            this._notesTab.Text = "Notes";
            // 
            // _notesTextBox
            // 
            this._notesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._notesTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._notesTextBox.Location = new System.Drawing.Point(7, 7);
            this._notesTextBox.Multiline = true;
            this._notesTextBox.Name = "_notesTextBox";
            this._notesTextBox.Size = new System.Drawing.Size(226, 234);
            this._notesTextBox.TabIndex = 0;
            this._notesTextBox.TextChanged += new System.EventHandler(this.NotesTextBoxTextChanged);
            // 
            // OrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.tabControl);
            this.Name = "OrderView";
            this.Size = new System.Drawing.Size(240, 268);
            this.Load += new MSS.WinMobile.UI.Views.Views.View.OnLoad(this.OrderViewLoad);
            this.itemsActionPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this._generalTab.ResumeLayout(false);
            this.warehousePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pricePanel.ResumeLayout(false);
            this._buttonPanel.ResumeLayout(false);
            this._detailsTab.ResumeLayout(false);
            this._notesTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel itemsActionPanel;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton addButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage _generalTab;
        private System.Windows.Forms.Panel warehousePanel;
        private System.Windows.Forms.TextBox _warehouseTextBox;
        private System.Windows.Forms.Panel panel1;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _warehouseResetButton;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _warehouseLookUpButton;
        public System.Windows.Forms.Panel pricePanel;
        private System.Windows.Forms.TextBox _priceListTextBox;
        private System.Windows.Forms.Panel _buttonPanel;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _priceListResetButton;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _priceListLookUpButton;
        private System.Windows.Forms.DateTimePicker _shippingDatePicker;
        private System.Windows.Forms.Label _shippingDateLabel;
        private System.Windows.Forms.TextBox _shippingAddressTextBox;
        private System.Windows.Forms.TextBox _customerTextBox;
        private System.Windows.Forms.Label _warehouseLabel;
        private System.Windows.Forms.Label _priceLabel;
        private System.Windows.Forms.Label _addressLabel;
        private System.Windows.Forms.Label _customerLabel;
        private System.Windows.Forms.Label _orderDateLabel;
        private System.Windows.Forms.TabPage _detailsTab;
        private System.Windows.Forms.TabPage _notesTab;
        private System.Windows.Forms.TextBox _notesTextBox;
        private OrderItemListBox orderItemListBox;
        private System.Windows.Forms.Label _amountValueLable;
        private System.Windows.Forms.Label _amountLabel;
        private System.Windows.Forms.TextBox _orderDateTextBox;
        private MSS.WinMobile.UI.Controls.VericalLine vericalLine1;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _deleteButton;
    }
}
