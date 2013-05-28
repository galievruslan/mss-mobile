using System.Windows.Forms;

namespace MSS.WinMobile.UI.Views.Views {
    partial class ChangeStatusView {
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
                foreach (Control control in _statusesPanel.Controls) {
                    control.Dispose();
                }
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
            this._statusesPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _statusesPanel
            // 
            this._statusesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._statusesPanel.Location = new System.Drawing.Point(15, 15);
            this._statusesPanel.Name = "_statusesPanel";
            this._statusesPanel.Size = new System.Drawing.Size(210, 238);
            // 
            // ChangeStatusView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this._statusesPanel);
            this.Name = "ChangeStatusView";
            this.Size = new System.Drawing.Size(240, 268);
            this.Load += new MSS.WinMobile.UI.Views.Views.View.OnLoad(this.ChangeStatusViewLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _statusesPanel;
    }
}
