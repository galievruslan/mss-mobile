namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.System
{
    public class CreatePrimaryKeyScript : CreateColumnScript
    {
        private readonly CreateColumnScript _createColumnScript;

        public CreatePrimaryKeyScript(CreateColumnScript createColumnScript)
        {
            _createColumnScript = createColumnScript;
        }

        private const string Pattern = "{0} PRIMARY KEY";

        public override string Text
        {
            get { return string.Format(Pattern, _createColumnScript.Text); }
        }
    }
}