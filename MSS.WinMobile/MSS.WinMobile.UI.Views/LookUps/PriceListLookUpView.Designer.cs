using MSS.WinMobile.UI.Controls;

namespace MSS.WinMobile.UI.Views.LookUps
{
    partial class PriceListLookUpView
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
            this.searchPanel = new MSS.WinMobile.UI.Controls.SearchPanel();
            this._priceListListBox = new MSS.WinMobile.UI.Controls.Concret.PriceListListBox();
            this.SuspendLayout();
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
            // _priceListListBox
            // 
            this._priceListListBox.BackColor = System.Drawing.Color.White;
            this._priceListListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._priceListListBox.Location = new System.Drawing.Point(0, 24);
            this._priceListListBox.Name = "_priceListListBox";
            this._priceListListBox.Size = new System.Drawing.Size(240, 244);
            this._priceListListBox.TabIndex = 1;
            // 
            // PriceListLookUpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this._priceListListBox);
            this.Controls.Add(this.searchPanel);
            this.Name = "PriceListLookUpView";
            this.Text = "PriceListLookUpView";
            this.Load += new System.EventHandler(this.ViewLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private SearchPanel searchPanel;
        private MSS.WinMobile.UI.Controls.Concret.PriceListListBox _priceListListBox;

    }
}