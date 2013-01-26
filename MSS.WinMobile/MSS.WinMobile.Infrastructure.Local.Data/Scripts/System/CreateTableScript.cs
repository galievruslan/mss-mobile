using System.Collections.Generic;
using System.Text;

namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.System
{
    public class CreateTableScript : Script
    {
        public CreateTableScript()
        {
            _createColumnScripts = new List<CreateColumnScript>();
        }

        private string _name;

        public CreateTableScript TableName(string name)
        {
            _name = name;
            return this;
        }

        private readonly List<CreateColumnScript> _createColumnScripts;

        public CreateTableScript AddColumn(CreateColumnScript createColumnScript)
        {
            _createColumnScripts.Add(createColumnScript);
            return this;
        }

        private const string Pattern = "CREATE TABLE {0}";

        public override string Text {
            get
            {
                var createTableStringBuilder = new StringBuilder();
                createTableStringBuilder.Append(string.Format(Pattern, _name));
                createTableStringBuilder.Append("\n(\n");
                for (int i = 0; i < _createColumnScripts.Count; i++)
                {
                    createTableStringBuilder.Append(_createColumnScripts[i].Text);
                    createTableStringBuilder.Append(i != _createColumnScripts.Count - 1 ? "," : ")\n");
                    createTableStringBuilder.Append("\n");
                }

                return createTableStringBuilder.ToString();
            }
        }
    }
}
