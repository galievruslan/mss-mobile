using MSS.WinMobile.UI.Controls.Buttons;

namespace MSS.WinMobile.UI.Views
{
    partial class LogonView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogonView));
            this._passwordTextBox = new System.Windows.Forms.TextBox();
            this._accountTextBox = new System.Windows.Forms.TextBox();
            this._accountLabel = new System.Windows.Forms.Label();
            this._passwordLabel = new System.Windows.Forms.Label();
            this._inputPanel = new System.Windows.Forms.Panel();
            this._actionPanel = new System.Windows.Forms.Panel();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.inputPanel = new Microsoft.WindowsCE.Forms.InputPanel();
            this.notification = new Microsoft.WindowsCE.Forms.Notification();
            this.cancelButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.okButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._inputPanel.SuspendLayout();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _passwordTextBox
            // 
            this._passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._passwordTextBox.Location = new System.Drawing.Point(82, 36);
            this._passwordTextBox.Name = "_passwordTextBox";
            this._passwordTextBox.PasswordChar = '*';
            this._passwordTextBox.Size = new System.Drawing.Size(155, 21);
            this._passwordTextBox.TabIndex = 1;
            this._passwordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBoxTextChanged);
            // 
            // _accountTextBox
            // 
            this._accountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._accountTextBox.Location = new System.Drawing.Point(82, 9);
            this._accountTextBox.Name = "_accountTextBox";
            this._accountTextBox.Size = new System.Drawing.Size(155, 21);
            this._accountTextBox.TabIndex = 0;
            this._accountTextBox.TextChanged += new System.EventHandler(this.AccountTextBoxTextChanged);
            // 
            // _accountLabel
            // 
            this._accountLabel.Location = new System.Drawing.Point(12, 10);
            this._accountLabel.Name = "_accountLabel";
            this._accountLabel.Size = new System.Drawing.Size(64, 20);
            this._accountLabel.Text = "Account";
            // 
            // _passwordLabel
            // 
            this._passwordLabel.Location = new System.Drawing.Point(12, 37);
            this._passwordLabel.Name = "_passwordLabel";
            this._passwordLabel.Size = new System.Drawing.Size(64, 20);
            this._passwordLabel.Text = "Password";
            // 
            // _inputPanel
            // 
            this._inputPanel.Controls.Add(this._passwordTextBox);
            this._inputPanel.Controls.Add(this._accountTextBox);
            this._inputPanel.Controls.Add(this._accountLabel);
            this._inputPanel.Controls.Add(this._passwordLabel);
            this._inputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._inputPanel.Location = new System.Drawing.Point(0, 0);
            this._inputPanel.Name = "_inputPanel";
            this._inputPanel.Size = new System.Drawing.Size(240, 268);
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
            // inputPanel
            // 
            this.inputPanel.Enabled = true;
            // 
            // notification
            // 
            this.notification.Text = "notification1";
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
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
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
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // LogonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this._actionPanel);
            this.Controls.Add(this._inputPanel);
            this.Menu = this.mainMenu;
            this.Name = "LogonView";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ViewLoad);
            this._inputPanel.ResumeLayout(false);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox _passwordTextBox;
        private System.Windows.Forms.TextBox _accountTextBox;
        private System.Windows.Forms.Label _accountLabel;
        private System.Windows.Forms.Label _passwordLabel;
        private System.Windows.Forms.Panel _inputPanel;
        private System.Windows.Forms.Panel _actionPanel;
        private System.Windows.Forms.MainMenu mainMenu;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel;
        private Microsoft.WindowsCE.Forms.Notification notification;
        private PictureButton cancelButton;
        private PictureButton okButton;
    }
}