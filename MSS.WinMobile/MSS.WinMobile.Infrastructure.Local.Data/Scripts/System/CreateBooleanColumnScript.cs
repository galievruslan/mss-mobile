namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.System
{
    public class CreateBooleanColumnScript : CreateColumnScript
    {
        private readonly CreateColumnScript _createColumnScript;

        public CreateBooleanColumnScript(CreateColumnScript createColumnScript)
        {
            _createColumnScript = createColumnScript;
        }

        private const string Pattern = "{0} bit";

        public override string Text
        {
            get { return string.Format(Pattern, _createColumnScript.Text); }
        }
    }
}
