using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Local.Attributes;
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
                        ScriptGenerator.GenearteCreateTableFor<Customer>(),
                        ScriptGenerator.GenearteCreateTableFor<Manager>(),
                        ScriptGenerator.GenearteCreateTableFor<Order>(),
                        ScriptGenerator.GenearteCreateTableFor<OrderItem>(),
                        ScriptGenerator.GenearteCreateTableFor<Product>(),
                        ScriptGenerator.GenearteCreateTableFor<Route>(),
                        ScriptGenerator.GenearteCreateTableFor<RoutePoint>(),
                        ScriptGenerator.GenearteCreateTableFor<ShippingAddress>(),
                        ScriptGenerator.GenearteCreateTableFor<Status>()
                    };
                scripts.AddRange(ScriptGenerator.GenerateAlterTableFor<Order>());
                scripts.AddRange(ScriptGenerator.GenerateAlterTableFor<OrderItem>());
                scripts.AddRange(ScriptGenerator.GenerateAlterTableFor<Route>());
                scripts.AddRange(ScriptGenerator.GenerateAlterTableFor<RoutePoint>());
                scripts.AddRange(ScriptGenerator.GenerateAlterTableFor<ShippingAddress>());

                var scriptExecuter = new ScriptExecuter(GetConnection());
                scriptExecuter.ExecuteCreateScripts(scripts);
            }
        }

        protected SqlCeConnection GetConnection()
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
