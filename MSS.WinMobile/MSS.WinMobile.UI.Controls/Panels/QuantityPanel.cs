using System;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls.Panels {
    public class QuantityPanel : UserControl {
        private Buttons.PictureButton _deleteButton;
        private Button _nilButton;
        private Button _nineButton;
        private Button _eightButton;
        private Button _sevenButton;
        private Button _sixButton;
        private Button _fiveButton;
        private Button _fourButton;
        private Button _threeButton;
        private Button _twoButton;
        private Button _oneButton;

        public QuantityPanel() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuantityPanel));
            this._nilButton = new System.Windows.Forms.Button();
            this._nineButton = new System.Windows.Forms.Button();
            this._eightButton = new System.Windows.Forms.Button();
            this._sevenButton = new System.Windows.Forms.Button();
            this._sixButton = new System.Windows.Forms.Button();
            this._fiveButton = new System.Windows.Forms.Button();
            this._fourButton = new System.Windows.Forms.Button();
            this._threeButton = new System.Windows.Forms.Button();
            this._twoButton = new System.Windows.Forms.Button();
            this._oneButton = new System.Windows.Forms.Button();
            this._deleteButton = new MSS.WinMobile.UI.Controls.Buttons.PictureButton();
            this.SuspendLayout();
            // 
            // _nilButton
            // 
            this._nilButton.BackColor = System.Drawing.Color.White;
            this._nilButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._nilButton.Location = new System.Drawing.Point(181, 1);
            this._nilButton.Name = "_nilButton";
            this._nilButton.Size = new System.Drawing.Size(19, 20);
            this._nilButton.TabIndex = 20;
            this._nilButton.Text = "0";
            this._nilButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // _nineButton
            // 
            this._nineButton.BackColor = System.Drawing.Color.White;
            this._nineButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._nineButton.Location = new System.Drawing.Point(161, 1);
            this._nineButton.Name = "_nineButton";
            this._nineButton.Size = new System.Drawing.Size(19, 20);
            this._nineButton.TabIndex = 19;
            this._nineButton.Text = "9";
            this._nineButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // _eightButton
            // 
            this._eightButton.BackColor = System.Drawing.Color.White;
            this._eightButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._eightButton.Location = new System.Drawing.Point(141, 1);
            this._eightButton.Name = "_eightButton";
            this._eightButton.Size = new System.Drawing.Size(19, 20);
            this._eightButton.TabIndex = 18;
            this._eightButton.Text = "8";
            this._eightButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // _sevenButton
            // 
            this._sevenButton.BackColor = System.Drawing.Color.White;
            this._sevenButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._sevenButton.Location = new System.Drawing.Point(121, 1);
            this._sevenButton.Name = "_sevenButton";
            this._sevenButton.Size = new System.Drawing.Size(19, 20);
            this._sevenButton.TabIndex = 17;
            this._sevenButton.Text = "7";
            this._sevenButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // _sixButton
            // 
            this._sixButton.BackColor = System.Drawing.Color.White;
            this._sixButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._sixButton.Location = new System.Drawing.Point(101, 1);
            this._sixButton.Name = "_sixButton";
            this._sixButton.Size = new System.Drawing.Size(19, 20);
            this._sixButton.TabIndex = 16;
            this._sixButton.Text = "6";
            this._sixButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // _fiveButton
            // 
            this._fiveButton.BackColor = System.Drawing.Color.White;
            this._fiveButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._fiveButton.Location = new System.Drawing.Point(81, 1);
            this._fiveButton.Name = "_fiveButton";
            this._fiveButton.Size = new System.Drawing.Size(19, 20);
            this._fiveButton.TabIndex = 15;
            this._fiveButton.Text = "5";
            this._fiveButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // _fourButton
            // 
            this._fourButton.BackColor = System.Drawing.Color.White;
            this._fourButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._fourButton.Location = new System.Drawing.Point(61, 1);
            this._fourButton.Name = "_fourButton";
            this._fourButton.Size = new System.Drawing.Size(19, 20);
            this._fourButton.TabIndex = 14;
            this._fourButton.Text = "4";
            this._fourButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // _threeButton
            // 
            this._threeButton.BackColor = System.Drawing.Color.White;
            this._threeButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._threeButton.Location = new System.Drawing.Point(41, 1);
            this._threeButton.Name = "_threeButton";
            this._threeButton.Size = new System.Drawing.Size(19, 20);
            this._threeButton.TabIndex = 13;
            this._threeButton.Text = "3";
            this._threeButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // _twoButton
            // 
            this._twoButton.BackColor = System.Drawing.Color.White;
            this._twoButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._twoButton.Location = new System.Drawing.Point(21, 1);
            this._twoButton.Name = "_twoButton";
            this._twoButton.Size = new System.Drawing.Size(19, 20);
            this._twoButton.TabIndex = 12;
            this._twoButton.Text = "2";
            this._twoButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // _oneButton
            // 
            this._oneButton.BackColor = System.Drawing.Color.White;
            this._oneButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._oneButton.Location = new System.Drawing.Point(1, 1);
            this._oneButton.Name = "_oneButton";
            this._oneButton.Size = new System.Drawing.Size(19, 20);
            this._oneButton.TabIndex = 11;
            this._oneButton.Text = "1";
            this._oneButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // _deleteButton
            // 
            this._deleteButton.BackColor = System.Drawing.Color.White;
            this._deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_deleteButton.BackgroundImage")));
            this._deleteButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._deleteButton.Location = new System.Drawing.Point(201, 1);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("_deleteButton.PressedImage")));
            this._deleteButton.Size = new System.Drawing.Size(20, 20);
            this._deleteButton.TabIndex = 21;
            this._deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // QuantityPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._deleteButton);
            this.Controls.Add(this._nilButton);
            this.Controls.Add(this._nineButton);
            this.Controls.Add(this._eightButton);
            this.Controls.Add(this._sevenButton);
            this.Controls.Add(this._sixButton);
            this.Controls.Add(this._fiveButton);
            this.Controls.Add(this._fourButton);
            this.Controls.Add(this._threeButton);
            this.Controls.Add(this._twoButton);
            this.Controls.Add(this._oneButton);
            this.Name = "QuantityPanel";
            this.Size = new System.Drawing.Size(228, 22);
            this.ResumeLayout(false);

        }

        public delegate void OnDigitAdd(int value);
        public delegate void OnDigitRemove();

        public event OnDigitAdd DigitAdd;
        public event OnDigitRemove DigitRemove;

        private void oneButton_Click(object sender, EventArgs e) {
            var digitButton = sender as Button;
            if (digitButton != null) {
                if (DigitAdd != null)
                    DigitAdd.Invoke(Int32.Parse(digitButton.Text));
            }
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            if (DigitRemove != null)
                DigitRemove.Invoke();
        }
    }
}
