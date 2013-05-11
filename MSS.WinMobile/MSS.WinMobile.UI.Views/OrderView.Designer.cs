using MSS.WinMobile.UI.Controls.Buttons;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    partial class OrderView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderView));
            this.tabControl = new System.Windows.Forms.TabControl();
            this._generalTab = new System.Windows.Forms.TabPage();
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
            this._orderDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this._shippingAddressTextBox = new System.Windows.Forms.TextBox();
            this._customerTextBox = new System.Windows.Forms.TextBox();
            this._warehouseLabel = new System.Windows.Forms.Label();
            this._priceLabel = new System.Windows.Forms.Label();
            this._addressLabel = new System.Windows.Forms.Label();
            this._customerLabel = new System.Windows.Forms.Label();
            this._orderDateLabel = new System.Windows.Forms.Label();
            this._detailsTab = new System.Windows.Forms.TabPage();
            this._orderItemListBox = new MSS.WinMobile.UI.Controls.Concret.OrderItemListBox();
            this.itemsActionPanel = new System.Windows.Forms.Panel();
            this.addButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._notesTab = new System.Windows.Forms.TabPage();
            this._notesTextBox = new System.Windows.Forms.TextBox();
            this._actionPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.okButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.notification = new Microsoft.WindowsCE.Forms.Notification();
            this.tabControl.SuspendLayout();
            this._generalTab.SuspendLayout();
            this.warehousePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pricePanel.SuspendLayout();
            this._buttonPanel.SuspendLayout();
            this._detailsTab.SuspendLayout();
            this.itemsActionPanel.SuspendLayout();
            this._notesTab.SuspendLayout();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this._generalTab);
            this.tabControl.Controls.Add(this._detailsTab);
            this.tabControl.Controls.Add(this._notesTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 264);
            this.tabControl.TabIndex = 0;
            // 
            // _generalTab
            // 
            this._generalTab.Controls.Add(this.warehousePanel);
            this._generalTab.Controls.Add(this.pricePanel);
            this._generalTab.Controls.Add(this._shippingDatePicker);
            this._generalTab.Controls.Add(this._orderDatePicker);
            this._generalTab.Controls.Add(this.label1);
            this._generalTab.Controls.Add(this._shippingAddressTextBox);
            this._generalTab.Controls.Add(this._customerTextBox);
            this._generalTab.Controls.Add(this._warehouseLabel);
            this._generalTab.Controls.Add(this._priceLabel);
            this._generalTab.Controls.Add(this._addressLabel);
            this._generalTab.Controls.Add(this._customerLabel);
            this._generalTab.Controls.Add(this._orderDateLabel);
            this._generalTab.Location = new System.Drawing.Point(0, 0);
            this._generalTab.Name = "_generalTab";
            this._generalTab.Size = new System.Drawing.Size(240, 240);
            this._generalTab.Text = "General";
            // 
            // warehousePanel
            // 
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
            this._warehouseResetButton.PressedImage = null;
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
            this._warehouseLookUpButton.PressedImage = null;
            this._warehouseLookUpButton.Size = new System.Drawing.Size(22, 24);
            this._warehouseLookUpButton.TabIndex = 0;
            this._warehouseLookUpButton.Click += new System.EventHandler(this.WarehouseLookUp);
            // 
            // pricePanel
            // 
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
            this._priceListResetButton.Location = new System.Drawing.Point(1, 24);
            this._priceListResetButton.Name = "_priceListResetButton";
            this._priceListResetButton.PressedImage = null;
            this._priceListResetButton.Size = new System.Drawing.Size(22, 24);
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
            this._priceListLookUpButton.PressedImage = null;
            this._priceListLookUpButton.Size = new System.Drawing.Size(22, 24);
            this._priceListLookUpButton.TabIndex = 0;
            this._priceListLookUpButton.Click += new System.EventHandler(this.PriceListlookUp);
            // 
            // _shippingDatePicker
            // 
            this._shippingDatePicker.CustomFormat = "dd.MM.yyyy";
            this._shippingDatePicker.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._shippingDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._shippingDatePicker.Location = new System.Drawing.Point(107, 29);
            this._shippingDatePicker.Name = "_shippingDatePicker";
            this._shippingDatePicker.Size = new System.Drawing.Size(125, 22);
            this._shippingDatePicker.TabIndex = 52;
            this._shippingDatePicker.ValueChanged += new System.EventHandler(this.ShippingDatePickerValueChanged);
            // 
            // _orderDatePicker
            // 
            this._orderDatePicker.CustomFormat = "dd.MM.yyyy";
            this._orderDatePicker.Enabled = false;
            this._orderDatePicker.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._orderDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._orderDatePicker.Location = new System.Drawing.Point(107, 2);
            this._orderDatePicker.Name = "_orderDatePicker";
            this._orderDatePicker.Size = new System.Drawing.Size(125, 22);
            this._orderDatePicker.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.Text = "Shipping Date";
            // 
            // _shippingAddressTextBox
            // 
            this._shippingAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._shippingAddressTextBox.Enabled = false;
            this._shippingAddressTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._shippingAddressTextBox.Location = new System.Drawing.Point(77, 81);
            this._shippingAddressTextBox.Name = "_shippingAddressTextBox";
            this._shippingAddressTextBox.Size = new System.Drawing.Size(155, 21);
            this._shippingAddressTextBox.TabIndex = 41;
            // 
            // _customerTextBox
            // 
            this._customerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._customerTextBox.Enabled = false;
            this._customerTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._customerTextBox.Location = new System.Drawing.Point(77, 55);
            this._customerTextBox.Name = "_customerTextBox";
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
            this._priceLabel.Text = "Price";
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
            this._detailsTab.Controls.Add(this._orderItemListBox);
            this._detailsTab.Controls.Add(this.itemsActionPanel);
            this._detailsTab.Location = new System.Drawing.Point(0, 0);
            this._detailsTab.Name = "_detailsTab";
            this._detailsTab.Size = new System.Drawing.Size(240, 240);
            this._detailsTab.Text = "Details";
            // 
            // _orderItemListBox
            // 
            this._orderItemListBox.BackColor = System.Drawing.Color.White;
            this._orderItemListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._orderItemListBox.Location = new System.Drawing.Point(0, 24);
            this._orderItemListBox.Name = "_orderItemListBox";
            this._orderItemListBox.Size = new System.Drawing.Size(240, 216);
            this._orderItemListBox.TabIndex = 1;
            // 
            // itemsActionPanel
            // 
            this.itemsActionPanel.Controls.Add(this.addButton);
            this.itemsActionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemsActionPanel.Location = new System.Drawing.Point(0, 0);
            this.itemsActionPanel.Name = "itemsActionPanel";
            this.itemsActionPanel.Size = new System.Drawing.Size(240, 24);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.White;
            this.addButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addButton.BackgroundImage")));
            this.addButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addButton.Location = new System.Drawing.Point(2, 2);
            this.addButton.Name = "addButton";
            this.addButton.PressedImage = null;
            this.addButton.Size = new System.Drawing.Size(20, 20);
            this.addButton.TabIndex = 0;
            this.addButton.Click += new System.EventHandler(this.AddClick);
            // 
            // _notesTab
            // 
            this._notesTab.Controls.Add(this._notesTextBox);
            this._notesTab.Location = new System.Drawing.Point(0, 0);
            this._notesTab.Name = "_notesTab";
            this._notesTab.Size = new System.Drawing.Size(232, 238);
            this._notesTab.Text = "Notes";
            // 
            // _notesTextBox
            // 
            this._notesTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._notesTextBox.Location = new System.Drawing.Point(7, 7);
            this._notesTextBox.Multiline = true;
            this._notesTextBox.Name = "_notesTextBox";
            this._notesTextBox.Size = new System.Drawing.Size(226, 231);
            this._notesTextBox.TabIndex = 0;
            this._notesTextBox.TextChanged += new System.EventHandler(this.NotesTextBoxTextChanged);
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this.cancelButton);
            this._actionPanel.Controls.Add(this.okButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._actionPanel.Location = new System.Drawing.Point(0, 264);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 30);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.White;
            this.cancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelButton.BackgroundImage")));
            this.cancelButton.Location = new System.Drawing.Point(123, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.PressedImage = null;
            this.cancelButton.Size = new System.Drawing.Size(24, 24);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.BackColor = System.Drawing.Color.White;
            this.okButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okButton.BackgroundImage")));
            this.okButton.Location = new System.Drawing.Point(93, 3);
            this.okButton.Name = "okButton";
            this.okButton.PressedImage = null;
            this.okButton.Size = new System.Drawing.Size(24, 24);
            this.okButton.TabIndex = 4;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // notification
            // 
            this.notification.Text = "notification1";
            // 
            // OrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this._actionPanel);
            this.Name = "OrderView";
            this.Text = "OrderView";
            this.Load += new System.EventHandler(this.ViewLoad);
            this.tabControl.ResumeLayout(false);
            this._generalTab.ResumeLayout(false);
            this.warehousePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pricePanel.ResumeLayout(false);
            this._buttonPanel.ResumeLayout(false);
            this._detailsTab.ResumeLayout(false);
            this.itemsActionPanel.ResumeLayout(false);
            this._notesTab.ResumeLayout(false);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage _generalTab;
        private System.Windows.Forms.TabPage _detailsTab;
        private System.Windows.Forms.TabPage _notesTab;
        private System.Windows.Forms.Panel _actionPanel;
        private System.Windows.Forms.Label _orderDateLabel;
        private System.Windows.Forms.Label _warehouseLabel;
        private System.Windows.Forms.Label _priceLabel;
        private System.Windows.Forms.Label _addressLabel;
        private System.Windows.Forms.Label _customerLabel;
        private System.Windows.Forms.TextBox _notesTextBox;
        private System.Windows.Forms.TextBox _shippingAddressTextBox;
        private System.Windows.Forms.TextBox _customerTextBox;
        private System.Windows.Forms.Panel itemsActionPanel;
        private PictureButton addButton;
        private PictureButton cancelButton;
        private PictureButton okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker _shippingDatePicker;
        private System.Windows.Forms.DateTimePicker _orderDatePicker;
        private Microsoft.WindowsCE.Forms.Notification notification;
        private System.Windows.Forms.Panel _buttonPanel;
        private PictureButton _priceListResetButton;
        private PictureButton _priceListLookUpButton;
        private System.Windows.Forms.Panel warehousePanel;
        private System.Windows.Forms.TextBox _warehouseTextBox;
        private System.Windows.Forms.Panel panel1;
        private PictureButton _warehouseResetButton;
        private PictureButton _warehouseLookUpButton;
        private System.Windows.Forms.TextBox _priceListTextBox;
        private MSS.WinMobile.UI.Controls.Concret.OrderItemListBox _orderItemListBox;
        public System.Windows.Forms.Panel pricePanel;
    }
}