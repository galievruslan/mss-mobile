using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.UI.Views
{
    partial class CustomersView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._viewActionsPanel = new System.Windows.Forms.Panel();
            this._customersListBox = new MSS.WinMobile.UI.Controls.ListBox.VirtualListBox<Customer>();
            this.SuspendLayout();
            // 
            // _viewActionsPanel
            // 
            this._viewActionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._viewActionsPanel.Location = new System.Drawing.Point(0, 0);
            this._viewActionsPanel.Name = "_viewActionsPanel";
            this._viewActionsPanel.Size = new System.Drawing.Size(226, 24);
            // 
            // _customersListBox
            // 
            this._customersListBox.BackColor = System.Drawing.Color.White;
            this._customersListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._customersListBox.ItemCount = 0;
            this._customersListBox.Location = new System.Drawing.Point(0, 24);
            this._customersListBox.Name = "_customersListBox";
            this._customersListBox.SelectedIndex = 0;
            this._customersListBox.Size = new System.Drawing.Size(226, 249);
            this._customersListBox.TabIndex = 1;
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this._customersListBox);
            this.Controls.Add(this._viewActionsPanel);
            this.Name = "Customers";
            this.Size = new System.Drawing.Size(226, 273);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _viewActionsPanel;
        private MSS.WinMobile.UI.Controls.ListBox.VirtualListBox<Customer> _customersListBox;
    }
}
