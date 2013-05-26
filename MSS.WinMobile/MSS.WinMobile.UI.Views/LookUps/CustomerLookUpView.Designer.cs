using MSS.WinMobile.UI.Controls;

namespace MSS.WinMobile.UI.Views.LookUps
{
    partial class CustomerLookUpView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerLookUpView));
            this.customerListBox = new MSS.WinMobile.UI.Controls.Concret.CustomerListBox();
            this.searchPanel = new MSS.WinMobile.UI.Controls.SearchPanel();
            this._actionPanel = new System.Windows.Forms.Panel();
            this._vericalLine = new MSS.WinMobile.UI.Controls.VericalLine();
            this._informationButton = new MSS.WinMobile.UI.Controls.Buttons.InformationButton();
            this._horizontalLine = new MSS.WinMobile.UI.Controls.HorizontalLine();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerListBox
            // 
            this.customerListBox.BackColor = System.Drawing.Color.White;
            this.customerListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerListBox.Location = new System.Drawing.Point(0, 29);
            this.customerListBox.Name = "customerListBox";
            this.customerListBox.Size = new System.Drawing.Size(240, 265);
            this.customerListBox.TabIndex = 1;
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
            this.searchPanel.Search += new MSS.WinMobile.UI.Controls.SearchPanel.OnSearch(this.DoSearchClick);
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this.searchPanel);
            this._actionPanel.Controls.Add(this._vericalLine);
            this._actionPanel.Controls.Add(this._informationButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._actionPanel.Location = new System.Drawing.Point(0, 0);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 24);
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
            this._informationButton.PressedImage = null;
            this._informationButton.Size = new System.Drawing.Size(24, 24);
            this._informationButton.TabIndex = 0;
            this._informationButton.Click += new System.EventHandler(this.InformationButtonClick);
            // 
            // _horizontalLine
            // 
            this._horizontalLine.BackColor = System.Drawing.Color.White;
            this._horizontalLine.Dock = System.Windows.Forms.DockStyle.Top;
            this._horizontalLine.LineColor = System.Drawing.Color.DarkGray;
            this._horizontalLine.Location = new System.Drawing.Point(0, 24);
            this._horizontalLine.Name = "_horizontalLine";
            this._horizontalLine.Size = new System.Drawing.Size(240, 5);
            this._horizontalLine.TabIndex = 3;
            this._horizontalLine.TabStop = false;
            // 
            // CustomerLookUpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.customerListBox);
            this.Controls.Add(this._horizontalLine);
            this.Controls.Add(this._actionPanel);
            this.Name = "CustomerLookUpView";
            this.Text = "Customers";
            this.Load += new System.EventHandler(this.ViewLoad);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SearchPanel searchPanel;
        private MSS.WinMobile.UI.Controls.Concret.CustomerListBox customerListBox;
        private System.Windows.Forms.Panel _actionPanel;
        private MSS.WinMobile.UI.Controls.Buttons.InformationButton _informationButton;
        private VericalLine _vericalLine;
        private HorizontalLine _horizontalLine;

    }
}