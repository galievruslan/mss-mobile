using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls
{
    public partial class LookUpBox : UserControl
    {
        public delegate void OnLookUp(LookUpBox sender);
        public delegate void OnReset(LookUpBox sender);

        public event OnLookUp LookUp;
        public event OnReset Reset;

        public LookUpBox()
        {
            InitializeComponent();
        }

        private void LookUpButtonClick(object sender, EventArgs e)
        {
            if (LookUp != null)
                LookUp.Invoke(this);
        }

        public override string Text {
            get { return _valueLabel.Text; }
            set { _valueLabel.Text = value; }
        }

        private void ResetButtonClick(object sender, EventArgs e)
        {
            if (Reset != null)
                Reset.Invoke(this);
        }
    }
}
