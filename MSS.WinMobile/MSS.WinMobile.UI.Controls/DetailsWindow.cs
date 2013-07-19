using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.WindowsMobile.Status;

namespace MSS.WinMobile.UI.Controls {
    public class DetailsWindow : Form {
        private readonly SystemState _displayRotationState =
            new SystemState(SystemProperty.DisplayRotation);
        private Label _textLabel;

        private bool _centered = true;

        #region Native Platform Invoke

        [DllImport("coredll.dll")]
        private static extern UInt32 SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);

        [DllImport("aygshell.dll")]
        private static extern int SHDoneButton(IntPtr hwndRequester, UInt32 dwState);

        private const int GwlStyle = (-16);

        private const UInt32 WsCaption = 0x00C00000; /* WS_BORDER | WS_DLGFRAME  */
        private const UInt32 WsBorder = 0x00800000;
        private const UInt32 WsPopup = 0x80000000;

        private const UInt32 ShdbShow = 0x0001;
        private const UInt32 ShdbHide = 0x0002;

        #endregion

        public DetailsWindow() {
            InitializeComponent();
            _displayRotationState.Changed += displayRotationState_Changed;
        }

        public DetailsWindow(string text) :this() {
            _textLabel.Text = text;
        }

        public bool CenterFormOnScreen {
            get { return _centered; }
            set {
                _centered = value;

                if (_centered) {
                    CenterWithinScreen();
                }
            }
        }

        protected override void OnLoad(EventArgs e) {
            // By default if you set a form's size within
            // the Visual Studio form designer it won't
            // take into account the additional height of
            // the caption, so we'll add that height here...
            Height += SystemInformation.MenuHeight;

            base.OnLoad(e);

            // Add the border and caption we removed from the form
            // when we set the Form's FormBorderStyle property to None.
            // We do this at the Win32 API level, which causes the .NET
            // Compact Framework wrapper to get out of sync.
            const uint style = WsBorder | WsCaption | WsPopup;
            SetWindowLong(Handle, GwlStyle, style);

            // Add/Remove an [OK] button from the dialog's
            // caption bar as required
            SHDoneButton(Handle, ControlBox ? ShdbShow : ShdbHide);

            // Center the form if requested
            if (_centered) {
                CenterWithinScreen();
            }
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);

            // If the dialog changes size and we want to be
            // centered we may need to move the dialog to
            // keep it centered.
            if (_centered) {
                CenterWithinScreen();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e) {
            base.OnKeyDown(e);

            // If we have an [OK] button in the caption pressing
            // Return or Escape should close the dialog
            if (ControlBox) {
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Escape) {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void displayRotationState_Changed(object sender, ChangeEventArgs args) {
            // If the orientation has changed and the CenterFormOnScreen
            // property is set re-center the form
            if (_centered) {
                CenterWithinScreen();
            }
        }

        private void CenterWithinScreen() {
            // Move the position of this form to center it within the
            // working area of the desktop
            int x = (Screen.PrimaryScreen.WorkingArea.Width - Width)/2;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - Height)/2;

            Location = new Point(x, y);
        }

        private void InitializeComponent() {
            this._textLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _textLabel
            // 
            this._textLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular);
            this._textLabel.Location = new System.Drawing.Point(0, 0);
            this._textLabel.Name = "_textLabel";
            this._textLabel.Size = new System.Drawing.Size(180, 146);
            this._textLabel.Text = "Some details";
            // 
            // DetailsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(180, 146);
            this.Controls.Add(this._textLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DetailsWindow";
            this.Text = "details";
            this.ResumeLayout(false);

        }
    }
}
