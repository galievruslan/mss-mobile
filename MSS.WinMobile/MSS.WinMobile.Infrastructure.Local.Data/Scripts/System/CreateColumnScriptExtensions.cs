namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.System
{
    public static class CreateColumnScriptExtensions
    {
        public static CreateIntegerColumnScript AsInteger(this CreateColumnScript createColumnScript)
        {
            return new CreateIntegerColumnScript(createColumnScript);
        }

        public static CreateDatetimeColumnScript AsDatetime(this CreateColumnScript createColumnScript)
        {
            return new CreateDatetimeColumnScript(createColumnScript);
        }

        public static CreateBooleanColumnScript AsBoolean(this CreateColumnScript createColumnScript)
        {
            return new CreateBooleanColumnScript(createColumnScript);
        }

        public static CreateDecimalColumnScript AsDecimal(this CreateColumnScript createColumnScript, int precision, int scale)
        {
            return new CreateDecimalColumnScript(createColumnScript, precision, scale);
        }

        public static CreateStringColumnScript AsString(this CreateColumnScript createColumnScript, int lenght)
        {
            return new CreateStringColumnScript(createColumnScript, lenght);
        }

        public static CreateReferenceColumnScript AsReference(this CreateColumnScript createColumnScript, string referencedTableName, string referencedColumnName)
        {
            return new CreateReferenceColumnScript(createColumnScript, referencedTableName, referencedColumnName);
        }

        public static CreateReferenceColumnScript AsReference(this CreateColumnScript createColumnScript, string referencedTableName)
        {
            return new CreateReferenceColumnScript(createColumnScript, referencedTableName);
        }

        public static CreatePrimaryKeyScript AsPrimaryKey(this CreateColumnScript createColumnScript)
        {
            return new CreatePrimaryKeyScript(createColumnScript);
        }

        public static AddColumnScript InExistingTable(this CreateColumnScript createColumnScript)
        {
            return new AddColumnScript(createColumnScript);
        }
    }
}
