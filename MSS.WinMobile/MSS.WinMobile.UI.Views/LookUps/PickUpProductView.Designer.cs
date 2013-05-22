using MSS.WinMobile.UI.Controls;
using MSS.WinMobile.UI.Controls.Buttons;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickUpProductView));
            this.cancelButton = new MSS.WinMobile.UI.Controls.Buttons.CancelButton();
            this.okButton = new MSS.WinMobile.UI.Controls.Buttons.OkButton();
            this.inputPanel = new Microsoft.WindowsCE.Forms.InputPanel();
            this.quantityPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.nilButton = new System.Windows.Forms.Button();
            this.nineButton = new System.Windows.Forms.Button();
            this.eightButton = new System.Windows.Forms.Button();
            this.sevenButton = new System.Windows.Forms.Button();
            this.sixButton = new System.Windows.Forms.Button();
            this.fiveButton = new System.Windows.Forms.Button();
            this.fourButton = new System.Windows.Forms.Button();
            this.threeButton = new System.Windows.Forms.Button();
            this.twoButton = new System.Windows.Forms.Button();
            this.oneButton = new System.Windows.Forms.Button();
            this._productPriceListBox = new MSS.WinMobile.UI.Controls.Concret.ProductPriceListBox();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this._searchHeaderPanel = new System.Windows.Forms.Panel();
            this._searchPanel = new MSS.WinMobile.UI.Controls.SearchPanel();
            this._filterHeaderPanel = new System.Windows.Forms.Panel();
            this._filterPanel = new MSS.WinMobile.UI.Controls.FilterPanel();
            this.quantityPanel.SuspendLayout();
            this._searchHeaderPanel.SuspendLayout();
            this._filterHeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.White;
            this.cancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelButton.BackgroundImage")));
            this.cancelButton.Location = new System.Drawing.Point(216, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.PressedImage = null;
            this.cancelButton.Size = new System.Drawing.Size(22, 22);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.White;
            this.okButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okButton.BackgroundImage")));
            this.okButton.Location = new System.Drawing.Point(190, 4);
            this.okButton.Name = "okButton";
            this.okButton.PressedImage = null;
            this.okButton.Size = new System.Drawing.Size(22, 22);
            this.okButton.TabIndex = 11;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // quantityPanel
            // 
            this.quantityPanel.Controls.Add(this.okButton);
            this.quantityPanel.Controls.Add(this.cancelButton);
            this.quantityPanel.Controls.Add(this.deleteButton);
            this.quantityPanel.Controls.Add(this.nilButton);
            this.quantityPanel.Controls.Add(this.nineButton);
            this.quantityPanel.Controls.Add(this.eightButton);
            this.quantityPanel.Controls.Add(this.sevenButton);
            this.quantityPanel.Controls.Add(this.sixButton);
            this.quantityPanel.Controls.Add(this.fiveButton);
            this.quantityPanel.Controls.Add(this.fourButton);
            this.quantityPanel.Controls.Add(this.threeButton);
            this.quantityPanel.Controls.Add(this.twoButton);
            this.quantityPanel.Controls.Add(this.oneButton);
            this.quantityPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.quantityPanel.Location = new System.Drawing.Point(0, 238);
            this.quantityPanel.Name = "quantityPanel";
            this.quantityPanel.Size = new System.Drawing.Size(240, 30);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.BackColor = System.Drawing.Color.White;
            this.deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteButton.BackgroundImage")));
            this.deleteButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deleteButton.Location = new System.Drawing.Point(162, 6);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.PressedImage = null;
            this.deleteButton.Size = new System.Drawing.Size(16, 18);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Click += new System.EventHandler(this.DeleteDigitButtonClick);
            // 
            // nilButton
            // 
            this.nilButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nilButton.BackColor = System.Drawing.Color.White;
            this.nilButton.Location = new System.Drawing.Point(146, 6);
            this.nilButton.Name = "nilButton";
            this.nilButton.Size = new System.Drawing.Size(14, 18);
            this.nilButton.TabIndex = 9;
            this.nilButton.Text = "0";
            this.nilButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // nineButton
            // 
            this.nineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nineButton.BackColor = System.Drawing.Color.White;
            this.nineButton.Location = new System.Drawing.Point(130, 6);
            this.nineButton.Name = "nineButton";
            this.nineButton.Size = new System.Drawing.Size(14, 18);
            this.nineButton.TabIndex = 8;
            this.nineButton.Text = "9";
            this.nineButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // eightButton
            // 
            this.eightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.eightButton.BackColor = System.Drawing.Color.White;
            this.eightButton.Location = new System.Drawing.Point(114, 6);
            this.eightButton.Name = "eightButton";
            this.eightButton.Size = new System.Drawing.Size(14, 18);
            this.eightButton.TabIndex = 7;
            this.eightButton.Text = "8";
            this.eightButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // sevenButton
            // 
            this.sevenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sevenButton.BackColor = System.Drawing.Color.White;
            this.sevenButton.Location = new System.Drawing.Point(98, 6);
            this.sevenButton.Name = "sevenButton";
            this.sevenButton.Size = new System.Drawing.Size(14, 18);
            this.sevenButton.TabIndex = 6;
            this.sevenButton.Text = "7";
            this.sevenButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // sixButton
            // 
            this.sixButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sixButton.BackColor = System.Drawing.Color.White;
            this.sixButton.Location = new System.Drawing.Point(82, 6);
            this.sixButton.Name = "sixButton";
            this.sixButton.Size = new System.Drawing.Size(14, 18);
            this.sixButton.TabIndex = 5;
            this.sixButton.Text = "6";
            this.sixButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // fiveButton
            // 
            this.fiveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fiveButton.BackColor = System.Drawing.Color.White;
            this.fiveButton.Location = new System.Drawing.Point(66, 6);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Size = new System.Drawing.Size(14, 18);
            this.fiveButton.TabIndex = 4;
            this.fiveButton.Text = "5";
            this.fiveButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // fourButton
            // 
            this.fourButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fourButton.BackColor = System.Drawing.Color.White;
            this.fourButton.Location = new System.Drawing.Point(50, 6);
            this.fourButton.Name = "fourButton";
            this.fourButton.Size = new System.Drawing.Size(14, 18);
            this.fourButton.TabIndex = 3;
            this.fourButton.Text = "4";
            this.fourButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // threeButton
            // 
            this.threeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.threeButton.BackColor = System.Drawing.Color.White;
            this.threeButton.Location = new System.Drawing.Point(34, 6);
            this.threeButton.Name = "threeButton";
            this.threeButton.Size = new System.Drawing.Size(14, 18);
            this.threeButton.TabIndex = 2;
            this.threeButton.Text = "3";
            this.threeButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // twoButton
            // 
            this.twoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.twoButton.BackColor = System.Drawing.Color.White;
            this.twoButton.Location = new System.Drawing.Point(18, 6);
            this.twoButton.Name = "twoButton";
            this.twoButton.Size = new System.Drawing.Size(14, 18);
            this.twoButton.TabIndex = 1;
            this.twoButton.Text = "2";
            this.twoButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // oneButton
            // 
            this.oneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oneButton.BackColor = System.Drawing.Color.White;
            this.oneButton.Location = new System.Drawing.Point(2, 6);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(14, 18);
            this.oneButton.TabIndex = 0;
            this.oneButton.Text = "1";
            this.oneButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // _productPriceListBox
            // 
            this._productPriceListBox.BackColor = System.Drawing.Color.White;
            this._productPriceListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productPriceListBox.Location = new System.Drawing.Point(0, 48);
            this._productPriceListBox.Name = "_productPriceListBox";
            this._productPriceListBox.Size = new System.Drawing.Size(240, 190);
            this._productPriceListBox.TabIndex = 1;
            // 
            // _searchHeaderPanel
            // 
            this._searchHeaderPanel.Controls.Add(this._searchPanel);
            this._searchHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._searchHeaderPanel.Location = new System.Drawing.Point(0, 24);
            this._searchHeaderPanel.Name = "_searchHeaderPanel";
            this._searchHeaderPanel.Size = new System.Drawing.Size(240, 24);
            // 
            // _searchPanel
            // 
            this._searchPanel.BackColor = System.Drawing.Color.White;
            this._searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._searchPanel.Location = new System.Drawing.Point(0, 0);
            this._searchPanel.Name = "_searchPanel";
            this._searchPanel.Size = new System.Drawing.Size(240, 24);
            this._searchPanel.TabIndex = 5;
            // 
            // _filterHeaderPanel
            // 
            this._filterHeaderPanel.Controls.Add(this._filterPanel);
            this._filterHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._filterHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this._filterHeaderPanel.Name = "_filterHeaderPanel";
            this._filterHeaderPanel.Size = new System.Drawing.Size(240, 24);
            // 
            // _filterPanel
            // 
            this._filterPanel.BackColor = System.Drawing.Color.White;
            this._filterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._filterPanel.Location = new System.Drawing.Point(0, 0);
            this._filterPanel.Name = "_filterPanel";
            this._filterPanel.Size = new System.Drawing.Size(240, 24);
            this._filterPanel.TabIndex = 0;
            this._filterPanel.Filter += new MSS.WinMobile.UI.Controls.FilterPanel.OnFilter(this._filterPanel_Filter);
            this._filterPanel.Clear += new MSS.WinMobile.UI.Controls.FilterPanel.OnClear(this._filterPanel_Clear);
            // 
            // PickUpProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this._productPriceListBox);
            this.Controls.Add(this._searchHeaderPanel);
            this.Controls.Add(this._filterHeaderPanel);
            this.Controls.Add(this.quantityPanel);
            this.Menu = this.mainMenu;
            this.Name = "PickUpProductView";
            this.Text = "CustomerLookUpView";
            this.Load += new System.EventHandler(this.ViewLoad);
            this.quantityPanel.ResumeLayout(false);
            this._searchHeaderPanel.ResumeLayout(false);
            this._filterHeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.WindowsCE.Forms.InputPanel inputPanel;
        private System.Windows.Forms.Panel quantityPanel;
        private System.Windows.Forms.Button oneButton;
        private System.Windows.Forms.Button nilButton;
        private System.Windows.Forms.Button nineButton;
        private System.Windows.Forms.Button eightButton;
        private System.Windows.Forms.Button sevenButton;
        private System.Windows.Forms.Button sixButton;
        private System.Windows.Forms.Button fiveButton;
        private System.Windows.Forms.Button fourButton;
        private System.Windows.Forms.Button threeButton;
        private System.Windows.Forms.Button twoButton;
        private OkButton okButton;
        private CancelButton cancelButton;
        public PictureButton deleteButton;
        private MSS.WinMobile.UI.Controls.Concret.ProductPriceListBox _productPriceListBox;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.Panel _searchHeaderPanel;
        private System.Windows.Forms.Panel _filterHeaderPanel;
        private SearchPanel _searchPanel;
        private FilterPanel _filterPanel;

    }
}