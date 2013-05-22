using System;
using System.Windows.Forms;
using System.Drawing;

namespace MSS.WinMobile.UI.Controls {
    public class TextBoxWithPrompt : TextBox {
        // originated at http://danielmoth.com/Blog
        protected override void OnGotFocus(EventArgs e) {
            base.OnGotFocus(e);
            if (UsePrompt) {
                UsePrompt = false;
                Text = string.Empty;
            }
        }

        protected override void OnLostFocus(EventArgs e) {
            if (TextLength == 0 || Text == TextPrompt) {
                UsePrompt = true;
                Text = TextPrompt;
            }
            base.OnLostFocus(e);
        }

        private string _textPrompt = "enter a moth";

        public string TextPrompt {
            get { return _textPrompt; }
            set {
                _textPrompt = value;
                if (UsePrompt && !string.IsNullOrEmpty(_textPrompt)) {
                    Text = value;
                }
            }
        }

        private bool _usePrompt;

        private bool UsePrompt {
            get { return _usePrompt; }
            set {
                _usePrompt = value;
                if (_usePrompt) {
                    Font = new Font(Font.Name, Font.Size, FontStyle.Italic);
                    ForeColor = Color.Gray;
                }
                else {
                    // TODO don't hardcode the user given values.
                    Font = new Font(Font.Name, Font.Size, FontStyle.Regular);
                    ForeColor = Color.Black;
                }
            }
        }

        protected override void OnParentChanged(EventArgs e) {
            if (string.IsNullOrEmpty(Text)) {
                UsePrompt = true;
                Text = TextPrompt;
            }
            base.OnParentChanged(e);
        }

        public override string Text {
            get {
                if (UsePrompt) {
                    return string.Empty;
                }
                return base.Text;
            }
            set {
                if (UsePrompt && (!string.IsNullOrEmpty(value) && value != TextPrompt)) {
                    UsePrompt = false;
                }

                if (string.IsNullOrEmpty(value) && !Focused &&
                    !string.IsNullOrEmpty(_textPrompt)) {
                    UsePrompt = true;
                    Text = TextPrompt;
                    return;
                }

                base.Text = value;
            }
        }
    }
}