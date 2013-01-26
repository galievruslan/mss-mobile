namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.System
{
    public class AddColumnScript : CreateColumnScript
    {
        private readonly CreateColumnScript _createColumnScript;

        public AddColumnScript(CreateColumnScript createColumnScript)
        {
            _createColumnScript = createColumnScript;
        }

        private const string Pattern = "ADD COLUMN {0}";

        public override string Text
        {
            get { return string.Format(Pattern, _createColumnScript.Text); }
        }
    }
}
