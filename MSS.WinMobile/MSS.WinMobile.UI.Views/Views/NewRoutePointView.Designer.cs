namespace MSS.WinMobile.UI.Views.Views {
    partial class NewRoutePointView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRoutePointView));
            this._customerResetButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._customerLookUpButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._actionPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.okButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._customerLabel = new System.Windows.Forms.Label();
            this._customerTextBox = new System.Windows.Forms.TextBox();
            this._shippingAddressPanel = new System.Windows.Forms.Panel();
            this._shippingAddressTextBox = new System.Windows.Forms.TextBox();
            this._shippingAddressButtonPanel = new System.Windows.Forms.Panel();
            this._shippingAddressResetButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._shippingAddressLookUpButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._customerPanel = new System.Windows.Forms.Panel();
            this._customerButtonPanel = new System.Windows.Forms.Panel();
            this._shippingAddressLabel = new System.Windows.Forms.Label();
            this._actionPanel.SuspendLayout();
            this._shippingAddressPanel.SuspendLayout();
            this._shippingAddressButtonPanel.SuspendLayout();
            this._customerPanel.SuspendLayout();
            this._customerButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _customerResetButton
            // 
            this._customerResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._customerResetButton.BackColor = System.Drawing.Color.White;
            this._customerResetButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_customerResetButton.BackgroundImage")));
            this._customerResetButton.Location = new System.Drawing.Point(2, 24);
            this._customerResetButton.Name = "_customerResetButton";
            this._customerResetButton.PressedImage = null;
            this._customerResetButton.Size = new System.Drawing.Size(22, 24);
            this._customerResetButton.TabIndex = 1;
            this._customerResetButton.Click += new System.EventHandler(this.CustomerResetButtonClick);
            // 
            // _customerLookUpButton
            // 
            this._customerLookUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._customerLookUpButton.BackColor = System.Drawing.Color.White;
            this._customerLookUpButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_customerLookUpButton.BackgroundImage")));
            this._customerLookUpButton.Location = new System.Drawing.Point(2, 0);
            this._customerLookUpButton.Name = "_customerLookUpButton";
            this._customerLookUpButton.PressedImage = null;
            this._customerLookUpButton.Size = new System.Drawing.Size(24, 24);
            this._customerLookUpButton.TabIndex = 0;
            this._customerLookUpButton.Click += new System.EventHandler(this.CustomerLookUpButtonClick);
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this.cancelButton);
            this._actionPanel.Controls.Add(this.okButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._actionPanel.Location = new System.Drawing.Point(0, 238);
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
            // _customerLabel
            // 
            this._customerLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._customerLabel.Location = new System.Drawing.Point(12, 6);
            this._customerLabel.Name = "_customerLabel";
            this._customerLabel.Size = new System.Drawing.Size(64, 20);
            this._customerLabel.Text = "Customer";
            // 
            // _customerTextBox
            // 
            this._customerTextBox.BackColor = System.Drawing.Color.White;
            this._customerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._customerTextBox.Location = new System.Drawing.Point(0, 0);
            this._customerTextBox.Multiline = true;
            this._customerTextBox.Name = "_customerTextBox";
            this._customerTextBox.ReadOnly = true;
            this._customerTextBox.Size = new System.Drawing.Size(131, 48);
            this._customerTextBox.TabIndex = 4;
            // 
            // _shippingAddressPanel
            // 
            this._shippingAddressPanel.Controls.Add(this._shippingAddressTextBox);
            this._shippingAddressPanel.Controls.Add(this._shippingAddressButtonPanel);
            this._shippingAddressPanel.Location = new System.Drawing.Point(82, 56);
            this._shippingAddressPanel.Name = "_shippingAddressPanel";
            this._shippingAddressPanel.Size = new System.Drawing.Size(155, 48);
            // 
            // _shippingAddressTextBox
            // 
            this._shippingAddressTextBox.BackColor = System.Drawing.Color.White;
            this._shippingAddressTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._shippingAddressTextBox.Location = new System.Drawing.Point(0, 0);
            this._shippingAddressTextBox.Multiline = true;
            this._shippingAddressTextBox.Name = "_shippingAddressTextBox";
            this._shippingAddressTextBox.ReadOnly = true;
            this._shippingAddressTextBox.Size = new System.Drawing.Size(131, 48);
            this._shippingAddressTextBox.TabIndex = 4;
            // 
            // _shippingAddressButtonPanel
            // 
            this._shippingAddressButtonPanel.BackColor = System.Drawing.Color.White;
            this._shippingAddressButtonPanel.Controls.Add(this._shippingAddressResetButton);
            this._shippingAddressButtonPanel.Controls.Add(this._shippingAddressLookUpButton);
            this._shippingAddressButtonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._shippingAddressButtonPanel.Location = new System.Drawing.Point(131, 0);
            this._shippingAddressButtonPanel.Name = "_shippingAddressButtonPanel";
            this._shippingAddressButtonPanel.Size = new System.Drawing.Size(24, 48);
            // 
            // _shippingAddressResetButton
            // 
            this._shippingAddressResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._shippingAddressResetButton.BackColor = System.Drawing.Color.White;
            this._shippingAddressResetButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_shippingAddressResetButton.BackgroundImage")));
            this._shippingAddressResetButton.Location = new System.Drawing.Point(2, 24);
            this._shippingAddressResetButton.Name = "_shippingAddressResetButton";
            this._shippingAddressResetButton.PressedImage = null;
            this._shippingAddressResetButton.Size = new System.Drawing.Size(22, 24);
            this._shippingAddressResetButton.TabIndex = 1;
            this._shippingAddressResetButton.Click += new System.EventHandler(this.ShippingAddressResetButtonClick);
            // 
            // _shippingAddressLookUpButton
            // 
            this._shippingAddressLookUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._shippingAddressLookUpButton.BackColor = System.Drawing.Color.White;
            this._shippingAddressLookUpButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_shippingAddressLookUpButton.BackgroundImage")));
            this._shippingAddressLookUpButton.Location = new System.Drawing.Point(2, 0);
            this._shippingAddressLookUpButton.Name = "_shippingAddressLookUpButton";
            this._shippingAddressLookUpButton.PressedImage = null;
            this._shippingAddressLookUpButton.Size = new System.Drawing.Size(22, 24);
            this._shippingAddressLookUpButton.TabIndex = 0;
            this._shippingAddressLookUpButton.Click += new System.EventHandler(this.ShippingAddressLookUpButtonClick);
            // 
            // _customerPanel
            // 
            this._customerPanel.Controls.Add(this._customerTextBox);
            this._customerPanel.Controls.Add(this._customerButtonPanel);
            this._customerPanel.Location = new System.Drawing.Point(82, 2);
            this._customerPanel.Name = "_customerPanel";
            this._customerPanel.Size = new System.Drawing.Size(155, 48);
            // 
            // _customerButtonPanel
            // 
            this._customerButtonPanel.BackColor = System.Drawing.Color.White;
            this._customerButtonPanel.Controls.Add(this._customerResetButton);
            this._customerButtonPanel.Controls.Add(this._customerLookUpButton);
            this._customerButtonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._customerButtonPanel.Location = new System.Drawing.Point(131, 0);
            this._customerButtonPanel.Name = "_customerButtonPanel";
            this._customerButtonPanel.Size = new System.Drawing.Size(24, 48);
            // 
            // _shippingAddressLabel
            // 
            this._shippingAddressLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._shippingAddressLabel.Location = new System.Drawing.Point(12, 56);
            this._shippingAddressLabel.Name = "_shippingAddressLabel";
            this._shippingAddressLabel.Size = new System.Drawing.Size(64, 33);
            this._shippingAddressLabel.Text = "Shipping Address";
            // 
            // NewRoutePointView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this._actionPanel);
            this.Controls.Add(this._customerLabel);
            this.Controls.Add(this._shippingAddressPanel);
            this.Controls.Add(this._customerPanel);
            this.Controls.Add(this._shippingAddressLabel);
            this.Name = "NewRoutePointView";
            this.Load += new MSS.WinMobile.UI.Views.Views.View.OnLoad(this.NewRoutePointViewLoad);
            this._actionPanel.ResumeLayout(false);
            this._shippingAddressPanel.ResumeLayout(false);
            this._shippingAddressButtonPanel.ResumeLayout(false);
            this._customerPanel.ResumeLayout(false);
            this._customerButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _customerResetButton;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _customerLookUpButton;
        private System.Windows.Forms.Panel _actionPanel;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton cancelButton;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton okButton;
        private System.Windows.Forms.Label _customerLabel;
        private System.Windows.Forms.TextBox _customerTextBox;
        private System.Windows.Forms.Panel _shippingAddressPanel;
        private System.Windows.Forms.TextBox _shippingAddressTextBox;
        private System.Windows.Forms.Panel _shippingAddressButtonPanel;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _shippingAddressResetButton;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _shippingAddressLookUpButton;
        private System.Windows.Forms.Panel _customerPanel;
        private System.Windows.Forms.Panel _customerButtonPanel;
        private System.Windows.Forms.Label _shippingAddressLabel;
    }
}
