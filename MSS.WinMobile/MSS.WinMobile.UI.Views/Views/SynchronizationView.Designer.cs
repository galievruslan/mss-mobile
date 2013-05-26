namespace MSS.WinMobile.UI.Views.Views {
    partial class SynchronizationView {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this._lastSyncDateLabel = new System.Windows.Forms.Label();
            this.synchronizationFullyWarningLabel = new System.Windows.Forms.Label();
            this._synchronizeFullyCheckBox = new System.Windows.Forms.CheckBox();
            this.lastSynchronizationLabel = new System.Windows.Forms.Label();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._statusLabel = new System.Windows.Forms.Label();
            this._statusPanel = new System.Windows.Forms.Panel();
            this._statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lastSyncDateLabel
            // 
            this._lastSyncDateLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._lastSyncDateLabel.Location = new System.Drawing.Point(114, 202);
            this._lastSyncDateLabel.Name = "_lastSyncDateLabel";
            this._lastSyncDateLabel.Size = new System.Drawing.Size(112, 20);
            this._lastSyncDateLabel.Text = "dd.MM.yyyy HH:mm";
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
            // lastSynchronizationLabel
            // 
            this.lastSynchronizationLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this.lastSynchronizationLabel.Location = new System.Drawing.Point(14, 193);
            this.lastSynchronizationLabel.Name = "lastSynchronizationLabel";
            this.lastSynchronizationLabel.Size = new System.Drawing.Size(103, 39);
            this.lastSynchronizationLabel.Text = "Last date synchronization";
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
            this._statusPanel.Size = new System.Drawing.Size(240, 268);
            // 
            // SynchronizationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this._statusPanel);
            this.Name = "SynchronizationView";
            this.Load += new MSS.WinMobile.UI.Views.Views.View.OnLoad(this.SynchronizationViewLoad);
            this._statusPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _lastSyncDateLabel;
        private System.Windows.Forms.Label synchronizationFullyWarningLabel;
        private System.Windows.Forms.CheckBox _synchronizeFullyCheckBox;
        private System.Windows.Forms.Label lastSynchronizationLabel;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Label _statusLabel;
        private System.Windows.Forms.Panel _statusPanel;
    }
}
