using MSS.WinMobile.UI.Controls;

namespace MSS.WinMobile.UI.Views.LookUps
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
            this._warehouseListBox = new MSS.WinMobile.UI.Controls.Concret.WarehouseListBox();
            this.searchPanel = new MSS.WinMobile.UI.Controls.SearchPanel();
            this.SuspendLayout();
            // 
            // _warehouseListBox
            // 
            this._warehouseListBox.BackColor = System.Drawing.Color.White;
            this._warehouseListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._warehouseListBox.Location = new System.Drawing.Point(0, 24);
            this._warehouseListBox.Name = "_warehouseListBox";
            this._warehouseListBox.Size = new System.Drawing.Size(240, 244);
            this._warehouseListBox.TabIndex = 1;
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(240, 24);
            this.searchPanel.TabIndex = 0;
            this.searchPanel.Clear += new MSS.WinMobile.UI.Controls.SearchPanel.OnClear(this.ClearSearchClick);
            this.searchPanel.Search += new MSS.WinMobile.UI.Controls.SearchPanel.OnSearch(this.DoSearchClick);
            // 
            // WarehouseLookUpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this._warehouseListBox);
            this.Controls.Add(this.searchPanel);
            this.Name = "WarehouseLookUpView";
            this.Text = "WarehouseLookUpView";
            this.Load += new System.EventHandler(this.ViewLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private SearchPanel searchPanel;
        private MSS.WinMobile.UI.Controls.Concret.WarehouseListBox _warehouseListBox;

    }
}