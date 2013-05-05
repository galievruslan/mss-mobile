using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls {
    public class TransparentControl : Control {
        private bool _transparentBackgound = true;

        public bool TransparentBackground {
            get { return _transparentBackgound; }
            set { _transparentBackgound = value; }
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            if (_transparentBackgound) {
                var parent = Parent as IPaintControl;
                if (parent != null) {
                    parent.InvokePaintBackground(e);
                }
            }
            else base.OnPaintBackground(e);
        }
    }
}