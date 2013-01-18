using System.Data.SqlServerCe;
using System.IO;
using MSS.WinMobile.Infrastructure.Data;
using SubSonic;

namespace MSS.WinMobile.Infrastructure.Local.Data
{
    public class Session : ISession
    {
        private readonly string _connectionString;

        public Session(string storageName)
        {
            string fullFilePath = string.Format(@"{0}\{1}",
                                                Path.GetDirectoryName(
                                                    System.Reflection.Assembly.GetExecutingAssembly()
                                                          .GetName()
                                                          .CodeBase),
                                                storageName);
            _connectionString = string.Format(@"Data Source={0};Persist Security Info=False;", fullFilePath);

            if (!File.Exists(fullFilePath))
            {
                var sqlCeEngine = new SqlCeEngine(_connectionString);
                sqlCeEngine.CreateDatabase();
            }
        }

        public ITransaction BeginTransaction()
        {
            var provider = new SqlCEProvider();

            provider.CreateConnection(_connectionString);
            ISubSonicRepository subSonicRepository =
                new SubSonicRepository(provider);

            return new Transaction(subSonicRepository);
        }
    }
}
