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
            this._actionPanel.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _actionPanel
            // 
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
            this.datePicker.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(2, 1);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(238, 22);
            this.datePicker.TabIndex = 1;
            this.datePicker.ValueChanged += new System.EventHandler(this.DatePickerValueChanged);
            // 
            // OrderListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this._orderListBox);
            this.Controls.Add(this.panel);
            this.Controls.Add(this._actionPanel);
            this.Name = "OrderListView";
            this.Size = new System.Drawing.Size(240, 268);
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
    }
}
