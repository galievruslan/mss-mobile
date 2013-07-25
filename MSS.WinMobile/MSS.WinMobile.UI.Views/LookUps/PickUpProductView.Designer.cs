using MSS.WinMobile.UI.Controls;
using MSS.WinMobile.UI.Controls.Buttons;
using MSS.WinMobile.UI.Controls.Lines;
using MSS.WinMobile.UI.Controls.Panels;

namespace MSS.WinMobile.UI.Views.LookUps
{
    partial class PickUpProductView
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
            this._productPriceListBox = new MSS.WinMobile.UI.Controls.Concret.ProductPriceListBox();
            this._horizontalLine = new MSS.WinMobile.UI.Controls.Lines.HorizontalLine();
            this._actionPanel = new System.Windows.Forms.Panel();
            this.searchPanel = new MSS.WinMobile.UI.Controls.Panels.SearchPanel();
            this._vericalLine = new MSS.WinMobile.UI.Controls.Lines.VericalLine();
            this._informationButton = new MSS.WinMobile.UI.Controls.Buttons.InformationButton();
            this._filterHeaderPanel = new System.Windows.Forms.Panel();
            this._filterPanel = new MSS.WinMobile.UI.Controls.Panels.FilterPanel();
            this._quantityPanel = new MSS.WinMobile.UI.Controls.Panels.QuantityPanel();
            this._productPickUpExtraPanel = new MSS.WinMobile.UI.Controls.Panels.ProductPickUpExtraPanel();
            this.productPickUpExtraPanel1 = new MSS.WinMobile.UI.Controls.Panels.ProductPickUpExtraPanel();
            this._actionPanel.SuspendLayout();
            this._filterHeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _productPriceListBox
            // 
            this._productPriceListBox.BackColor = System.Drawing.Color.White;
            this._productPriceListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productPriceListBox.Location = new System.Drawing.Point(0, 49);
            this._productPriceListBox.Name = "_productPriceListBox";
            this._productPriceListBox.Size = new System.Drawing.Size(240, 175);
            this._productPriceListBox.TabIndex = 1;
            // 
            // _horizontalLine
            // 
            this._horizontalLine.BackColor = System.Drawing.Color.White;
            this._horizontalLine.Dock = System.Windows.Forms.DockStyle.Top;
            this._horizontalLine.LineColor = System.Drawing.Color.DarkGray;
            this._horizontalLine.Location = new System.Drawing.Point(0, 44);
            this._horizontalLine.Name = "_horizontalLine";
            this._horizontalLine.Size = new System.Drawing.Size(240, 5);
            this._horizontalLine.TabIndex = 6;
            this._horizontalLine.TabStop = false;
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this.searchPanel);
            this._actionPanel.Controls.Add(this._vericalLine);
            this._actionPanel.Controls.Add(this._informationButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._actionPanel.Location = new System.Drawing.Point(0, 22);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 22);
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(27, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(213, 22);
            this.searchPanel.TabIndex = 0;
            this.searchPanel.Search += new MSS.WinMobile.UI.Controls.Panels.SearchPanel.OnSearch(this.SearchClick);
            this.searchPanel.Clear += new MSS.WinMobile.UI.Controls.Panels.SearchPanel.OnClear(this.ClearSearchClick);
            // 
            // _vericalLine
            // 
            this._vericalLine.BackColor = System.Drawing.Color.White;
            this._vericalLine.Dock = System.Windows.Forms.DockStyle.Left;
            this._vericalLine.LineColor = System.Drawing.Color.DarkGray;
            this._vericalLine.Location = new System.Drawing.Point(22, 0);
            this._vericalLine.Name = "_vericalLine";
            this._vericalLine.Size = new System.Drawing.Size(5, 22);
            this._vericalLine.TabIndex = 1;
            // 
            // _informationButton
            // 
            this._informationButton.BackColor = System.Drawing.Color.Transparent;
            this._informationButton.Dock = System.Windows.Forms.DockStyle.Left;
            this._informationButton.Location = new System.Drawing.Point(0, 0);
            this._informationButton.Name = "_informationButton";
            this._informationButton.Size = new System.Drawing.Size(22, 22);
            this._informationButton.TabIndex = 0;
            this._informationButton.Click += new System.EventHandler(this.InformationButtonClick);
            // 
            // _filterHeaderPanel
            // 
            this._filterHeaderPanel.Controls.Add(this._filterPanel);
            this._filterHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._filterHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this._filterHeaderPanel.Name = "_filterHeaderPanel";
            this._filterHeaderPanel.Size = new System.Drawing.Size(240, 22);
            // 
            // _filterPanel
            // 
            this._filterPanel.BackColor = System.Drawing.Color.White;
            this._filterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._filterPanel.Location = new System.Drawing.Point(0, 0);
            this._filterPanel.Name = "_filterPanel";
            this._filterPanel.Size = new System.Drawing.Size(240, 22);
            this._filterPanel.TabIndex = 0;
            this._filterPanel.Clear += new MSS.WinMobile.UI.Controls.Panels.FilterPanel.OnClear(this.ClearFilterClick);
            this._filterPanel.Filter += new MSS.WinMobile.UI.Controls.Panels.FilterPanel.OnFilter(this.FilterClick);
            // 
            // _quantityPanel
            // 
            this._quantityPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._quantityPanel.Location = new System.Drawing.Point(0, 224);
            this._quantityPanel.Name = "_quantityPanel";
            this._quantityPanel.Size = new System.Drawing.Size(240, 22);
            this._quantityPanel.TabIndex = 9;
            this._quantityPanel.DigitAdd += new MSS.WinMobile.UI.Controls.Panels.QuantityPanel.OnDigitAdd(this.quantityPanel_DigitAdd);
            this._quantityPanel.DigitRemove += new MSS.WinMobile.UI.Controls.Panels.QuantityPanel.OnDigitRemove(this.quantityPanel_DigitRemove);
            // 
            // _productPickUpExtraPanel
            // 
            this._productPickUpExtraPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._productPickUpExtraPanel.Location = new System.Drawing.Point(0, 246);
            this._productPickUpExtraPanel.Name = "_productPickUpExtraPanel";
            this._productPickUpExtraPanel.Size = new System.Drawing.Size(240, 22);
            this._productPickUpExtraPanel.TabIndex = 10;
            this._productPickUpExtraPanel.UnitOfMeasureChanged += new MSS.WinMobile.UI.Controls.Panels.ProductPickUpExtraPanel.OnUnitOfMeasureChanged(this.productPickUpExtraPanel1_UnitOfMeasureChanged);
            // 
            // productPickUpExtraPanel1
            // 
            this.productPickUpExtraPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.productPickUpExtraPanel1.Location = new System.Drawing.Point(0, 246);
            this.productPickUpExtraPanel1.Name = "productPickUpExtraPanel1";
            this.productPickUpExtraPanel1.Size = new System.Drawing.Size(240, 22);
            this.productPickUpExtraPanel1.TabIndex = 10;
            // 
            // PickUpProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this._productPriceListBox);
            this.Controls.Add(this._quantityPanel);
            this.Controls.Add(this._productPickUpExtraPanel);
            this.Controls.Add(this._horizontalLine);
            this.Controls.Add(this._actionPanel);
            this.Controls.Add(this._filterHeaderPanel);
            this.Name = "PickUpProductView";
            this.Text = "Products pickup";
            this.Load += new System.EventHandler(this.ViewLoad);
            this._actionPanel.ResumeLayout(false);
            this._filterHeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MSS.WinMobile.UI.Controls.Concret.ProductPriceListBox _productPriceListBox;
        private System.Windows.Forms.Panel _filterHeaderPanel;
        private FilterPanel _filterPanel;
        private HorizontalLine _horizontalLine;
        private System.Windows.Forms.Panel _actionPanel;
        private SearchPanel searchPanel;
        private VericalLine _vericalLine;
        private InformationButton _informationButton;
        private QuantityPanel _quantityPanel;
        private ProductPickUpExtraPanel _productPickUpExtraPanel;
        private ProductPickUpExtraPanel productPickUpExtraPanel1;

    }
}