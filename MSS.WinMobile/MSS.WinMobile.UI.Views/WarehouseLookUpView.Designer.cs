using MSS.WinMobile.UI.Controls;

namespace MSS.WinMobile.UI.Views
{
    partial class WarehouseLookUpView
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
            this._actionPanel = new System.Windows.Forms.Panel();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.searchPanel = new SearchPanel();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
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
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.BackColor = System.Drawing.Color.White;
            this._okButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this._okButton.Location = new System.Drawing.Point(82, 7);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(72, 20);
            this._okButton.TabIndex = 2;
            this._okButton.Text = "Ok";
            this._okButton.Click += new System.EventHandler(this.OkClick);
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.BackColor = System.Drawing.Color.White;
            this._cancelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this._cancelButton.Location = new System.Drawing.Point(165, 7);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(72, 20);
            this._cancelButton.TabIndex = 3;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.Click += new System.EventHandler(this.CancelClick);
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(240, 24);
            this.searchPanel.TabIndex = 0;
            // 
            // CustomerLookUpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this._actionPanel);
            this.Controls.Add(this.searchPanel);
            this.Name = "WarehouseLookUpView";
            this.Text = "WarehouseLookUpView";
            this.Load += new System.EventHandler(this.ViewLoad);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SearchPanel searchPanel;
        private System.Windows.Forms.Panel _actionPanel;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;

    }
}