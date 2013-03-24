using MSS.WinMobile.Domain.Models;

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
            this.tabControl = new System.Windows.Forms.TabControl();
            this._generalTab = new System.Windows.Forms.TabPage();
            this._warehouseLookUpBox = new MSS.WinMobile.UI.Controls.LookUpBox();
            this._priceLookUpBox = new MSS.WinMobile.UI.Controls.LookUpBox();
            this._shippingAddressLookUpBox = new MSS.WinMobile.UI.Controls.LookUpBox();
            this._customerLookUpBox = new MSS.WinMobile.UI.Controls.LookUpBox();
            this._warehouseLabel = new System.Windows.Forms.Label();
            this._priceLabel = new System.Windows.Forms.Label();
            this._addressLabel = new System.Windows.Forms.Label();
            this._customerLabel = new System.Windows.Forms.Label();
            this._dateTextBox = new System.Windows.Forms.TextBox();
            this._noTextBox = new System.Windows.Forms.TextBox();
            this._noLabel = new System.Windows.Forms.Label();
            this._dateLabel = new System.Windows.Forms.Label();
            this._detailsTab = new System.Windows.Forms.TabPage();
            this._itemsVirtualListBox = new MSS.WinMobile.UI.Controls.ListBox.OrderItemListBox();
            this._notesTab = new System.Windows.Forms.TabPage();
            this._notesTextBox = new System.Windows.Forms.TextBox();
            this._actionPanel = new System.Windows.Forms.Panel();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.notification = new Microsoft.WindowsCE.Forms.Notification();
            this.tabControl.SuspendLayout();
            this._generalTab.SuspendLayout();
            this._detailsTab.SuspendLayout();
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
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 264);
            this.tabControl.TabIndex = 0;
            // 
            // _generalTab
            // 
            this._generalTab.Controls.Add(this._warehouseLookUpBox);
            this._generalTab.Controls.Add(this._priceLookUpBox);
            this._generalTab.Controls.Add(this._shippingAddressLookUpBox);
            this._generalTab.Controls.Add(this._customerLookUpBox);
            this._generalTab.Controls.Add(this._warehouseLabel);
            this._generalTab.Controls.Add(this._priceLabel);
            this._generalTab.Controls.Add(this._addressLabel);
            this._generalTab.Controls.Add(this._customerLabel);
            this._generalTab.Controls.Add(this._dateTextBox);
            this._generalTab.Controls.Add(this._noTextBox);
            this._generalTab.Controls.Add(this._noLabel);
            this._generalTab.Controls.Add(this._dateLabel);
            this._generalTab.Location = new System.Drawing.Point(0, 0);
            this._generalTab.Name = "_generalTab";
            this._generalTab.Size = new System.Drawing.Size(240, 241);
            this._generalTab.Text = "General";
            // 
            // _warehouseLookUpBox
            // 
            this._warehouseLookUpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._warehouseLookUpBox.Label = "- none -";
            this._warehouseLookUpBox.Location = new System.Drawing.Point(82, 141);
            this._warehouseLookUpBox.Name = "_warehouseLookUpBox";
            this._warehouseLookUpBox.Size = new System.Drawing.Size(155, 22);
            this._warehouseLookUpBox.TabIndex = 33;
            this._warehouseLookUpBox.Value = null;
            this._warehouseLookUpBox.LookUp += new MSS.WinMobile.UI.Controls.LookUpBox.OnLookUp(this._warehouseLookUpBox_LookUp);
            // 
            // _priceLookUpBox
            // 
            this._priceLookUpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._priceLookUpBox.Label = "- none -";
            this._priceLookUpBox.Location = new System.Drawing.Point(82, 114);
            this._priceLookUpBox.Name = "_priceLookUpBox";
            this._priceLookUpBox.Size = new System.Drawing.Size(155, 22);
            this._priceLookUpBox.TabIndex = 32;
            this._priceLookUpBox.Value = null;
            this._priceLookUpBox.LookUp += new MSS.WinMobile.UI.Controls.LookUpBox.OnLookUp(this._priceLookUpBox_LookUp);
            // 
            // _shippingAddressLookUpBox
            // 
            this._shippingAddressLookUpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._shippingAddressLookUpBox.Label = "- none -";
            this._shippingAddressLookUpBox.Location = new System.Drawing.Point(82, 87);
            this._shippingAddressLookUpBox.Name = "_shippingAddressLookUpBox";
            this._shippingAddressLookUpBox.Size = new System.Drawing.Size(155, 22);
            this._shippingAddressLookUpBox.TabIndex = 31;
            this._shippingAddressLookUpBox.Value = null;
            this._shippingAddressLookUpBox.LookUp += new MSS.WinMobile.UI.Controls.LookUpBox.OnLookUp(this._addressLookUpBox_LookUp);
            // 
            // _customerLookUpBox
            // 
            this._customerLookUpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._customerLookUpBox.Label = "- none -";
            this._customerLookUpBox.Location = new System.Drawing.Point(82, 59);
            this._customerLookUpBox.Name = "_customerLookUpBox";
            this._customerLookUpBox.Size = new System.Drawing.Size(155, 22);
            this._customerLookUpBox.TabIndex = 30;
            this._customerLookUpBox.Value = null;
            this._customerLookUpBox.LookUp += new MSS.WinMobile.UI.Controls.LookUpBox.OnLookUp(this._customerLookUpBox_LookUp);
            // 
            // _warehouseLabel
            // 
            this._warehouseLabel.Location = new System.Drawing.Point(12, 143);
            this._warehouseLabel.Name = "_warehouseLabel";
            this._warehouseLabel.Size = new System.Drawing.Size(64, 20);
            this._warehouseLabel.Text = "Warehouse";
            // 
            // _priceLabel
            // 
            this._priceLabel.Location = new System.Drawing.Point(12, 116);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(64, 20);
            this._priceLabel.Text = "Price";
            // 
            // _addressLabel
            // 
            this._addressLabel.Location = new System.Drawing.Point(12, 89);
            this._addressLabel.Name = "_addressLabel";
            this._addressLabel.Size = new System.Drawing.Size(64, 20);
            this._addressLabel.Text = "Address";
            // 
            // _customerLabel
            // 
            this._customerLabel.Location = new System.Drawing.Point(12, 62);
            this._customerLabel.Name = "_customerLabel";
            this._customerLabel.Size = new System.Drawing.Size(64, 20);
            this._customerLabel.Text = "Customer";
            // 
            // _dateTextBox
            // 
            this._dateTextBox.AcceptsReturn = true;
            this._dateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dateTextBox.Location = new System.Drawing.Point(82, 34);
            this._dateTextBox.Name = "_dateTextBox";
            this._dateTextBox.ReadOnly = true;
            this._dateTextBox.Size = new System.Drawing.Size(155, 21);
            this._dateTextBox.TabIndex = 5;
            // 
            // _noTextBox
            // 
            this._noTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._noTextBox.Location = new System.Drawing.Point(82, 7);
            this._noTextBox.Name = "_noTextBox";
            this._noTextBox.ReadOnly = true;
            this._noTextBox.Size = new System.Drawing.Size(155, 21);
            this._noTextBox.TabIndex = 4;
            // 
            // _noLabel
            // 
            this._noLabel.Location = new System.Drawing.Point(12, 8);
            this._noLabel.Name = "_noLabel";
            this._noLabel.Size = new System.Drawing.Size(64, 20);
            this._noLabel.Text = "No #";
            // 
            // _dateLabel
            // 
            this._dateLabel.Location = new System.Drawing.Point(12, 35);
            this._dateLabel.Name = "_dateLabel";
            this._dateLabel.Size = new System.Drawing.Size(64, 20);
            this._dateLabel.Text = "Date";
            // 
            // _detailsTab
            // 
            this._detailsTab.Controls.Add(this._itemsVirtualListBox);
            this._detailsTab.Location = new System.Drawing.Point(0, 0);
            this._detailsTab.Name = "_detailsTab";
            this._detailsTab.Size = new System.Drawing.Size(232, 238);
            this._detailsTab.Text = "Details";
            // 
            // _itemsVirtualListBox
            // 
            this._itemsVirtualListBox.BackColor = System.Drawing.Color.White;
            this._itemsVirtualListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._itemsVirtualListBox.Location = new System.Drawing.Point(0, 0);
            this._itemsVirtualListBox.Name = "_itemsVirtualListBox";
            this._itemsVirtualListBox.SelectedIndex = -1;
            this._itemsVirtualListBox.Size = new System.Drawing.Size(232, 238);
            this._itemsVirtualListBox.TabIndex = 0;
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
            this._notesTextBox.Location = new System.Drawing.Point(7, 7);
            this._notesTextBox.Multiline = true;
            this._notesTextBox.Name = "_notesTextBox";
            this._notesTextBox.Size = new System.Drawing.Size(226, 231);
            this._notesTextBox.TabIndex = 0;
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this._okButton);
            this._actionPanel.Controls.Add(this._cancelButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._actionPanel.Location = new System.Drawing.Point(0, 264);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 30);
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.BackColor = System.Drawing.Color.White;
            this._okButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this._okButton.Location = new System.Drawing.Point(82, 7);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(72, 20);
            this._okButton.TabIndex = 2;
            this._okButton.Text = "Ok";
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.BackColor = System.Drawing.Color.White;
            this._cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this._cancelButton.Location = new System.Drawing.Point(165, 7);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(72, 20);
            this._cancelButton.TabIndex = 3;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // notification
            // 
            this.notification.Text = "notification";
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
            this._detailsTab.ResumeLayout(false);
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
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.TextBox _dateTextBox;
        private System.Windows.Forms.Label _noLabel;
        private System.Windows.Forms.Label _dateLabel;
        private System.Windows.Forms.TextBox _noTextBox;
        private System.Windows.Forms.Label _warehouseLabel;
        private System.Windows.Forms.Label _priceLabel;
        private System.Windows.Forms.Label _addressLabel;
        private System.Windows.Forms.Label _customerLabel;
        private MSS.WinMobile.UI.Controls.ListBox.OrderItemListBox _itemsVirtualListBox;
        private System.Windows.Forms.TextBox _notesTextBox;
        private MSS.WinMobile.UI.Controls.LookUpBox _customerLookUpBox;
        private MSS.WinMobile.UI.Controls.LookUpBox _warehouseLookUpBox;
        private MSS.WinMobile.UI.Controls.LookUpBox _priceLookUpBox;
        private MSS.WinMobile.UI.Controls.LookUpBox _shippingAddressLookUpBox;
        private Microsoft.WindowsCE.Forms.Notification notification;

    }
}