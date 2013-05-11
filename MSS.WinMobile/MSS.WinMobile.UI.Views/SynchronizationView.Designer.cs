namespace MSS.WinMobile.UI.Views
{
    partial class SynchronizationView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SynchronizationView));
            this._actionPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.okButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._statusPanel = new System.Windows.Forms.Panel();
            this.synchronizationFullyWarningLabel = new System.Windows.Forms.Label();
            this.lastSynchronizationLabel = new System.Windows.Forms.Label();
            this._synchronizeFullyCheckBox = new System.Windows.Forms.CheckBox();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._statusLabel = new System.Windows.Forms.Label();
            this.notification = new Microsoft.WindowsCE.Forms.Notification();
            this._lastSyncDateLabel = new System.Windows.Forms.Label();
            this._actionPanel.SuspendLayout();
            this._statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this.cancelButton);
            this._actionPanel.Controls.Add(this.okButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._actionPanel.Location = new System.Drawing.Point(0, 264);
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
            // _statusPanel
            // 
            this._statusPanel.Controls.Add(this._lastSyncDateLabel);
            this._statusPanel.Controls.Add(this.synchronizationFullyWarningLabel);
            this._statusPanel.Controls.Add(this.lastSynchronizationLabel);
            this._statusPanel.Controls.Add(this._synchronizeFullyCheckBox);
            this._statusPanel.Controls.Add(this._progressBar);
            this._statusPanel.Controls.Add(this._statusLabel);
            this._statusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._statusPanel.Location = new System.Drawing.Point(0, 0);
            this._statusPanel.Name = "_statusPanel";
            this._statusPanel.Size = new System.Drawing.Size(240, 264);
            // 
            // synchronizationFullyWarningLabel
            // 
            this.synchronizationFullyWarningLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this.synchronizationFullyWarningLabel.ForeColor = System.Drawing.Color.Gray;
            this.synchronizationFullyWarningLabel.Location = new System.Drawing.Point(14, 38);
            this.synchronizationFullyWarningLabel.Name = "synchronizationFullyWarningLabel";
            this.synchronizationFullyWarningLabel.Size = new System.Drawing.Size(212, 31);
            this.synchronizationFullyWarningLabel.Text = "(Use only then full synchronization is realy necessary)";
            // 
            // lastSynchronizationLabel
            // 
            this.lastSynchronizationLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this.lastSynchronizationLabel.Location = new System.Drawing.Point(14, 222);
            this.lastSynchronizationLabel.Name = "lastSynchronizationLabel";
            this.lastSynchronizationLabel.Size = new System.Drawing.Size(103, 39);
            this.lastSynchronizationLabel.Text = "Last date synchronization";
            // 
            // _synchronizeFullyCheckBox
            // 
            this._synchronizeFullyCheckBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._synchronizeFullyCheckBox.Location = new System.Drawing.Point(14, 15);
            this._synchronizeFullyCheckBox.Name = "_synchronizeFullyCheckBox";
            this._synchronizeFullyCheckBox.Size = new System.Drawing.Size(210, 20);
            this._synchronizeFullyCheckBox.TabIndex = 4;
            this._synchronizeFullyCheckBox.Text = "Synchronize fully";
            this._synchronizeFullyCheckBox.CheckStateChanged += new System.EventHandler(this.SynchronizeFullyCheckBoxCheckStateChanged);
            // 
            // _progressBar
            // 
            this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._progressBar.Location = new System.Drawing.Point(14, 123);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(212, 20);
            this._progressBar.Visible = false;
            // 
            // _statusLabel
            // 
            this._statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._statusLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._statusLabel.Location = new System.Drawing.Point(14, 99);
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(212, 21);
            this._statusLabel.Text = "Sync...";
            this._statusLabel.Visible = false;
            // 
            // notification
            // 
            this.notification.Text = "notification1";
            // 
            // _lastSyncDateLabel
            // 
            this._lastSyncDateLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._lastSyncDateLabel.Location = new System.Drawing.Point(114, 232);
            this._lastSyncDateLabel.Name = "_lastSyncDateLabel";
            this._lastSyncDateLabel.Size = new System.Drawing.Size(112, 20);
            this._lastSyncDateLabel.Text = "dd.MM.yyyy HH:mm";
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
            this.Load += new System.EventHandler(this.ViewLoad);
            this._actionPanel.ResumeLayout(false);
            this._statusPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _actionPanel;
        private System.Windows.Forms.Panel _statusPanel;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Label _statusLabel;
        private System.Windows.Forms.Label lastSynchronizationLabel;
        private System.Windows.Forms.CheckBox _synchronizeFullyCheckBox;
        private System.Windows.Forms.Label synchronizationFullyWarningLabel;
        private Microsoft.WindowsCE.Forms.Notification notification;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton cancelButton;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton okButton;
        private System.Windows.Forms.Label _lastSyncDateLabel;
    }
}