namespace Updater
{
    partial class Configuration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this._configureMenuItem = new System.Windows.Forms.MenuItem();
            this._cancelUpdatesMenuItem = new System.Windows.Forms.MenuItem();
            this._targetLabel = new System.Windows.Forms.Label();
            this._targetTextBox = new System.Windows.Forms.TextBox();
            this._serverTextBox = new System.Windows.Forms.TextBox();
            this._serverLabel = new System.Windows.Forms.Label();
            this._loginTextBox = new System.Windows.Forms.TextBox();
            this._loginLabel = new System.Windows.Forms.Label();
            this._passwordTextBox = new System.Windows.Forms.TextBox();
            this._passwordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this._configureMenuItem);
            this.mainMenu1.MenuItems.Add(this._cancelUpdatesMenuItem);
            // 
            // _configureMenuItem
            // 
            this._configureMenuItem.Text = "Configure";
            this._configureMenuItem.Click += new System.EventHandler(this.CheckUpdatesMenuItemClick);
            // 
            // _cancelUpdatesMenuItem
            // 
            this._cancelUpdatesMenuItem.Text = "Cancel";
            this._cancelUpdatesMenuItem.Click += new System.EventHandler(this.CancelUpdatesMenuItemClick);
            // 
            // _targetLabel
            // 
            this._targetLabel.Location = new System.Drawing.Point(3, 11);
            this._targetLabel.Name = "_targetLabel";
            this._targetLabel.Size = new System.Drawing.Size(100, 20);
            this._targetLabel.Text = "Target";
            // 
            // _targetTextBox
            // 
            this._targetTextBox.Location = new System.Drawing.Point(109, 10);
            this._targetTextBox.Name = "_targetTextBox";
            this._targetTextBox.Size = new System.Drawing.Size(128, 21);
            this._targetTextBox.TabIndex = 1;
            this._targetTextBox.TextChanged += new System.EventHandler(this.TargetTextBoxTextChanged);
            // 
            // _serverTextBox
            // 
            this._serverTextBox.Location = new System.Drawing.Point(109, 34);
            this._serverTextBox.Name = "_serverTextBox";
            this._serverTextBox.Size = new System.Drawing.Size(128, 21);
            this._serverTextBox.TabIndex = 3;
            this._serverTextBox.TextChanged += new System.EventHandler(this.ServerTextBoxTextChanged);
            // 
            // _serverLabel
            // 
            this._serverLabel.Location = new System.Drawing.Point(3, 35);
            this._serverLabel.Name = "_serverLabel";
            this._serverLabel.Size = new System.Drawing.Size(100, 20);
            this._serverLabel.Text = "Server";
            // 
            // _loginTextBox
            // 
            this._loginTextBox.Location = new System.Drawing.Point(109, 58);
            this._loginTextBox.Name = "_loginTextBox";
            this._loginTextBox.Size = new System.Drawing.Size(128, 21);
            this._loginTextBox.TabIndex = 6;
            this._loginTextBox.TextChanged += new System.EventHandler(this.LoginTextBoxTextChanged);
            // 
            // _loginLabel
            // 
            this._loginLabel.Location = new System.Drawing.Point(3, 59);
            this._loginLabel.Name = "_loginLabel";
            this._loginLabel.Size = new System.Drawing.Size(100, 20);
            this._loginLabel.Text = "Login";
            // 
            // _passwordTextBox
            // 
            this._passwordTextBox.Location = new System.Drawing.Point(109, 82);
            this._passwordTextBox.Name = "_passwordTextBox";
            this._passwordTextBox.PasswordChar = '*';
            this._passwordTextBox.Size = new System.Drawing.Size(128, 21);
            this._passwordTextBox.TabIndex = 9;
            this._passwordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBoxTextChanged);
            // 
            // _passwordLabel
            // 
            this._passwordLabel.Location = new System.Drawing.Point(3, 83);
            this._passwordLabel.Name = "_passwordLabel";
            this._passwordLabel.Size = new System.Drawing.Size(100, 20);
            this._passwordLabel.Text = "Password";
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this._passwordTextBox);
            this.Controls.Add(this._passwordLabel);
            this.Controls.Add(this._loginTextBox);
            this.Controls.Add(this._loginLabel);
            this.Controls.Add(this._serverTextBox);
            this.Controls.Add(this._serverLabel);
            this.Controls.Add(this._targetTextBox);
            this.Controls.Add(this._targetLabel);
            this.Menu = this.mainMenu1;
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _targetLabel;
        private System.Windows.Forms.TextBox _targetTextBox;
        private System.Windows.Forms.TextBox _serverTextBox;
        private System.Windows.Forms.Label _serverLabel;
        private System.Windows.Forms.TextBox _loginTextBox;
        private System.Windows.Forms.Label _loginLabel;
        private System.Windows.Forms.TextBox _passwordTextBox;
        private System.Windows.Forms.Label _passwordLabel;
        private System.Windows.Forms.MenuItem _configureMenuItem;
        private System.Windows.Forms.MenuItem _cancelUpdatesMenuItem;
    }
}