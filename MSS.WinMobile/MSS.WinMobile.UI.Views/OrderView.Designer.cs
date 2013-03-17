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
            this._detailsTab = new System.Windows.Forms.TabPage();
            this._itemsVirtualListBox = new MSS.WinMobile.UI.Controls.ListBox.VirtualListBox();
            this._notesTab = new System.Windows.Forms.TabPage();
            this._notesTextBox = new System.Windows.Forms.TextBox();
            this._generalTab = new System.Windows.Forms.TabPage();
            this._warehouseComboBox = new System.Windows.Forms.ComboBox();
            this._priceComboBox = new System.Windows.Forms.ComboBox();
            this._warehouseLabel = new System.Windows.Forms.Label();
            this._addressComboBox = new System.Windows.Forms.ComboBox();
            this._customerComboBox = new System.Windows.Forms.ComboBox();
            this._priceLabel = new System.Windows.Forms.Label();
            this._addressLabel = new System.Windows.Forms.Label();
            this._customerLabel = new System.Windows.Forms.Label();
            this._dateTextBox = new System.Windows.Forms.TextBox();
            this._noTextBox = new System.Windows.Forms.TextBox();
            this._noLabel = new System.Windows.Forms.Label();
            this._dateLabel = new System.Windows.Forms.Label();
            this._actionPanel = new System.Windows.Forms.Panel();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this._detailsTab.SuspendLayout();
            this._notesTab.SuspendLayout();
            this._generalTab.SuspendLayout();
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
            this._itemsVirtualListBox.ItemCount = 0;
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
            // _generalTab
            // 
            this._generalTab.Controls.Add(this._warehouseComboBox);
            this._generalTab.Controls.Add(this._priceComboBox);
            this._generalTab.Controls.Add(this._warehouseLabel);
            this._generalTab.Controls.Add(this._addressComboBox);
            this._generalTab.Controls.Add(this._customerComboBox);
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
            // _warehouseComboBox
            // 
            this._warehouseComboBox.Location = new System.Drawing.Point(82, 141);
            this._warehouseComboBox.Name = "_warehouseComboBox";
            this._warehouseComboBox.Size = new System.Drawing.Size(155, 22);
            this._warehouseComboBox.TabIndex = 23;
            // 
            // _priceComboBox
            // 
            this._priceComboBox.Location = new System.Drawing.Point(82, 114);
            this._priceComboBox.Name = "_priceComboBox";
            this._priceComboBox.Size = new System.Drawing.Size(155, 22);
            this._priceComboBox.TabIndex = 22;
            // 
            // _warehouseLabel
            // 
            this._warehouseLabel.Location = new System.Drawing.Point(12, 143);
            this._warehouseLabel.Name = "_warehouseLabel";
            this._warehouseLabel.Size = new System.Drawing.Size(64, 20);
            this._warehouseLabel.Text = "Warehouse";
            // 
            // _addressComboBox
            // 
            this._addressComboBox.Location = new System.Drawing.Point(82, 87);
            this._addressComboBox.Name = "_addressComboBox";
            this._addressComboBox.Size = new System.Drawing.Size(155, 22);
            this._addressComboBox.TabIndex = 18;
            // 
            // _customerComboBox
            // 
            this._customerComboBox.Location = new System.Drawing.Point(82, 60);
            this._customerComboBox.Name = "_customerComboBox";
            this._customerComboBox.Size = new System.Drawing.Size(155, 22);
            this._customerComboBox.TabIndex = 17;
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
            this._detailsTab.ResumeLayout(false);
            this._notesTab.ResumeLayout(false);
            this._generalTab.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox _addressComboBox;
        private System.Windows.Forms.ComboBox _customerComboBox;
        private System.Windows.Forms.Label _priceLabel;
        private System.Windows.Forms.Label _addressLabel;
        private System.Windows.Forms.Label _customerLabel;
        private MSS.WinMobile.UI.Controls.ListBox.VirtualListBox _itemsVirtualListBox;
        private System.Windows.Forms.TextBox _notesTextBox;
        private System.Windows.Forms.ComboBox _warehouseComboBox;
        private System.Windows.Forms.ComboBox _priceComboBox;

    }
}