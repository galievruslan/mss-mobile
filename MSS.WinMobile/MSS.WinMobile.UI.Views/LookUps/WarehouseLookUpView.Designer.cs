﻿using MSS.WinMobile.UI.Controls;
using MSS.WinMobile.UI.Controls.Lines;
using MSS.WinMobile.UI.Controls.Panels;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarehouseLookUpView));
            this._warehouseListBox = new MSS.WinMobile.UI.Controls.Concret.WarehouseListBox();
            this._horizontalLine = new HorizontalLine();
            this._actionPanel = new System.Windows.Forms.Panel();
            this.searchPanel = new SearchPanel();
            this._vericalLine = new VericalLine();
            this._informationButton = new MSS.WinMobile.UI.Controls.Buttons.InformationButton();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _warehouseListBox
            // 
            this._warehouseListBox.BackColor = System.Drawing.Color.White;
            this._warehouseListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._warehouseListBox.Location = new System.Drawing.Point(0, 29);
            this._warehouseListBox.Name = "_warehouseListBox";
            this._warehouseListBox.Size = new System.Drawing.Size(240, 239);
            this._warehouseListBox.TabIndex = 1;
            // 
            // _horizontalLine
            // 
            this._horizontalLine.BackColor = System.Drawing.Color.White;
            this._horizontalLine.Dock = System.Windows.Forms.DockStyle.Top;
            this._horizontalLine.LineColor = System.Drawing.Color.DarkGray;
            this._horizontalLine.Location = new System.Drawing.Point(0, 24);
            this._horizontalLine.Name = "_horizontalLine";
            this._horizontalLine.Size = new System.Drawing.Size(240, 5);
            this._horizontalLine.TabIndex = 5;
            this._horizontalLine.TabStop = false;
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
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(29, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(211, 24);
            this.searchPanel.TabIndex = 0;
            this.searchPanel.Search += new SearchPanel.OnSearch(this.DoSearchClick);
            this.searchPanel.Clear += new SearchPanel.OnClear(this.ClearSearchClick);
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
            this._informationButton.Size = new System.Drawing.Size(24, 24);
            this._informationButton.TabIndex = 0;
            this._informationButton.Click += new System.EventHandler(this.InformationButtonClick);
            // 
            // WarehouseLookUpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this._warehouseListBox);
            this.Controls.Add(this._horizontalLine);
            this.Controls.Add(this._actionPanel);
            this.Name = "WarehouseLookUpView";
            this.Text = "Warehouses";
            this.Load += new System.EventHandler(this.ViewLoad);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MSS.WinMobile.UI.Controls.Concret.WarehouseListBox _warehouseListBox;
        private HorizontalLine _horizontalLine;
        private System.Windows.Forms.Panel _actionPanel;
        private SearchPanel searchPanel;
        private VericalLine _vericalLine;
        private MSS.WinMobile.UI.Controls.Buttons.InformationButton _informationButton;

    }
}