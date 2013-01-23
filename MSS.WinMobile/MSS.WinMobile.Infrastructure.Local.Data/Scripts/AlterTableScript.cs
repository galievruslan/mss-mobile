using System.Collections.Generic;
using System.Text;

namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts
{
    public class AlterTableScript : Script
    {
        public AlterTableScript()
        {
            _subScripts = new List<Script>();
        }

        private string _name;

        public AlterTableScript TableName(string name)
        {
            _name = name;
            return this;
        }

        private readonly List<Script> _subScripts;

        public AlterTableScript AddColumn(CreateColumnScript createColumnScript)
        {
            _subScripts.Add(createColumnScript.InExistingTable());
            return this;
        }

        private const string Pattern = "ALTER TABLE {0}";

        public override string Text {
            get
            {
                var createTableStringBuilder = new StringBuilder();
                foreach (Script t in _subScripts)
                {
                    createTableStringBuilder.Append(string.Format(Pattern, _name));
                    createTableStringBuilder.Append(" ");
                    createTableStringBuilder.Append(t.Text);
                    createTableStringBuilder.Append(";\n");
                }
                return createTableStringBuilder.ToString();
            }
        }
    }
}
