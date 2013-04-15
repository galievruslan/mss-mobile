using System;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls
{
    public partial class LookUpBox : UserControl
    {
        private const string DefaultLabel = "- none -";

        public delegate void OnLookUp(LookUpBox sender);
        public delegate void OnReset(LookUpBox sender);

        public event OnLookUp LookUp;
        public event OnReset Reset;

        public LookUpBox()
        {
            InitializeComponent();
            Value = null;
            Label = DefaultLabel;
        }

        private void _lookUpButton_Click(object sender, EventArgs e)
        {
            if (LookUp != null)
                LookUp.Invoke(this);
        }

        public object Value { get; set; }
        public string Label {
            get { return _valueLabel.Text; }
            set {
                _valueLabel.Text = value == string.Empty ? DefaultLabel : value;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (Reset != null)
                Reset.Invoke(this);
        }
    }
}
