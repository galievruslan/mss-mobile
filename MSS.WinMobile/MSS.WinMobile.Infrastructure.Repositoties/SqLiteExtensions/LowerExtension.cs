using System.Data.SQLite;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.SqLiteExtensions {
    [SQLiteFunction(Name = "LOWER", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class LowerExtension : SQLiteFunction {
        public override object Invoke(object[] args) {
            return args[0].ToString().ToLower();
        }
    }
}
