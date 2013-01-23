namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts
{
    public class CreateColumnScript : Script
    {
        private string _name;

        public CreateColumnScript ColumnName(string name)
        {
            _name = name;
            return this;
        }

        public override string Text
        {
            get { return _name; }
        }
    }
}
