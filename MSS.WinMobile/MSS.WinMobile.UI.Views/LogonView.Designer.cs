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
            this._passwordTextBox = new System.Windows.Forms.TextBox();
            this._accountTextBox = new System.Windows.Forms.TextBox();
            this._accountLabel = new System.Windows.Forms.Label();
            this._passwordLabel = new System.Windows.Forms.Label();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._inputPanel = new System.Windows.Forms.Panel();
            this._errorsLabel = new System.Windows.Forms.Label();
            this._actionPanel = new System.Windows.Forms.Panel();
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
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.BackColor = System.Drawing.Color.White;
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this._okButton.Location = new System.Drawing.Point(82, 7);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(72, 20);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "Ok";
            this._okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.BackColor = System.Drawing.Color.White;
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this._cancelButton.Location = new System.Drawing.Point(165, 7);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(72, 20);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // _inputPanel
            // 
            this._inputPanel.Controls.Add(this._errorsLabel);
            this._inputPanel.Controls.Add(this._passwordTextBox);
            this._inputPanel.Controls.Add(this._accountTextBox);
            this._inputPanel.Controls.Add(this._accountLabel);
            this._inputPanel.Controls.Add(this._passwordLabel);
            this._inputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._inputPanel.Location = new System.Drawing.Point(0, 0);
            this._inputPanel.Name = "_inputPanel";
            this._inputPanel.Size = new System.Drawing.Size(240, 294);
            // 
            // _errorsLabel
            // 
            this._errorsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._errorsLabel.ForeColor = System.Drawing.Color.DarkRed;
            this._errorsLabel.Location = new System.Drawing.Point(12, 60);
            this._errorsLabel.Name = "_errorsLabel";
            this._errorsLabel.Size = new System.Drawing.Size(225, 20);
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
            // LogonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this._actionPanel);
            this.Controls.Add(this._inputPanel);
            this.Name = "LogonView";
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
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Panel _inputPanel;
        private System.Windows.Forms.Panel _actionPanel;
        private System.Windows.Forms.Label _errorsLabel;
    }
}