using System.Data.SQLite;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.SqLiteExtensions {
    [SQLiteFunction(Name = "UPPER", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class UpperExtension : SQLiteFunction {
        public override object Invoke(object[] args) {
            return args[0].ToString().ToUpper();
        }
    }
}
