using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    internal static class FormExtensions
    {
        public static void Navigate<T>(this Form form)
        {
            Form to;
            if (typeof(T) == typeof(ILogonView))
                to = new LogonView();
            else
                throw new ViewNotFoundException();

            to.Show();
            form.Close();
            form.Dispose();
        }

        public static void ShowInfoDialog(this Form form, string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk,
                            MessageBoxDefaultButton.Button1);
        }

        public static bool ShowConfirmDialog(this Form form, string question)
        {
            DialogResult dialogResult = MessageBox.Show(question, "Confirmation", MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2);
            return dialogResult == DialogResult.Yes;
        }

        public class ViewNotFoundException : Exception
        {
        }
    }
}
