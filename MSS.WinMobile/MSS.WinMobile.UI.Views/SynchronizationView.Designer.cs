namespace MSS.WinMobile.UI.Views
{
    partial class SynchronizationView
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
            this._startButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._statusTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _startButton
            // 
            this._startButton.Location = new System.Drawing.Point(73, 236);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(72, 20);
            this._startButton.TabIndex = 0;
            this._startButton.Text = "Start";
            this._startButton.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(151, 236);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(72, 20);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // _statusTextBox
            // 
            this._statusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._statusTextBox.Location = new System.Drawing.Point(15, 3);
            this._statusTextBox.Multiline = true;
            this._statusTextBox.Name = "_statusTextBox";
            this._statusTextBox.Size = new System.Drawing.Size(208, 227);
            this._statusTextBox.TabIndex = 2;
            // 
            // SynchronizationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this._statusTextBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._startButton);
            this.Menu = this.mainMenu1;
            this.Name = "SynchronizationView";
            this.Text = "SynchronizationView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _startButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.TextBox _statusTextBox;
    }
}