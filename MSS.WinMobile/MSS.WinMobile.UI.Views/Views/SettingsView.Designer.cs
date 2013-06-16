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
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this._systemTab = new System.Windows.Forms.TabPage();
            this.localizationViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._languagesComboBox = new System.Windows.Forms.ComboBox();
            this._languageLabel = new System.Windows.Forms.Label();
            this._logoutLinkLabel = new System.Windows.Forms.LinkLabel();
            this._serverNameTextBox = new System.Windows.Forms.TextBox();
            this._serverLabel = new System.Windows.Forms.Label();
            this._passwordTextBox = new System.Windows.Forms.TextBox();
            this._accountTextBox = new System.Windows.Forms.TextBox();
            this._accountLabel = new System.Windows.Forms.Label();
            this._passwordLabel = new System.Windows.Forms.Label();
            this._synchronizationTab = new System.Windows.Forms.TabPage();
            this._batchSizeTextBox = new System.Windows.Forms.TextBox();
            this._batchSizeLabel = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this._systemTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localizationViewModelBindingSource)).BeginInit();
            this._synchronizationTab.SuspendLayout();
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
            this.tabControl.Size = new System.Drawing.Size(240, 268);
            this.tabControl.TabIndex = 0;
            // 
            // _systemTab
            // 
            this._systemTab.Controls.Add(this._languagesComboBox);
            this._systemTab.Controls.Add(this._languageLabel);
            this._systemTab.Controls.Add(this._logoutLinkLabel);
            this._systemTab.Controls.Add(this._serverNameTextBox);
            this._systemTab.Controls.Add(this._serverLabel);
            this._systemTab.Controls.Add(this._passwordTextBox);
            this._systemTab.Controls.Add(this._accountTextBox);
            this._systemTab.Controls.Add(this._accountLabel);
            this._systemTab.Controls.Add(this._passwordLabel);
            this._systemTab.Location = new System.Drawing.Point(0, 0);
            this._systemTab.Name = "_systemTab";
            this._systemTab.Size = new System.Drawing.Size(240, 245);
            this._systemTab.Text = "System";
            // 
            // localizationViewModelBindingSource
            // 
            this.localizationViewModelBindingSource.DataSource = typeof(MSS.WinMobile.UI.Presenters.ViewModels.LocalizationViewModel);
            // 
            // _languagesComboBox
            // 
            this._languagesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._languagesComboBox.DataSource = this.localizationViewModelBindingSource;
            this._languagesComboBox.DisplayMember = "Label";
            this._languagesComboBox.Location = new System.Drawing.Point(78, 88);
            this._languagesComboBox.Name = "_languagesComboBox";
            this._languagesComboBox.Size = new System.Drawing.Size(155, 22);
            this._languagesComboBox.TabIndex = 16;
            this._languagesComboBox.ValueMember = "Name";
            // 
            // _languageLabel
            // 
            this._languageLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._languageLabel.Location = new System.Drawing.Point(8, 90);
            this._languageLabel.Name = "_languageLabel";
            this._languageLabel.Size = new System.Drawing.Size(64, 20);
            this._languageLabel.Text = "Language";
            // 
            // _logoutLinkLabel
            // 
            this._logoutLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._logoutLinkLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Underline);
            this._logoutLinkLabel.ForeColor = System.Drawing.Color.Black;
            this._logoutLinkLabel.Location = new System.Drawing.Point(184, 113);
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
            // _serverLabel
            // 
            this._serverLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._serverLabel.Location = new System.Drawing.Point(8, 8);
            this._serverLabel.Name = "_serverLabel";
            this._serverLabel.Size = new System.Drawing.Size(64, 20);
            this._serverLabel.Text = "Server";
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
            this._synchronizationTab.Size = new System.Drawing.Size(232, 242);
            this._synchronizationTab.Text = "Synchronization";
            // 
            // _batchSizeTextBox
            // 
            this._batchSizeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._batchSizeTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._batchSizeTextBox.Location = new System.Drawing.Point(78, 7);
            this._batchSizeTextBox.Name = "_batchSizeTextBox";
            this._batchSizeTextBox.Size = new System.Drawing.Size(147, 21);
            this._batchSizeTextBox.TabIndex = 11;
            this._batchSizeTextBox.TextChanged += new System.EventHandler(this.BatchSizeTextBoxTextChanged);
            // 
            // _batchSizeLabel
            // 
            this._batchSizeLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._batchSizeLabel.Location = new System.Drawing.Point(8, 8);
            this._batchSizeLabel.Name = "_batchSizeLabel";
            this._batchSizeLabel.Size = new System.Drawing.Size(64, 35);
            this._batchSizeLabel.Text = "Batch size";
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.tabControl);
            this.Name = "SettingsView";
            this.Load += new MSS.WinMobile.UI.Views.Views.View.OnLoad(this.SettingsViewLoad);
            this.tabControl.ResumeLayout(false);
            this._systemTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.localizationViewModelBindingSource)).EndInit();
            this._synchronizationTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage _systemTab;
        private System.Windows.Forms.TabPage _synchronizationTab;
        private System.Windows.Forms.LinkLabel _logoutLinkLabel;
        private System.Windows.Forms.TextBox _serverNameTextBox;
        private System.Windows.Forms.Label _serverLabel;
        private System.Windows.Forms.TextBox _passwordTextBox;
        private System.Windows.Forms.TextBox _accountTextBox;
        private System.Windows.Forms.Label _accountLabel;
        private System.Windows.Forms.Label _passwordLabel;
        private System.Windows.Forms.TextBox _batchSizeTextBox;
        private System.Windows.Forms.Label _batchSizeLabel;
        private System.Windows.Forms.ComboBox _languagesComboBox;
        private System.Windows.Forms.Label _languageLabel;
        private System.Windows.Forms.BindingSource localizationViewModelBindingSource;
    }
}
