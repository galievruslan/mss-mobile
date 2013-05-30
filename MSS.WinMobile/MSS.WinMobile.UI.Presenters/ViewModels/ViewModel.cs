using System.Collections.Generic;

namespace MSS.WinMobile.UI.Presenters.ViewModels
{
    public abstract class ViewModel
    {
        protected readonly IList<string> ErrorList = new List<string>();
        public IEnumerable<string> Errors {
            get { return ErrorList; }
        }

        public virtual bool Validate() {
            ErrorList.Clear();
            return true;
        }
    }
}
