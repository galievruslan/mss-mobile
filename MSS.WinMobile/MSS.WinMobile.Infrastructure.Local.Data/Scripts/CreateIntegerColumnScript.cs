using System;

using System.Collections.Generic;
using System.Text;

namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts
{
    public class CreateIntegerColumnScript : CreateColumnScript
    {
        private readonly CreateColumnScript _createColumnScript;

        public CreateIntegerColumnScript(CreateColumnScript createColumnScript)
        {
            _createColumnScript = createColumnScript;
        }

        private const string Pattern = "{0} int";

        public override string Text
        {
            get { return string.Format(Pattern, _createColumnScript.Text); }
        }
    }
}
