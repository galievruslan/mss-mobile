using System.Collections.Generic;
using System.Linq;

namespace MSS.WinMobile.UI.Presenters.ViewModels
{
    public abstract class ViewModel
    {
        private readonly IList<string> _errors = new List<string>();
        public string[] Errors {
            get { return _errors.ToArray(); }
        }

        public abstract bool Validate();
    }
}
