namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.System
{
    public class CreateDecimalColumnScript : CreateColumnScript
    {
        private readonly CreateColumnScript _createColumnScript;
        private readonly int _precision;
        private readonly int _scale;

        public CreateDecimalColumnScript(CreateColumnScript createColumnScript, int precision, int scale)
        {
            _createColumnScript = createColumnScript;
            _precision = precision;
            _scale = scale;
        }

        private const string Pattern = "{0} numeric({1},{2})";

        public override string Text
        {
            get { return string.Format(Pattern, _createColumnScript.Text, _precision, _scale); }
        }
    }
}
