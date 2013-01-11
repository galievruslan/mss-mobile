using System;
using System.Collections.Generic;
using System.Text;

namespace MSS.WinMobile.UI.ViewModel
{
    public class ErrorCollection
    {
        private readonly IList<string> _errors;

        public ErrorCollection()
        {
            _errors = new List<string>();
        }

        public void AddError(string error)
        {
            _errors.Add(error);
        }

        public int Count {
            get { return _errors.Count; }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var error in _errors)
            {
                stringBuilder.Append(error);
                stringBuilder.Append('\n');
            }

            return stringBuilder.ToString();
        }
    }
}
