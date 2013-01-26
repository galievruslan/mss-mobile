using System.Text;

namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.System
{
    public class AlterTableScript : Script
    {
        private string _name;

        public AlterTableScript TableName(string name)
        {
            _name = name;
            return this;
        }

        private Script _subScript;

        public AlterTableScript AddColumn(CreateColumnScript createColumnScript)
        {
            _subScript = createColumnScript.InExistingTable();
            return this;
        }

        private const string Pattern = "ALTER TABLE {0}";

        public override string Text {
            get
            {
                var createTableStringBuilder = new StringBuilder();
                createTableStringBuilder.Append(string.Format(Pattern, _name));
                createTableStringBuilder.Append(" ");
                createTableStringBuilder.Append(_subScript.Text);
                createTableStringBuilder.Append(";\n");

                return createTableStringBuilder.ToString();
            }
        }
    }
}
