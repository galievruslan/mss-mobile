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
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._infoLabel = new System.Windows.Forms.Label();
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
            // _progressBar
            // 
            this._progressBar.Location = new System.Drawing.Point(18, 36);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(205, 25);
            // 
            // _infoLabel
            // 
            this._infoLabel.Location = new System.Drawing.Point(18, 13);
            this._infoLabel.Name = "_infoLabel";
            this._infoLabel.Size = new System.Drawing.Size(100, 20);
            // 
            // SynchronizationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this._infoLabel);
            this.Controls.Add(this._progressBar);
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
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Label _infoLabel;
    }
}