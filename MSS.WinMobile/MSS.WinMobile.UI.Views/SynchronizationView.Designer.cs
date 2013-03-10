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
            this._actionPanel = new System.Windows.Forms.Panel();
            this._statusPanel = new System.Windows.Forms.Panel();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._statusLabel = new System.Windows.Forms.Label();
            this._errorsLabel = new System.Windows.Forms.Label();
            this._actionPanel.SuspendLayout();
            this._statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _startButton
            // 
            this._startButton.BackColor = System.Drawing.Color.White;
            this._startButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this._startButton.Location = new System.Drawing.Point(87, 7);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(72, 20);
            this._startButton.TabIndex = 0;
            this._startButton.Text = "Start";
            this._startButton.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // _cancelButton
            // 
            this._cancelButton.BackColor = System.Drawing.Color.White;
            this._cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this._cancelButton.Location = new System.Drawing.Point(165, 7);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(72, 20);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this._cancelButton);
            this._actionPanel.Controls.Add(this._startButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._actionPanel.Location = new System.Drawing.Point(0, 264);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 30);
            // 
            // _statusPanel
            // 
            this._statusPanel.Controls.Add(this._errorsLabel);
            this._statusPanel.Controls.Add(this._progressBar);
            this._statusPanel.Controls.Add(this._statusLabel);
            this._statusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._statusPanel.Location = new System.Drawing.Point(0, 0);
            this._statusPanel.Name = "_statusPanel";
            this._statusPanel.Size = new System.Drawing.Size(240, 264);
            // 
            // _progressBar
            // 
            this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._progressBar.Location = new System.Drawing.Point(3, 35);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(234, 20);
            // 
            // _statusLabel
            // 
            this._statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._statusLabel.Location = new System.Drawing.Point(3, 12);
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(234, 20);
            this._statusLabel.Text = "Sync...";
            // 
            // _errorsLabel
            // 
            this._errorsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._errorsLabel.ForeColor = System.Drawing.Color.DarkRed;
            this._errorsLabel.Location = new System.Drawing.Point(3, 58);
            this._errorsLabel.Name = "_errorsLabel";
            this._errorsLabel.Size = new System.Drawing.Size(234, 20);
            // 
            // SynchronizationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this._statusPanel);
            this.Controls.Add(this._actionPanel);
            this.Name = "SynchronizationView";
            this.Load += new System.EventHandler(this.SynchronizationView_Load);
            this._actionPanel.ResumeLayout(false);
            this._statusPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _startButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Panel _actionPanel;
        private System.Windows.Forms.Panel _statusPanel;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Label _statusLabel;
        private System.Windows.Forms.Label _errorsLabel;
    }
}