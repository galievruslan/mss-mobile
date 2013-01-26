namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.System
{
    public class CreateStringColumnScript : CreateColumnScript
    {
        private readonly CreateColumnScript _createColumnScript;
        private readonly int _lenght;

        public CreateStringColumnScript(CreateColumnScript createColumnScript, int lenght)
        {
            _createColumnScript = createColumnScript;
            _lenght = lenght;
        }

        private const string Pattern = "{0} nvarchar({1})";

        public override string Text
        {
            get { return string.Format(Pattern, _createColumnScript.Text, _lenght); }
        }
    }
}
