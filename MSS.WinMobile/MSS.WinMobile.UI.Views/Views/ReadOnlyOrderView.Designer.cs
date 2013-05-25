﻿using MSS.WinMobile.UI.Controls.Concret;

namespace MSS.WinMobile.UI.Views.Views {
    partial class ReadOnlyOrderView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadOnlyOrderView));
            this.itemsActionPanel = new System.Windows.Forms.Panel();
            this.divisorLabel = new System.Windows.Forms.Label();
            this._amountValueLable = new System.Windows.Forms.Label();
            this._amountLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this._generalTab = new System.Windows.Forms.TabPage();
            this._shippingDateTextBox = new System.Windows.Forms.TextBox();
            this._orderDataTextBox = new System.Windows.Forms.TextBox();
            this.warehousePanel = new System.Windows.Forms.Panel();
            this._warehouseTextBox = new System.Windows.Forms.TextBox();
            this.pricePanel = new System.Windows.Forms.Panel();
            this._priceListTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.cancelButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._actionPanel = new System.Windows.Forms.Panel();
            this.itemsActionPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this._generalTab.SuspendLayout();
            this.warehousePanel.SuspendLayout();
            this.pricePanel.SuspendLayout();
            this._detailsTab.SuspendLayout();
            this._notesTab.SuspendLayout();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemsActionPanel
            // 
            this.itemsActionPanel.Controls.Add(this.divisorLabel);
            this.itemsActionPanel.Controls.Add(this._amountValueLable);
            this.itemsActionPanel.Controls.Add(this._amountLabel);
            this.itemsActionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemsActionPanel.Location = new System.Drawing.Point(0, 0);
            this.itemsActionPanel.Name = "itemsActionPanel";
            this.itemsActionPanel.Size = new System.Drawing.Size(232, 24);
            // 
            // divisorLabel
            // 
            this.divisorLabel.Location = new System.Drawing.Point(100, 3);
            this.divisorLabel.Name = "divisorLabel";
            this.divisorLabel.Size = new System.Drawing.Size(5, 20);
            this.divisorLabel.Text = "|";
            // 
            // _amountValueLable
            // 
            this._amountValueLable.Location = new System.Drawing.Point(165, 3);
            this._amountValueLable.Name = "_amountValueLable";
            this._amountValueLable.Size = new System.Drawing.Size(72, 19);
            this._amountValueLable.Text = "0";
            this._amountValueLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _amountLabel
            // 
            this._amountLabel.Location = new System.Drawing.Point(107, 3);
            this._amountLabel.Name = "_amountLabel";
            this._amountLabel.Size = new System.Drawing.Size(52, 19);
            this._amountLabel.Text = "Amount";
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
            this.tabControl.Size = new System.Drawing.Size(240, 238);
            this.tabControl.TabIndex = 2;
            // 
            // _generalTab
            // 
            this._generalTab.Controls.Add(this._shippingDateTextBox);
            this._generalTab.Controls.Add(this._orderDataTextBox);
            this._generalTab.Controls.Add(this.warehousePanel);
            this._generalTab.Controls.Add(this.pricePanel);
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
            this._generalTab.Size = new System.Drawing.Size(240, 214);
            this._generalTab.Text = "General";
            // 
            // _shippingDateTextBox
            // 
            this._shippingDateTextBox.Location = new System.Drawing.Point(93, 29);
            this._shippingDateTextBox.Name = "_shippingDateTextBox";
            this._shippingDateTextBox.ReadOnly = true;
            this._shippingDateTextBox.Size = new System.Drawing.Size(139, 21);
            this._shippingDateTextBox.TabIndex = 60;
            // 
            // _orderDataTextBox
            // 
            this._orderDataTextBox.Location = new System.Drawing.Point(93, 3);
            this._orderDataTextBox.Name = "_orderDataTextBox";
            this._orderDataTextBox.ReadOnly = true;
            this._orderDataTextBox.Size = new System.Drawing.Size(139, 21);
            this._orderDataTextBox.TabIndex = 59;
            // 
            // warehousePanel
            // 
            this.warehousePanel.Controls.Add(this._warehouseTextBox);
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
            this._warehouseTextBox.Size = new System.Drawing.Size(155, 48);
            this._warehouseTextBox.TabIndex = 5;
            // 
            // pricePanel
            // 
            this.pricePanel.Controls.Add(this._priceListTextBox);
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
            this._priceListTextBox.Size = new System.Drawing.Size(155, 48);
            this._priceListTextBox.TabIndex = 4;
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
            this._detailsTab.Controls.Add(this.orderItemListBox);
            this._detailsTab.Controls.Add(this.itemsActionPanel);
            this._detailsTab.Location = new System.Drawing.Point(0, 0);
            this._detailsTab.Name = "_detailsTab";
            this._detailsTab.Size = new System.Drawing.Size(232, 212);
            this._detailsTab.Text = "Details";
            // 
            // orderItemListBox
            // 
            this.orderItemListBox.BackColor = System.Drawing.Color.White;
            this.orderItemListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderItemListBox.Location = new System.Drawing.Point(0, 24);
            this.orderItemListBox.Name = "orderItemListBox";
            this.orderItemListBox.Size = new System.Drawing.Size(232, 188);
            this.orderItemListBox.TabIndex = 1;
            // 
            // _notesTab
            // 
            this._notesTab.Controls.Add(this._notesTextBox);
            this._notesTab.Location = new System.Drawing.Point(0, 0);
            this._notesTab.Name = "_notesTab";
            this._notesTab.Size = new System.Drawing.Size(232, 212);
            this._notesTab.Text = "Notes";
            // 
            // _notesTextBox
            // 
            this._notesTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._notesTextBox.Location = new System.Drawing.Point(7, 7);
            this._notesTextBox.Multiline = true;
            this._notesTextBox.Name = "_notesTextBox";
            this._notesTextBox.ReadOnly = true;
            this._notesTextBox.Size = new System.Drawing.Size(226, 204);
            this._notesTextBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.White;
            this.cancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelButton.BackgroundImage")));
            this.cancelButton.Location = new System.Drawing.Point(108, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.PressedImage = null;
            this.cancelButton.Size = new System.Drawing.Size(24, 24);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this.cancelButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._actionPanel.Location = new System.Drawing.Point(0, 238);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 30);
            // 
            // ReadOnlyOrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this._actionPanel);
            this.Name = "ReadOnlyOrderView";
            this.Load += new MSS.WinMobile.UI.Views.Views.View.OnLoad(this.OrderViewLoad);
            this.itemsActionPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this._generalTab.ResumeLayout(false);
            this.warehousePanel.ResumeLayout(false);
            this.pricePanel.ResumeLayout(false);
            this._detailsTab.ResumeLayout(false);
            this._notesTab.ResumeLayout(false);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel itemsActionPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage _generalTab;
        private System.Windows.Forms.Panel warehousePanel;
        private System.Windows.Forms.TextBox _warehouseTextBox;
        public System.Windows.Forms.Panel pricePanel;
        private System.Windows.Forms.TextBox _priceListTextBox;
        private System.Windows.Forms.Label label1;
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
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton cancelButton;
        private System.Windows.Forms.Panel _actionPanel;
        private OrderItemListBox orderItemListBox;
        private System.Windows.Forms.Label _amountValueLable;
        private System.Windows.Forms.Label _amountLabel;
        private System.Windows.Forms.Label divisorLabel;
        private System.Windows.Forms.TextBox _shippingDateTextBox;
        private System.Windows.Forms.TextBox _orderDataTextBox;
    }
}
