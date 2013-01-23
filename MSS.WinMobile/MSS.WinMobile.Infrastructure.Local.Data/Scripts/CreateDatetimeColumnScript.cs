namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts
{
    public class CreateDatetimeColumnScript : CreateColumnScript
    {
        private readonly CreateColumnScript _createColumnScript;

        public CreateDatetimeColumnScript(CreateColumnScript createColumnScript)
        {
            _createColumnScript = createColumnScript;
        }

        private const string Pattern = "{0} datetime";

        public override string Text
        {
            get { return string.Format(Pattern, _createColumnScript.Text); }
        }
    }
}
