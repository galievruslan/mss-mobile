using System;

using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls {
    public class WndProcHooker {

        // The WndProcCallback method is used when a hooked
        // window's message map contains the hooked message.
        // Parameters:
        // hwnd - The handle to the window for which the message
        // was received.
        // wParam - The message's parameters (part 1).
        // lParam - The message's parameters (part 2).
        // handled - The invoked function sets this to true if it
        // handled the message. If the value is false when the callback
        // returns, the next window procedure in the wndproc chain is
        // called.
        //
        // Returns a value specified for the given message.
        public delegate int WndProcCallback(
            IntPtr hwnd, uint msg, uint wParam, int lParam, ref bool handled);

        // This is the global list of all the window procedures we have
        // hooked. The key is an hwnd. The value is a HookedProcInformation
        // object which contains a pointer to the old wndproc and a map of
        // message's callbacks for the window specified. Controls whose handles
        // have been created go into this dictionary.
        private static Dictionary<IntPtr, HookedProcInformation> hwndDict =
            new Dictionary<IntPtr, HookedProcInformation>();

        // The key for this dictionary is a control and the value is a
        // HookedProcInformation. Controls whose handles have not been created
        // go into this dictionary. When the HandleCreated event for the
        // control is fired the control is moved into hwndDict.
        private static Dictionary<Control, HookedProcInformation> ctlDict =
            new Dictionary<Control, HookedProcInformation>();

        // Makes a connection between a message on a specified window handle
        // and the callback to be called when that message is received. If the
        // window was not previously hooked it is added to the global list of
        // all the window procedures hooked.
        // Parameters:
        // ctl - The control whose wndproc we are hooking.
        // callback - The method to call when the specified.
        // message is received for the specified window.
        // msg - The message being hooked.
        public static void HookWndProc(
            Control ctl, WndProcCallback callback, uint msg) {
            HookedProcInformation hpi = null;
            if (ctlDict.ContainsKey(ctl))
                hpi = ctlDict[ctl];
            else if (hwndDict.ContainsKey(ctl.Handle))
                hpi = hwndDict[ctl.Handle];
            if (hpi == null) {
                // If new control, create a new
                // HookedProcInformation for it.
                hpi = new HookedProcInformation(ctl,
                    new Win32.WndProc(WndProcHooker.WindowProc));
                ctl.HandleCreated += new EventHandler(ctl_HandleCreated);
                ctl.HandleDestroyed += new EventHandler(ctl_HandleDestroyed);
                ctl.Disposed += new EventHandler(ctl_Disposed);

                // If the handle has already been created set the hook. If it
                // hasn't been created yet, the hook will get set in the
                // ctl_HandleCreated event handler.
                if (ctl.Handle != IntPtr.Zero)
                    hpi.SetHook();
            }

            // Stick hpi into the correct dictionary.
            if (ctl.Handle == IntPtr.Zero)
                ctlDict[ctl] = hpi;
            else
                hwndDict[ctl.Handle] = hpi;

            // Add the message/callback into the message map.
            hpi.messageMap[msg] = callback;
        }

        // The event handler called when a control is disposed.
        static void ctl_Disposed(object sender, EventArgs e) {
            Control ctl = sender as Control;
            if (ctlDict.ContainsKey(ctl))
                ctlDict.Remove(ctl);
            else
                System.Diagnostics.Debug.Assert(false);
        }

        // The event handler called when a control's handle is destroyed.
        // We remove the HookedProcInformation from hwndDict and
        // put it back into ctlDict in case the control get re-
        // created and we still want to hook its messages.
        static void ctl_HandleDestroyed(object sender, EventArgs e) {
            // When the handle for a control is destroyed, we want to
            // unhook its wndproc and update our lists
            Control ctl = sender as Control;
            if (hwndDict.ContainsKey(ctl.Handle)) {
                HookedProcInformation hpi = hwndDict[ctl.Handle];
                UnhookWndProc(ctl, false);
            }
            else
                System.Diagnostics.Debug.Assert(false);
        }

        // The event handler called when a control's handle is created. We
        // call SetHook() on the associated HookedProcInformation object and
        // move it from ctlDict to hwndDict.
        static void ctl_HandleCreated(object sender, EventArgs e) {
            Control ctl = sender as Control;
            if (ctlDict.ContainsKey(ctl)) {
                HookedProcInformation hpi = ctlDict[ctl];
                hwndDict[ctl.Handle] = hpi;
                ctlDict.Remove(ctl);
                hpi.SetHook();
            }
            else
                System.Diagnostics.Debug.Assert(false);
        }

        // This is a generic wndproc. It is the callback for all hooked
        // windows. If we get into this function, we look up the hwnd in the
        // global list of all hooked windows to get its message map. If the
        // message received is present in the message map, its callback is
        // invoked with the parameters listed here.
        // Parameters:
        // hwnd - The handle to the window that received the
        // message
        // msg - The message
        // wParam - The message's parameters (part 1)
        // lParam - The messages's parameters (part 2)
        // Returns the callback handled the message, the callback's return
        // value is returned form this function. If the callback didn't handle
        // the message, the message is forwarded on to the previous wndproc.
        private static int WindowProc(
            IntPtr hwnd, uint msg, uint wParam, int lParam) {
            if (hwndDict.ContainsKey(hwnd)) {
                HookedProcInformation hpi = hwndDict[hwnd];
                if (hpi.messageMap.ContainsKey(msg)) {
                    WndProcCallback callback = hpi.messageMap[msg];
                    bool handled = false;
                    int retval = callback(hwnd, msg, wParam, lParam, ref handled);
                    if (handled)
                        return retval;
                }

                // If the callback didn't set the handled property to true,
                // call the original window procedure.
                return hpi.CallOldWindowProc(hwnd, msg, wParam, lParam);
            }
            System.Diagnostics.Debug.Assert(
                false, "WindowProc called for hwnd we don't know about");
            return Win32.DefWindowProc(hwnd, msg, wParam, lParam);
        }

        // This method removes the specified message from the message map for
        // the specified hwnd.
        public static void UnhookWndProc(Control ctl, uint msg) {
            // Look for the HookedProcInformation in the
            // ctrDict and hwndDict dictionaries.
            HookedProcInformation hpi = null;
            if (ctlDict.ContainsKey(ctl))
                hpi = ctlDict[ctl];
            else if (hwndDict.ContainsKey(ctl.Handle))
                hpi = hwndDict[ctl.Handle];
            // if we couldn't find a HookedProcInformation, throw
            if (hpi == null)
                throw new ArgumentException("No hook exists for this control");

            // look for the message we are removing in the messageMap
            if (hpi.messageMap.ContainsKey(msg))
                hpi.messageMap.Remove(msg);
            else
                // if we couldn't find the message, throw
                throw new ArgumentException(
                    string.Format(
                    "No hook exists for message ({0}) on this control",
                    msg));
        }

        // Restores the previous wndproc for the specified window.
        // Parameters:
        // ctl - The control whose wndproc we no longer want to hook.
        // disposing - True if HookedProcInformation is not
        //   read back into ctlDict.
        public static void UnhookWndProc(Control ctl, bool disposing) {
            HookedProcInformation hpi = null;
            if (ctlDict.ContainsKey(ctl))
                hpi = ctlDict[ctl];
            else if (hwndDict.ContainsKey(ctl.Handle))
                hpi = hwndDict[ctl.Handle];
            if (hpi == null)
                throw new ArgumentException("No hook exists for this control");

            // If we found our HookedProcInformation in ctlDict and we are
            // disposing remove it from ctlDict.
            if (ctlDict.ContainsKey(ctl) && disposing)
                ctlDict.Remove(ctl);

            // If we found our HookedProcInformation in hwndDict, remove it
            // and if we are not disposing stick it in ctlDict.
            if (hwndDict.ContainsKey(ctl.Handle)) {
                hpi.Unhook();
                hwndDict.Remove(ctl.Handle);
                if (!disposing)
                    ctlDict[ctl] = hpi;
            }
        }

        // This class remembers the old window procedure for the specified
        // window handle and also provides the message map for the messages
        // hooked on that window.
        class HookedProcInformation {

            // The message map for the window.
            public Dictionary<uint, WndProcCallback> messageMap;

            // The old window procedure for the window.
            private IntPtr oldWndProc;

            // The delegate that gets called in place of this window's
            // wndproc.
            private Win32.WndProc newWndProc;

            // Control whose wndproc is being hooked.
            private Control control;

            // Constructs a new HookedProcInformation object
            // Parameters:
            // ctl - The handle to the window being hooked
            // wndproc - The window procedure to replace the
            // original one for the control.
            public HookedProcInformation(Control ctl, Win32.WndProc wndproc) {
                control = ctl;
                newWndProc = wndproc;
                messageMap = new Dictionary<uint, WndProcCallback>();
            }

            // Replaces the windows procedure for control with the
            // one specified in the constructor.
            public void SetHook() {
                IntPtr hwnd = control.Handle;
                if (hwnd == IntPtr.Zero)
                    throw new InvalidOperationException(
                        "Handle for control has not been created");

                oldWndProc = Win32.SetWindowLong(hwnd, Win32.GWL_WNDPROC,
                    Marshal.GetFunctionPointerForDelegate(newWndProc));
            }

            // Restores the original window procedure for the control.
            public void Unhook() {
                IntPtr hwnd = control.Handle;
                if (hwnd == IntPtr.Zero)
                    throw new InvalidOperationException(
                        "Handle for control has not been created");

                Win32.SetWindowLong(hwnd, Win32.GWL_WNDPROC, oldWndProc);
            }

            // Calls the original window procedure of the control with the
            // arguments provided.
            // Parameters:
            // hwnd - The handle of the window that received the
            // message
            // msg - The message
            // wParam - The message's arguments (part 1)
            // lParam - The message's arguments (part 2)
            // Returns the value returned by the control's original wndproc.
            public int CallOldWindowProc(
                IntPtr hwnd, uint msg, uint wParam, int lParam) {
                return Win32.CallWindowProc(
                    oldWndProc, hwnd, msg, wParam, lParam);
            }
        }
    }

    public sealed class Win32 {
        public struct TRIVERTEX {
            public int x;
            public int y;
            public ushort Red;
            public ushort Green;
            public ushort Blue;
            public ushort Alpha;
            public TRIVERTEX(int x, int y, Color color)
                : this(x, y, color.R, color.G, color.B, color.A) {
            }
            public TRIVERTEX(
                int x, int y,
                ushort red, ushort green, ushort blue,
                ushort alpha) {
                this.x = x;
                this.y = y;
                this.Red = (ushort)(red << 8);
                this.Green = (ushort)(green << 8);
                this.Blue = (ushort)(blue << 8);
                this.Alpha = (ushort)(alpha << 8);
            }
        }
        public struct GRADIENT_RECT {
            public uint UpperLeft;
            public uint LowerRight;
            public GRADIENT_RECT(uint ul, uint lr) {
                this.UpperLeft = ul;
                this.LowerRight = lr;
            }
        }
        public struct GRADIENT_TRIANGLE {
            public uint Vertex1;
            public uint Vertex2;
            public uint Vertex3;
            public GRADIENT_TRIANGLE(uint v1, uint v2, uint v3) {
                this.Vertex1 = v1;
                this.Vertex2 = v2;
                this.Vertex3 = v3;
            }
        }

        // WM_NOTIFY notification message header.
        [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
        public class NMHDR {
            private IntPtr hwndFrom;
            public uint idFrom;
            public uint code;
        }

        //[System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
        public struct TVITEM {
            public int mask;
            private IntPtr hItem;
            public int state;
            public int stateMask;
            private IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            private IntPtr lParam;
        }

        // Native representation of a point.
        public struct POINT {
            public int X;
            public int Y;
        }

        public struct TVHITTESTINFO {
            public POINT pt;
            public uint flags;
            public IntPtr hItem;
        }

        // A callback to a Win32 window procedure (wndproc):
        // Parameters:
        //   hwnd - The handle of the window receiving a message.
        //   msg - The message
        //   wParam - The message's parameters (part 1).
        //   lParam - The message's parameters (part 2).
        //  Returns an integer as described for the given message in MSDN.
        public delegate int WndProc(IntPtr hwnd, uint msg, uint wParam, int lParam);

        [DllImport("coredll.dll", SetLastError = true, EntryPoint = "GradientFill")]
        public extern static bool GradientFill(
            IntPtr hdc,
            TRIVERTEX[] pVertex,
            uint dwNumVertex,
            GRADIENT_RECT[] pMesh,
            uint dwNumMesh,
            uint dwMode);

        public const int GRADIENT_FILL_RECT_H = 0x00000000;
        public const int GRADIENT_FILL_RECT_V = 0x00000001;

        // Not supported on Windows CE:
        public const int GRADIENT_FILL_TRIANGLE = 0x00000002;


        [DllImport("coredll.dll")]
        public extern static IntPtr SetWindowLong(
            IntPtr hwnd, int nIndex, IntPtr dwNewLong);
        public const int GWL_WNDPROC = -4;

        [DllImport("coredll.dll")]
        public extern static int CallWindowProc(
            IntPtr lpPrevWndFunc, IntPtr hwnd, uint msg, uint wParam, int lParam);

        [DllImport("coredll.dll")]
        public extern static int DefWindowProc(
            IntPtr hwnd, uint msg, uint wParam, int lParam);

        [DllImport("coredll.dll")]
        public extern static int SendMessage(
            IntPtr hwnd, uint msg, uint wParam, ref TVHITTESTINFO lParam);

        [DllImport("coredll.dll", SetLastError = true)]
        public extern static int SendMessage(
            IntPtr hwnd, uint msg, uint wParam, ref TVITEM lParam);

        [DllImport("coredll.dll")]
        public extern static uint GetMessagePos();

        [DllImport("coredll.dll")]
        public extern static IntPtr BeginPaint(IntPtr hwnd, ref PAINTSTRUCT ps);

        [DllImport("coredll.dll")]
        public extern static bool EndPaint(IntPtr hwnd, ref PAINTSTRUCT ps);

        public struct PAINTSTRUCT {
            private IntPtr hdc;
            public bool fErase;
            public Rectangle rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;
        }

        [DllImport("coredll.dll")]
        public extern static IntPtr GetDC(IntPtr hwnd);

        [DllImport("coredll.dll")]
        public extern static bool ReleaseDC(IntPtr hwnd, IntPtr hdc);

        // Helper function to convert a Windows lParam into a Point.
        //   lParam - The parameter to convert.
        // Returns a Point where X is the low 16 bits and Y is the
        // high 16 bits of the value passed in.
        public static Point LParamToPoint(int lParam) {
            uint ulParam = (uint)lParam;
            return new Point(
                (int)(ulParam & 0x0000ffff),
                (int)((ulParam & 0xffff0000) >> 16));
        }

        // Windows messages
        public const uint WM_PAINT = 0x000F;
        public const uint WM_ERASEBKGND = 0x0014;
        public const uint WM_KEYDOWN = 0x0100;
        public const uint WM_KEYUP = 0x0101;
        public const uint WM_MOUSEMOVE = 0x0200;
        public const uint WM_LBUTTONDOWN = 0x0201;
        public const uint WM_LBUTTONUP = 0x0202;
        public const uint WM_NOTIFY = 0x4E;

        // Notifications
        public const uint NM_CLICK = 0xFFFFFFFE;
        public const uint NM_DBLCLK = 0xFFFFFFFD;
        public const uint NM_RCLICK = 0xFFFFFFFB;
        public const uint NM_RDBLCLK = 0xFFFFFFFA;

        // Key
        public const uint VK_SPACE = 0x20;
        public const uint VK_RETURN = 0x0D;

        // Treeview
        public const uint TV_FIRST = 0x1100;
        public const uint TVM_HITTEST = TV_FIRST + 17;

        public const uint TVHT_NOWHERE = 0x0001;
        public const uint TVHT_ONITEMICON = 0x0002;
        public const uint TVHT_ONITEMLABEL = 0x0004;
        public const uint TVHT_ONITEM = (TVHT_ONITEMICON | TVHT_ONITEMLABEL | TVHT_ONITEMSTATEICON);
        public const uint TVHT_ONITEMINDENT = 0x0008;
        public const uint TVHT_ONITEMBUTTON = 0x0010;
        public const uint TVHT_ONITEMRIGHT = 0x0020;
        public const uint TVHT_ONITEMSTATEICON = 0x0040;
        public const uint TVHT_ABOVE = 0x0100;
        public const uint TVHT_BELOW = 0x0200;
        public const uint TVHT_TORIGHT = 0x0400;
        public const uint TVHT_TOLEFT = 0x0800;

        public const uint TVM_GETITEM = TV_FIRST + 62;  //TVM_GETITEMW

        public const uint TVIF_TEXT = 0x0001;
        public const uint TVIF_IMAGE = 0x0002;
        public const uint TVIF_PARAM = 0x0004;
        public const uint TVIF_STATE = 0x0008;
        public const uint TVIF_HANDLE = 0x0010;
        public const uint TVIF_SELECTEDIMAGE = 0x0020;
        public const uint TVIF_CHILDREN = 0x0040;
        public const uint TVIF_DI_SETITEM = 0x1000;

    }

}

