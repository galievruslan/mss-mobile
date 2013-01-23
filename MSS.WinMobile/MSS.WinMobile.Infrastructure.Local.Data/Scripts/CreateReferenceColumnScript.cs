namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts
{
    public class CreateReferenceColumnScript : CreateColumnScript
    {
        private readonly CreateColumnScript _createColumnScript;
        private readonly string _referencedTableName;
        private readonly string _referencedColumnName;

        public CreateReferenceColumnScript(CreateColumnScript createColumnScript, string referencedTableName)
        {
            _createColumnScript = createColumnScript;
            _referencedTableName = referencedTableName;
        }

        public CreateReferenceColumnScript(CreateColumnScript createColumnScript, string referencedTableName, string referencedColumnName)
            :this(createColumnScript, referencedTableName)
        {
            _referencedColumnName = referencedColumnName;
        }

        private const string Pattern = "{0} REFERENCES {1} {2}";

        public override string Text
        {
            get
            {
                return
                    string.Format(Pattern, _createColumnScript.Text, _referencedTableName, _referencedColumnName)
                          .TrimEnd();
            }
        }
    }
}
