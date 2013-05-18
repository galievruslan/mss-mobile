namespace MSS.WinMobile.UI.Views.Views
{
    partial class SettingsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsView));
            this.tabControl = new System.Windows.Forms.TabControl();
            this._systemTab = new System.Windows.Forms.TabPage();
            this._logoutLinkLabel = new System.Windows.Forms.LinkLabel();
            this._serverNameTextBox = new System.Windows.Forms.TextBox();
            this._serverAddress = new System.Windows.Forms.Label();
            this._passwordTextBox = new System.Windows.Forms.TextBox();
            this._accountTextBox = new System.Windows.Forms.TextBox();
            this._accountLabel = new System.Windows.Forms.Label();
            this._passwordLabel = new System.Windows.Forms.Label();
            this._synchronizationTab = new System.Windows.Forms.TabPage();
            this._batchSizeTextBox = new System.Windows.Forms.TextBox();
            this._batchSizeLabel = new System.Windows.Forms.Label();
            this._actionPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.okButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.tabControl.SuspendLayout();
            this._systemTab.SuspendLayout();
            this._synchronizationTab.SuspendLayout();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this._systemTab);
            this.tabControl.Controls.Add(this._synchronizationTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 238);
            this.tabControl.TabIndex = 0;
            // 
            // _systemTab
            // 
            this._systemTab.Controls.Add(this._logoutLinkLabel);
            this._systemTab.Controls.Add(this._serverNameTextBox);
            this._systemTab.Controls.Add(this._serverAddress);
            this._systemTab.Controls.Add(this._passwordTextBox);
            this._systemTab.Controls.Add(this._accountTextBox);
            this._systemTab.Controls.Add(this._accountLabel);
            this._systemTab.Controls.Add(this._passwordLabel);
            this._systemTab.Location = new System.Drawing.Point(0, 0);
            this._systemTab.Name = "_systemTab";
            this._systemTab.Size = new System.Drawing.Size(240, 215);
            this._systemTab.Text = "System";
            // 
            // _logoutLinkLabel
            // 
            this._logoutLinkLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Underline);
            this._logoutLinkLabel.ForeColor = System.Drawing.Color.Black;
            this._logoutLinkLabel.Location = new System.Drawing.Point(184, 85);
            this._logoutLinkLabel.Name = "_logoutLinkLabel";
            this._logoutLinkLabel.Size = new System.Drawing.Size(49, 20);
            this._logoutLinkLabel.TabIndex = 11;
            this._logoutLinkLabel.Text = "Logout";
            this._logoutLinkLabel.Click += new System.EventHandler(this.LogoutLinkLabelClick);
            // 
            // _serverNameTextBox
            // 
            this._serverNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._serverNameTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._serverNameTextBox.Location = new System.Drawing.Point(78, 7);
            this._serverNameTextBox.Name = "_serverNameTextBox";
            this._serverNameTextBox.Size = new System.Drawing.Size(155, 21);
            this._serverNameTextBox.TabIndex = 9;
            this._serverNameTextBox.TextChanged += new System.EventHandler(this.ServerNameTextBoxTextChanged);
            // 
            // _serverAddress
            // 
            this._serverAddress.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._serverAddress.Location = new System.Drawing.Point(8, 8);
            this._serverAddress.Name = "_serverAddress";
            this._serverAddress.Size = new System.Drawing.Size(64, 20);
            this._serverAddress.Text = "Server";
            // 
            // _passwordTextBox
            // 
            this._passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._passwordTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._passwordTextBox.Location = new System.Drawing.Point(78, 61);
            this._passwordTextBox.Name = "_passwordTextBox";
            this._passwordTextBox.PasswordChar = '*';
            this._passwordTextBox.Size = new System.Drawing.Size(155, 21);
            this._passwordTextBox.TabIndex = 5;
            this._passwordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBoxTextChanged);
            // 
            // _accountTextBox
            // 
            this._accountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._accountTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._accountTextBox.Location = new System.Drawing.Point(78, 34);
            this._accountTextBox.Name = "_accountTextBox";
            this._accountTextBox.Size = new System.Drawing.Size(155, 21);
            this._accountTextBox.TabIndex = 4;
            this._accountTextBox.TextChanged += new System.EventHandler(this.AccountTextBoxTextChanged);
            // 
            // _accountLabel
            // 
            this._accountLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._accountLabel.Location = new System.Drawing.Point(8, 35);
            this._accountLabel.Name = "_accountLabel";
            this._accountLabel.Size = new System.Drawing.Size(64, 20);
            this._accountLabel.Text = "Account";
            // 
            // _passwordLabel
            // 
            this._passwordLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._passwordLabel.Location = new System.Drawing.Point(8, 62);
            this._passwordLabel.Name = "_passwordLabel";
            this._passwordLabel.Size = new System.Drawing.Size(64, 20);
            this._passwordLabel.Text = "Password";
            // 
            // _synchronizationTab
            // 
            this._synchronizationTab.Controls.Add(this._batchSizeTextBox);
            this._synchronizationTab.Controls.Add(this._batchSizeLabel);
            this._synchronizationTab.Location = new System.Drawing.Point(0, 0);
            this._synchronizationTab.Name = "_synchronizationTab";
            this._synchronizationTab.Size = new System.Drawing.Size(240, 215);
            this._synchronizationTab.Text = "Synchronization";
            // 
            // _batchSizeTextBox
            // 
            this._batchSizeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._batchSizeTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._batchSizeTextBox.Location = new System.Drawing.Point(78, 7);
            this._batchSizeTextBox.Name = "_batchSizeTextBox";
            this._batchSizeTextBox.Size = new System.Drawing.Size(155, 21);
            this._batchSizeTextBox.TabIndex = 11;
            this._batchSizeTextBox.TextChanged += new System.EventHandler(this.BatchSizeTextBoxTextChanged);
            // 
            // _batchSizeLabel
            // 
            this._batchSizeLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._batchSizeLabel.Location = new System.Drawing.Point(8, 8);
            this._batchSizeLabel.Name = "_batchSizeLabel";
            this._batchSizeLabel.Size = new System.Drawing.Size(64, 20);
            this._batchSizeLabel.Text = "Batch size";
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
            this.cancelButton.TabIndex = 3;
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
            this.okButton.TabIndex = 2;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this._actionPanel);
            this.Name = "SettingsView";
            this.Load += new MSS.WinMobile.UI.Views.Views.View.OnLoad(this.SettingsViewLoad);
            this.tabControl.ResumeLayout(false);
            this._systemTab.ResumeLayout(false);
            this._synchronizationTab.ResumeLayout(false);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage _systemTab;
        private System.Windows.Forms.TabPage _synchronizationTab;
        private System.Windows.Forms.LinkLabel _logoutLinkLabel;
        private System.Windows.Forms.TextBox _serverNameTextBox;
        private System.Windows.Forms.Label _serverAddress;
        private System.Windows.Forms.TextBox _passwordTextBox;
        private System.Windows.Forms.TextBox _accountTextBox;
        private System.Windows.Forms.Label _accountLabel;
        private System.Windows.Forms.Label _passwordLabel;
        private System.Windows.Forms.Panel _actionPanel;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton cancelButton;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton okButton;
        private System.Windows.Forms.TextBox _batchSizeTextBox;
        private System.Windows.Forms.Label _batchSizeLabel;
    }
}
