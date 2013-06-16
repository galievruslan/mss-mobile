using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls {
    public partial class CustomRadioButton : UserControl {
        public delegate void OnChecked(object sender);
        public event OnChecked CheckedEvent;

        public CustomRadioButton() {
            InitializeComponent();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e) {
            if (CheckedEvent != null && radioButton.Checked)
                CheckedEvent.Invoke(this);
        }

        public void UnCheck() {
            radioButton.Checked = false;
        }

        public bool Checked {
            get { return radioButton.Checked; }
            set { radioButton.Checked = value; }
        }

        new public string Text {
            get { return radioButton.Text; }
            set { radioButton.Text = value; }
        }
    }
}
