using System.Data.SQLite;
using System.Text;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.SqLiteExtensions {
    [SQLiteFunction(Name = "NOCASE", FuncType = FunctionType.Collation)]
    public class CollationCaseInsensitiveExtension : SQLiteFunction {
        public override int Compare(string first, string second) {
            byte[] firstBytes = Encoding.UTF8.GetBytes(first);
            byte[] secondBytes = Encoding.UTF8.GetBytes(second);
            return
                System.String.Compare(
                    Encoding.UTF8.GetString(firstBytes, 0, firstBytes.Length).ToLower(),
                    Encoding.UTF8.GetString(secondBytes, 0, secondBytes.Length).ToLower(),
                    System.StringComparison.OrdinalIgnoreCase);
        }
    }
}