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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderView));
            this.tabControl = new System.Windows.Forms.TabControl();
            this._generalTab = new System.Windows.Forms.TabPage();
            this.warehousePanel = new System.Windows.Forms.Panel();
            this.warehouseTextBox = new System.Windows.Forms.TextBox();
            this.orderViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureButton1 = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.pictureButton2 = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.pricePanel = new System.Windows.Forms.Panel();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this._buttonPanel = new System.Windows.Forms.Panel();
            this.resetButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.lookUpButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this._shippingAddressTextBox = new System.Windows.Forms.TextBox();
            this._customerTextBox = new System.Windows.Forms.TextBox();
            this._warehouseLabel = new System.Windows.Forms.Label();
            this._priceLabel = new System.Windows.Forms.Label();
            this._addressLabel = new System.Windows.Forms.Label();
            this._customerLabel = new System.Windows.Forms.Label();
            this._noTextBox = new System.Windows.Forms.TextBox();
            this._noLabel = new System.Windows.Forms.Label();
            this._orderDateLabel = new System.Windows.Forms.Label();
            this._detailsTab = new System.Windows.Forms.TabPage();
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
            ((System.ComponentModel.ISupportInitialize)(this.orderViewModelBindingSource)).BeginInit();
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
            this._generalTab.Controls.Add(this.dateTimePicker2);
            this._generalTab.Controls.Add(this.dateTimePicker1);
            this._generalTab.Controls.Add(this.label1);
            this._generalTab.Controls.Add(this._shippingAddressTextBox);
            this._generalTab.Controls.Add(this._customerTextBox);
            this._generalTab.Controls.Add(this._warehouseLabel);
            this._generalTab.Controls.Add(this._priceLabel);
            this._generalTab.Controls.Add(this._addressLabel);
            this._generalTab.Controls.Add(this._customerLabel);
            this._generalTab.Controls.Add(this._noTextBox);
            this._generalTab.Controls.Add(this._noLabel);
            this._generalTab.Controls.Add(this._orderDateLabel);
            this._generalTab.Location = new System.Drawing.Point(0, 0);
            this._generalTab.Name = "_generalTab";
            this._generalTab.Size = new System.Drawing.Size(240, 240);
            this._generalTab.Text = "General";
            // 
            // warehousePanel
            // 
            this.warehousePanel.Controls.Add(this.warehouseTextBox);
            this.warehousePanel.Controls.Add(this.panel1);
            this.warehousePanel.Location = new System.Drawing.Point(82, 164);
            this.warehousePanel.Name = "warehousePanel";
            this.warehousePanel.Size = new System.Drawing.Size(155, 24);
            // 
            // warehouseTextBox
            // 
            this.warehouseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderViewModelBindingSource, "WarehouseName", true));
            this.warehouseTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.warehouseTextBox.Location = new System.Drawing.Point(0, 0);
            this.warehouseTextBox.Multiline = true;
            this.warehouseTextBox.Name = "warehouseTextBox";
            this.warehouseTextBox.Size = new System.Drawing.Size(111, 24);
            this.warehouseTextBox.TabIndex = 5;
            // 
            // orderViewModelBindingSource
            // 
            this.orderViewModelBindingSource.DataSource = typeof(MSS.WinMobile.UI.Presenters.ViewModels.OrderViewModel);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureButton1);
            this.panel1.Controls.Add(this.pictureButton2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(111, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(44, 24);
            // 
            // pictureButton1
            // 
            this.pictureButton1.BackColor = System.Drawing.Color.White;
            this.pictureButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureButton1.BackgroundImage")));
            this.pictureButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureButton1.Location = new System.Drawing.Point(22, 0);
            this.pictureButton1.Name = "pictureButton1";
            this.pictureButton1.PressedImage = null;
            this.pictureButton1.Size = new System.Drawing.Size(22, 24);
            this.pictureButton1.TabIndex = 1;
            // 
            // pictureButton2
            // 
            this.pictureButton2.BackColor = System.Drawing.Color.White;
            this.pictureButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureButton2.BackgroundImage")));
            this.pictureButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureButton2.Location = new System.Drawing.Point(0, 0);
            this.pictureButton2.Name = "pictureButton2";
            this.pictureButton2.PressedImage = null;
            this.pictureButton2.Size = new System.Drawing.Size(22, 24);
            this.pictureButton2.TabIndex = 0;
            // 
            // pricePanel
            // 
            this.pricePanel.Controls.Add(this.priceTextBox);
            this.pricePanel.Controls.Add(this._buttonPanel);
            this.pricePanel.Location = new System.Drawing.Point(82, 137);
            this.pricePanel.Name = "pricePanel";
            this.pricePanel.Size = new System.Drawing.Size(155, 24);
            // 
            // priceTextBox
            // 
            this.priceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderViewModelBindingSource, "PriceListName", true));
            this.priceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceTextBox.Location = new System.Drawing.Point(0, 0);
            this.priceTextBox.Multiline = true;
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(111, 24);
            this.priceTextBox.TabIndex = 4;
            // 
            // _buttonPanel
            // 
            this._buttonPanel.BackColor = System.Drawing.Color.White;
            this._buttonPanel.Controls.Add(this.resetButton);
            this._buttonPanel.Controls.Add(this.lookUpButton);
            this._buttonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._buttonPanel.Location = new System.Drawing.Point(111, 0);
            this._buttonPanel.Name = "_buttonPanel";
            this._buttonPanel.Size = new System.Drawing.Size(44, 24);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.White;
            this.resetButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resetButton.BackgroundImage")));
            this.resetButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.resetButton.Location = new System.Drawing.Point(22, 0);
            this.resetButton.Name = "resetButton";
            this.resetButton.PressedImage = null;
            this.resetButton.Size = new System.Drawing.Size(22, 24);
            this.resetButton.TabIndex = 1;
            // 
            // lookUpButton
            // 
            this.lookUpButton.BackColor = System.Drawing.Color.White;
            this.lookUpButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lookUpButton.BackgroundImage")));
            this.lookUpButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.lookUpButton.Location = new System.Drawing.Point(0, 0);
            this.lookUpButton.Name = "lookUpButton";
            this.lookUpButton.PressedImage = null;
            this.lookUpButton.Size = new System.Drawing.Size(22, 24);
            this.lookUpButton.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.orderViewModelBindingSource, "ShippingDate", true));
            this.dateTimePicker2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this.dateTimePicker2.Location = new System.Drawing.Point(112, 60);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(125, 22);
            this.dateTimePicker2.TabIndex = 52;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.orderViewModelBindingSource, "OrderDate", true));
            this.dateTimePicker1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 33);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(125, 22);
            this.dateTimePicker1.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.Text = "Shipping Date";
            // 
            // _shippingAddressTextBox
            // 
            this._shippingAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._shippingAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderViewModelBindingSource, "ShippingAddressName", true));
            this._shippingAddressTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._shippingAddressTextBox.Location = new System.Drawing.Point(82, 112);
            this._shippingAddressTextBox.Name = "_shippingAddressTextBox";
            this._shippingAddressTextBox.ReadOnly = true;
            this._shippingAddressTextBox.Size = new System.Drawing.Size(155, 21);
            this._shippingAddressTextBox.TabIndex = 41;
            // 
            // _customerTextBox
            // 
            this._customerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._customerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderViewModelBindingSource, "CustomerName", true));
            this._customerTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._customerTextBox.Location = new System.Drawing.Point(82, 86);
            this._customerTextBox.Name = "_customerTextBox";
            this._customerTextBox.ReadOnly = true;
            this._customerTextBox.Size = new System.Drawing.Size(155, 21);
            this._customerTextBox.TabIndex = 40;
            // 
            // _warehouseLabel
            // 
            this._warehouseLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._warehouseLabel.Location = new System.Drawing.Point(12, 168);
            this._warehouseLabel.Name = "_warehouseLabel";
            this._warehouseLabel.Size = new System.Drawing.Size(64, 20);
            this._warehouseLabel.Text = "Warehouse";
            // 
            // _priceLabel
            // 
            this._priceLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._priceLabel.Location = new System.Drawing.Point(12, 141);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(64, 20);
            this._priceLabel.Text = "Price";
            // 
            // _addressLabel
            // 
            this._addressLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._addressLabel.Location = new System.Drawing.Point(12, 114);
            this._addressLabel.Name = "_addressLabel";
            this._addressLabel.Size = new System.Drawing.Size(64, 20);
            this._addressLabel.Text = "Address";
            // 
            // _customerLabel
            // 
            this._customerLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._customerLabel.Location = new System.Drawing.Point(12, 87);
            this._customerLabel.Name = "_customerLabel";
            this._customerLabel.Size = new System.Drawing.Size(64, 20);
            this._customerLabel.Text = "Customer";
            // 
            // _noTextBox
            // 
            this._noTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._noTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderViewModelBindingSource, "OrderId", true));
            this._noTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._noTextBox.Location = new System.Drawing.Point(112, 7);
            this._noTextBox.Name = "_noTextBox";
            this._noTextBox.ReadOnly = true;
            this._noTextBox.Size = new System.Drawing.Size(125, 21);
            this._noTextBox.TabIndex = 4;
            // 
            // _noLabel
            // 
            this._noLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._noLabel.Location = new System.Drawing.Point(12, 8);
            this._noLabel.Name = "_noLabel";
            this._noLabel.Size = new System.Drawing.Size(94, 20);
            this._noLabel.Text = "No #";
            // 
            // _orderDateLabel
            // 
            this._orderDateLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._orderDateLabel.Location = new System.Drawing.Point(12, 35);
            this._orderDateLabel.Name = "_orderDateLabel";
            this._orderDateLabel.Size = new System.Drawing.Size(94, 20);
            this._orderDateLabel.Text = "Order Date";
            // 
            // _detailsTab
            // 
            this._detailsTab.Controls.Add(this.itemsActionPanel);
            this._detailsTab.Location = new System.Drawing.Point(0, 0);
            this._detailsTab.Name = "_detailsTab";
            this._detailsTab.Size = new System.Drawing.Size(232, 238);
            this._detailsTab.Text = "Details";
            // 
            // itemsActionPanel
            // 
            this.itemsActionPanel.Controls.Add(this.addButton);
            this.itemsActionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemsActionPanel.Location = new System.Drawing.Point(0, 0);
            this.itemsActionPanel.Name = "itemsActionPanel";
            this.itemsActionPanel.Size = new System.Drawing.Size(232, 24);
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
            this.Load += new System.EventHandler(this.OrderView_Load);
            this.tabControl.ResumeLayout(false);
            this._generalTab.ResumeLayout(false);
            this.warehousePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderViewModelBindingSource)).EndInit();
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
        private System.Windows.Forms.Label _noLabel;
        private System.Windows.Forms.Label _orderDateLabel;
        private System.Windows.Forms.TextBox _noTextBox;
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
        private System.Windows.Forms.BindingSource orderViewModelBindingSource;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Microsoft.WindowsCE.Forms.Notification notification;
        private System.Windows.Forms.Panel pricePanel;
        private System.Windows.Forms.Panel _buttonPanel;
        private PictureButton resetButton;
        private PictureButton lookUpButton;
        private System.Windows.Forms.Panel warehousePanel;
        private System.Windows.Forms.TextBox warehouseTextBox;
        private System.Windows.Forms.Panel panel1;
        private PictureButton pictureButton1;
        private PictureButton pictureButton2;
        private System.Windows.Forms.TextBox priceTextBox;
    }
}