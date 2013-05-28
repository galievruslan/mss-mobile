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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickUpProductView));
            this.quantityPanel = new System.Windows.Forms.Panel();
            this.unitOfMeasureViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._uomComboBox = new System.Windows.Forms.ComboBox();
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
            this._filterHeaderPanel = new System.Windows.Forms.Panel();
            this._filterPanel = new MSS.WinMobile.UI.Controls.FilterPanel();
            this._horizontalLine = new MSS.WinMobile.UI.Controls.HorizontalLine();
            this._actionPanel = new System.Windows.Forms.Panel();
            this.searchPanel = new MSS.WinMobile.UI.Controls.SearchPanel();
            this._vericalLine = new MSS.WinMobile.UI.Controls.VericalLine();
            this._informationButton = new MSS.WinMobile.UI.Controls.Buttons.InformationButton();
            this.quantityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfMeasureViewModelBindingSource)).BeginInit();
            this._filterHeaderPanel.SuspendLayout();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // quantityPanel
            // 
            this.quantityPanel.Controls.Add(this._uomComboBox);
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
            // unitOfMeasureViewModelBindingSource
            // 
            this.unitOfMeasureViewModelBindingSource.DataSource = typeof(MSS.WinMobile.UI.Presenters.ViewModels.UnitOfMeasureViewModel);
            // 
            // _uomComboBox
            // 
            this._uomComboBox.DataSource = this.unitOfMeasureViewModelBindingSource;
            this._uomComboBox.DisplayMember = "Name";
            this._uomComboBox.Location = new System.Drawing.Point(170, 4);
            this._uomComboBox.Name = "_uomComboBox";
            this._uomComboBox.Size = new System.Drawing.Size(67, 22);
            this._uomComboBox.TabIndex = 11;
            this._uomComboBox.ValueMember = "Id";
            this._uomComboBox.SelectedValueChanged += new System.EventHandler(this._uomComboBox_SelectedValueChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.BackColor = System.Drawing.Color.White;
            this.deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteButton.BackgroundImage")));
            this.deleteButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deleteButton.Location = new System.Drawing.Point(152, 6);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("deleteButton.PressedImage")));
            this.deleteButton.Size = new System.Drawing.Size(16, 18);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Click += new System.EventHandler(this.DeleteDigitButtonClick);
            // 
            // nilButton
            // 
            this.nilButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nilButton.BackColor = System.Drawing.Color.White;
            this.nilButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.nilButton.Location = new System.Drawing.Point(137, 6);
            this.nilButton.Name = "nilButton";
            this.nilButton.Size = new System.Drawing.Size(13, 18);
            this.nilButton.TabIndex = 9;
            this.nilButton.Text = "0";
            this.nilButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // nineButton
            // 
            this.nineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nineButton.BackColor = System.Drawing.Color.White;
            this.nineButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.nineButton.Location = new System.Drawing.Point(122, 6);
            this.nineButton.Name = "nineButton";
            this.nineButton.Size = new System.Drawing.Size(13, 18);
            this.nineButton.TabIndex = 8;
            this.nineButton.Text = "9";
            this.nineButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // eightButton
            // 
            this.eightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.eightButton.BackColor = System.Drawing.Color.White;
            this.eightButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.eightButton.Location = new System.Drawing.Point(107, 6);
            this.eightButton.Name = "eightButton";
            this.eightButton.Size = new System.Drawing.Size(13, 18);
            this.eightButton.TabIndex = 7;
            this.eightButton.Text = "8";
            this.eightButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // sevenButton
            // 
            this.sevenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sevenButton.BackColor = System.Drawing.Color.White;
            this.sevenButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.sevenButton.Location = new System.Drawing.Point(92, 6);
            this.sevenButton.Name = "sevenButton";
            this.sevenButton.Size = new System.Drawing.Size(13, 18);
            this.sevenButton.TabIndex = 6;
            this.sevenButton.Text = "7";
            this.sevenButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // sixButton
            // 
            this.sixButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sixButton.BackColor = System.Drawing.Color.White;
            this.sixButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.sixButton.Location = new System.Drawing.Point(77, 6);
            this.sixButton.Name = "sixButton";
            this.sixButton.Size = new System.Drawing.Size(13, 18);
            this.sixButton.TabIndex = 5;
            this.sixButton.Text = "6";
            this.sixButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // fiveButton
            // 
            this.fiveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fiveButton.BackColor = System.Drawing.Color.White;
            this.fiveButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.fiveButton.Location = new System.Drawing.Point(62, 6);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Size = new System.Drawing.Size(13, 18);
            this.fiveButton.TabIndex = 4;
            this.fiveButton.Text = "5";
            this.fiveButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // fourButton
            // 
            this.fourButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fourButton.BackColor = System.Drawing.Color.White;
            this.fourButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.fourButton.Location = new System.Drawing.Point(47, 6);
            this.fourButton.Name = "fourButton";
            this.fourButton.Size = new System.Drawing.Size(13, 18);
            this.fourButton.TabIndex = 3;
            this.fourButton.Text = "4";
            this.fourButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // threeButton
            // 
            this.threeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.threeButton.BackColor = System.Drawing.Color.White;
            this.threeButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.threeButton.Location = new System.Drawing.Point(32, 6);
            this.threeButton.Name = "threeButton";
            this.threeButton.Size = new System.Drawing.Size(13, 18);
            this.threeButton.TabIndex = 2;
            this.threeButton.Text = "3";
            this.threeButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // twoButton
            // 
            this.twoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.twoButton.BackColor = System.Drawing.Color.White;
            this.twoButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.twoButton.Location = new System.Drawing.Point(17, 6);
            this.twoButton.Name = "twoButton";
            this.twoButton.Size = new System.Drawing.Size(13, 18);
            this.twoButton.TabIndex = 1;
            this.twoButton.Text = "2";
            this.twoButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // oneButton
            // 
            this.oneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oneButton.BackColor = System.Drawing.Color.White;
            this.oneButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.oneButton.Location = new System.Drawing.Point(2, 6);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(13, 18);
            this.oneButton.TabIndex = 0;
            this.oneButton.Text = "1";
            this.oneButton.Click += new System.EventHandler(this.DigitButtonClick);
            // 
            // _productPriceListBox
            // 
            this._productPriceListBox.BackColor = System.Drawing.Color.White;
            this._productPriceListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productPriceListBox.Location = new System.Drawing.Point(0, 53);
            this._productPriceListBox.Name = "_productPriceListBox";
            this._productPriceListBox.Size = new System.Drawing.Size(240, 185);
            this._productPriceListBox.TabIndex = 1;
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
            this._filterPanel.Filter += new MSS.WinMobile.UI.Controls.FilterPanel.OnFilter(this.FilterClick);
            this._filterPanel.Clear += new MSS.WinMobile.UI.Controls.FilterPanel.OnClear(this.ClearFilterClick);
            // 
            // _horizontalLine
            // 
            this._horizontalLine.BackColor = System.Drawing.Color.White;
            this._horizontalLine.Dock = System.Windows.Forms.DockStyle.Top;
            this._horizontalLine.LineColor = System.Drawing.Color.DarkGray;
            this._horizontalLine.Location = new System.Drawing.Point(0, 48);
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
            this._actionPanel.Location = new System.Drawing.Point(0, 24);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 24);
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(29, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(211, 24);
            this.searchPanel.TabIndex = 0;
            this.searchPanel.Clear += new MSS.WinMobile.UI.Controls.SearchPanel.OnClear(this.ClearSearchClick);
            this.searchPanel.Search += new MSS.WinMobile.UI.Controls.SearchPanel.OnSearch(this.SearchClick);
            // 
            // _vericalLine
            // 
            this._vericalLine.BackColor = System.Drawing.Color.White;
            this._vericalLine.Dock = System.Windows.Forms.DockStyle.Left;
            this._vericalLine.LineColor = System.Drawing.Color.DarkGray;
            this._vericalLine.Location = new System.Drawing.Point(24, 0);
            this._vericalLine.Name = "_vericalLine";
            this._vericalLine.Size = new System.Drawing.Size(5, 24);
            this._vericalLine.TabIndex = 1;
            // 
            // _informationButton
            // 
            this._informationButton.BackColor = System.Drawing.Color.Transparent;
            this._informationButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_informationButton.BackgroundImage")));
            this._informationButton.Dock = System.Windows.Forms.DockStyle.Left;
            this._informationButton.Location = new System.Drawing.Point(0, 0);
            this._informationButton.Name = "_informationButton";
            this._informationButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("_informationButton.PressedImage")));
            this._informationButton.Size = new System.Drawing.Size(24, 24);
            this._informationButton.TabIndex = 0;
            this._informationButton.Click += new System.EventHandler(this.InformationButtonClick);
            // 
            // PickUpProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this._productPriceListBox);
            this.Controls.Add(this._horizontalLine);
            this.Controls.Add(this._actionPanel);
            this.Controls.Add(this._filterHeaderPanel);
            this.Controls.Add(this.quantityPanel);
            this.Name = "PickUpProductView";
            this.Text = "CustomerLookUpView";
            this.Load += new System.EventHandler(this.ViewLoad);
            this.quantityPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.unitOfMeasureViewModelBindingSource)).EndInit();
            this._filterHeaderPanel.ResumeLayout(false);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        public PictureButton deleteButton;
        private MSS.WinMobile.UI.Controls.Concret.ProductPriceListBox _productPriceListBox;
        private System.Windows.Forms.Panel _filterHeaderPanel;
        private FilterPanel _filterPanel;
        private HorizontalLine _horizontalLine;
        private System.Windows.Forms.Panel _actionPanel;
        private SearchPanel searchPanel;
        private VericalLine _vericalLine;
        private InformationButton _informationButton;
        private System.Windows.Forms.ComboBox _uomComboBox;
        private System.Windows.Forms.BindingSource unitOfMeasureViewModelBindingSource;

    }
}