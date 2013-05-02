using System.Collections.Generic;
using System.Text;

namespace MSS.WinMobile.UI.Presenters.ViewModels
{
    public abstract class ViewModel
    {
        protected readonly IList<string> ErrorList = new List<string>();
        public string Errors {
            get {
                var errorsStringBilder = new StringBuilder();
                foreach (var error in ErrorList) {
                    errorsStringBilder.Append(error);
                    errorsStringBilder.Append('\n');
                }
                return errorsStringBilder.ToString();
            }
        }

        public virtual bool Validate() {
            ErrorList.Clear();
            return true;
        }
    }
}
