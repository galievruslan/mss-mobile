using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.Localization;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Panels {
    public class ProductPickUpExtraPanel : UserControl {
        private Lines.VericalLine _vericalLine;
        private Label _amountLabel;
        private Label _amountValueLable;
        private BindingSource _unitOfMeasureViewModelBindingSource;
        private System.ComponentModel.IContainer components;
        private ComboBox _uomComboBox;

        public ProductPickUpExtraPanel() {
            InitializeComponent();
        }

        private ILocalizationManager _localizationManager;
        public ILocalizationManager LocalizationManager {
            private get { return _localizationManager; }
            set {
                _localizationManager = value;
                _amountLabel.Text = _localizationManager.Localization.GetLocalizedValue(_amountLabel.Text);
            }
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this._unitOfMeasureViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._uomComboBox = new System.Windows.Forms.ComboBox();
            this._vericalLine = new MSS.WinMobile.UI.Controls.Lines.VericalLine();
            this._amountLabel = new System.Windows.Forms.Label();
            this._amountValueLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._unitOfMeasureViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _unitOfMeasureViewModelBindingSource
            // 
            this._unitOfMeasureViewModelBindingSource.DataSource = typeof(MSS.WinMobile.UI.Presenters.ViewModels.UnitOfMeasureViewModel);
            // 
            // _uomComboBox
            // 
            this._uomComboBox.DataSource = this._unitOfMeasureViewModelBindingSource;
            this._uomComboBox.DisplayMember = "Name";
            this._uomComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this._uomComboBox.Location = new System.Drawing.Point(0, 0);
            this._uomComboBox.Name = "_uomComboBox";
            this._uomComboBox.Size = new System.Drawing.Size(112, 22);
            this._uomComboBox.TabIndex = 0;
            this._uomComboBox.ValueMember = "Id";
            this._uomComboBox.SelectedValueChanged += new System.EventHandler(this.UomComboBoxSelectedValueChanged);
            // 
            // _vericalLine
            // 
            this._vericalLine.BackColor = System.Drawing.Color.White;
            this._vericalLine.Dock = System.Windows.Forms.DockStyle.Left;
            this._vericalLine.LineColor = System.Drawing.Color.DarkGray;
            this._vericalLine.Location = new System.Drawing.Point(112, 0);
            this._vericalLine.Name = "_vericalLine";
            this._vericalLine.Size = new System.Drawing.Size(5, 22);
            this._vericalLine.TabIndex = 9;
            // 
            // _amountLabel
            // 
            this._amountLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this._amountLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._amountLabel.Location = new System.Drawing.Point(117, 0);
            this._amountLabel.Name = "_amountLabel";
            this._amountLabel.Size = new System.Drawing.Size(52, 22);
            this._amountLabel.Text = "Amount";
            // 
            // _amountValueLable
            // 
            this._amountValueLable.Dock = System.Windows.Forms.DockStyle.Left;
            this._amountValueLable.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._amountValueLable.Location = new System.Drawing.Point(169, 0);
            this._amountValueLable.Name = "_amountValueLable";
            this._amountValueLable.Size = new System.Drawing.Size(56, 22);
            this._amountValueLable.Text = "0";
            this._amountValueLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ProductPickUpExtraPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._amountValueLable);
            this.Controls.Add(this._amountLabel);
            this.Controls.Add(this._vericalLine);
            this.Controls.Add(this._uomComboBox);
            this.Name = "ProductPickUpExtraPanel";
            this.Size = new System.Drawing.Size(225, 22);
            ((System.ComponentModel.ISupportInitialize)(this._unitOfMeasureViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        public void SetUnitsOfMeasures(IEnumerable<UnitOfMeasureViewModel> unitsOfMeasures) {
            _uomComboBox.SelectedValueChanged -= UomComboBoxSelectedValueChanged;
            _uomComboBox.DataSource = unitsOfMeasures;
            _uomComboBox.SelectedValueChanged += UomComboBoxSelectedValueChanged;
        }

        public void SetSelectedUnitOfMeasure(int id) {
            _uomComboBox.SelectedValueChanged -= UomComboBoxSelectedValueChanged;
            _uomComboBox.SelectedValue = id;
            _uomComboBox.SelectedValueChanged += UomComboBoxSelectedValueChanged;
        }

        public void SetAmount(decimal value) {
            _amountValueLable.Text =
                value.ToString(_localizationManager.Localization.GetLocalizedValue("decimalformat"));
        }

        public delegate void OnUnitOfMeasureChanged(UnitOfMeasureViewModel unitOfMeasureViewModel);

        public event OnUnitOfMeasureChanged UnitOfMeasureChanged;

        private void UomComboBoxSelectedValueChanged(object sender, EventArgs e) {
            if (UnitOfMeasureChanged != null)
                UnitOfMeasureChanged.Invoke((UnitOfMeasureViewModel)_uomComboBox.SelectedItem);
        }
    }
}
