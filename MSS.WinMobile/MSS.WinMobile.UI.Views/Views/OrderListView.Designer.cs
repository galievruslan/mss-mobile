namespace MSS.WinMobile.UI.Views.Views {
    partial class OrderListView
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderListView));
            this._actionPanel = new System.Windows.Forms.Panel();
            this._editOrderButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this._orderListBox = new MSS.WinMobile.UI.Controls.Concret.OrderListBox();
            this.panel = new System.Windows.Forms.Panel();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.vericalLine1 = new MSS.WinMobile.UI.Controls.VericalLine();
            this._amountLabel = new System.Windows.Forms.Label();
            this._amountValueLable = new System.Windows.Forms.Label();
            this._actionPanel.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _actionPanel
            // 
            this._actionPanel.Controls.Add(this.vericalLine1);
            this._actionPanel.Controls.Add(this._amountLabel);
            this._actionPanel.Controls.Add(this._amountValueLable);
            this._actionPanel.Controls.Add(this._editOrderButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._actionPanel.Location = new System.Drawing.Point(0, 0);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(240, 24);
            // 
            // _editOrderButton
            // 
            this._editOrderButton.BackColor = System.Drawing.Color.White;
            this._editOrderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_editOrderButton.BackgroundImage")));
            this._editOrderButton.Location = new System.Drawing.Point(2, 2);
            this._editOrderButton.Name = "_editOrderButton";
            this._editOrderButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("_editOrderButton.PressedImage")));
            this._editOrderButton.Size = new System.Drawing.Size(20, 20);
            this._editOrderButton.TabIndex = 1;
            this._editOrderButton.Click += new System.EventHandler(this.EditOrderClick);
            // 
            // _orderListBox
            // 
            this._orderListBox.BackColor = System.Drawing.Color.White;
            this._orderListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._orderListBox.Location = new System.Drawing.Point(0, 48);
            this._orderListBox.Name = "_orderListBox";
            this._orderListBox.Size = new System.Drawing.Size(240, 220);
            this._orderListBox.TabIndex = 4;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.datePicker);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 24);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(240, 24);
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "dd.MM.yyyy";
            this.datePicker.Dock = System.Windows.Forms.DockStyle.Top;
            this.datePicker.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(0, 0);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(240, 22);
            this.datePicker.TabIndex = 1;
            this.datePicker.ValueChanged += new System.EventHandler(this.DatePickerValueChanged);
            // 
            // vericalLine1
            // 
            this.vericalLine1.BackColor = System.Drawing.Color.White;
            this.vericalLine1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vericalLine1.LineColor = System.Drawing.Color.DarkGray;
            this.vericalLine1.Location = new System.Drawing.Point(111, 0);
            this.vericalLine1.Name = "vericalLine1";
            this.vericalLine1.Size = new System.Drawing.Size(5, 24);
            this.vericalLine1.TabIndex = 6;
            // 
            // _amountLabel
            // 
            this._amountLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this._amountLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._amountLabel.Location = new System.Drawing.Point(116, 0);
            this._amountLabel.Name = "_amountLabel";
            this._amountLabel.Size = new System.Drawing.Size(52, 24);
            this._amountLabel.Text = "Amount";
            // 
            // _amountValueLable
            // 
            this._amountValueLable.Dock = System.Windows.Forms.DockStyle.Right;
            this._amountValueLable.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._amountValueLable.Location = new System.Drawing.Point(168, 0);
            this._amountValueLable.Name = "_amountValueLable";
            this._amountValueLable.Size = new System.Drawing.Size(72, 24);
            this._amountValueLable.Text = "0";
            this._amountValueLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // OrderListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this._orderListBox);
            this.Controls.Add(this.panel);
            this.Controls.Add(this._actionPanel);
            this.Name = "OrderListView";
            this.Load += new MSS.WinMobile.UI.Views.Views.View.OnLoad(this.OrderListViewLoad);
            this._actionPanel.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _actionPanel;
        private MSS.WinMobile.UI.Controls.Buttons.PictureButton _editOrderButton;
        private MSS.WinMobile.UI.Controls.Concret.OrderListBox _orderListBox;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DateTimePicker datePicker;
        private MSS.WinMobile.UI.Controls.VericalLine vericalLine1;
        private System.Windows.Forms.Label _amountLabel;
        private System.Windows.Forms.Label _amountValueLable;
    }
}
