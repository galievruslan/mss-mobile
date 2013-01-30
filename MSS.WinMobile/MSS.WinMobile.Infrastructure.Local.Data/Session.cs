using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Local.Data.ScriptGenerators;
using MSS.WinMobile.Infrastructure.Local.Data.Scripts;

namespace MSS.WinMobile.Infrastructure.Local.Data
{
    public class Session : ISession
    {
        private readonly string _connectionString;
        private SqlCeConnection _connection;

        public Session(string path)
        {
            _connectionString = string.Format(@"Data Source={0};Persist Security Info=False;", path);

            if (!File.Exists(path))
            {
                var sqlCeEngine = new SqlCeEngine(_connectionString);
                sqlCeEngine.CreateDatabase();

                var scripts = new List<Script>
                    {
                        SystemScriptGenerator.GenearteCreateTableFor<Customer>(),
                        SystemScriptGenerator.GenearteCreateTableFor<Manager>(),
                        SystemScriptGenerator.GenearteCreateTableFor<Warehouse>(),
                        SystemScriptGenerator.GenearteCreateTableFor<UnitOfMeasure>(),
                        SystemScriptGenerator.GenearteCreateTableFor<PriceList>(),
                        SystemScriptGenerator.GenearteCreateTableFor<Order>(),
                        SystemScriptGenerator.GenearteCreateTableFor<OrderItem>(),
                        SystemScriptGenerator.GenearteCreateTableFor<Product>(),
                        SystemScriptGenerator.GenearteCreateTableFor<Route>(),
                        SystemScriptGenerator.GenearteCreateTableFor<RoutePoint>(),
                        SystemScriptGenerator.GenearteCreateTableFor<ShippingAddress>(),
                        SystemScriptGenerator.GenearteCreateTableFor<Status>()
                    };
                scripts.AddRange(SystemScriptGenerator.GenerateAlterTableFor<Order>());
                scripts.AddRange(SystemScriptGenerator.GenerateAlterTableFor<OrderItem>());
                scripts.AddRange(SystemScriptGenerator.GenerateAlterTableFor<Route>());
                scripts.AddRange(SystemScriptGenerator.GenerateAlterTableFor<RoutePoint>());
                scripts.AddRange(SystemScriptGenerator.GenerateAlterTableFor<ShippingAddress>());

                var scriptExecuter = new ScriptExecuter(GetConnection());
                scriptExecuter.ExecuteCreateScripts(scripts);
            }
        }

        public SqlCeConnection GetConnection()
        {
            if (_connection == null ||
                _connection.State != ConnectionState.Open)
            {
                _connection = new SqlCeConnection(_connectionString);
                _connection.Open();
                return _connection;
            }

            return _connection;
        }

        public ITransaction BeginTransaction()
        {
            if (_connection == null ||
                _connection.State != ConnectionState.Open)
            {
                _connection = new SqlCeConnection(_connectionString);
                _connection.Open();
            }

            return new Transaction(_connection);
        }
    }
}
