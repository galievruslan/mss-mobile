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
            this.SuspendLayout();
            // 
            // _passwordTextBox
            // 
            this._passwordTextBox.Location = new System.Drawing.Point(123, 42);
            this._passwordTextBox.Name = "_passwordTextBox";
            this._passwordTextBox.PasswordChar = '*';
            this._passwordTextBox.Size = new System.Drawing.Size(100, 21);
            this._passwordTextBox.TabIndex = 0;
            this._passwordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBoxTextChanged);
            // 
            // _accountTextBox
            // 
            this._accountTextBox.Location = new System.Drawing.Point(123, 15);
            this._accountTextBox.Name = "_accountTextBox";
            this._accountTextBox.Size = new System.Drawing.Size(100, 21);
            this._accountTextBox.TabIndex = 1;
            this._accountTextBox.TextChanged += new System.EventHandler(this.AccountTextBoxTextChanged);
            // 
            // _accountLabel
            // 
            this._accountLabel.Location = new System.Drawing.Point(17, 16);
            this._accountLabel.Name = "_accountLabel";
            this._accountLabel.Size = new System.Drawing.Size(100, 20);
            this._accountLabel.Text = "Account";
            // 
            // _passwordLabel
            // 
            this._passwordLabel.Location = new System.Drawing.Point(17, 43);
            this._passwordLabel.Name = "_passwordLabel";
            this._passwordLabel.Size = new System.Drawing.Size(100, 20);
            this._passwordLabel.Text = "Password";
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(71, 186);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(72, 20);
            this._okButton.TabIndex = 4;
            this._okButton.Text = "Ok";
            this._okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(149, 186);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(72, 20);
            this._cancelButton.TabIndex = 5;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // LogonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._passwordLabel);
            this.Controls.Add(this._accountLabel);
            this.Controls.Add(this._accountTextBox);
            this.Controls.Add(this._passwordTextBox);
            this.Name = "LogonView";
            this.Size = new System.Drawing.Size(231, 216);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox _passwordTextBox;
        private System.Windows.Forms.TextBox _accountTextBox;
        private System.Windows.Forms.Label _accountLabel;
        private System.Windows.Forms.Label _passwordLabel;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
    }
}