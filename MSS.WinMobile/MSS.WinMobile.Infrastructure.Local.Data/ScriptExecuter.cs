using System;
using System.Collections.Generic;
using System.Data;
using MSS.WinMobile.Infrastructure.Local.Data.ScriptGenerators;
using MSS.WinMobile.Infrastructure.Local.Data.Scripts;

namespace MSS.WinMobile.Infrastructure.Local.Data
{
    public class ScriptExecuter
    {
        private readonly IDbConnection _connection;

        public ScriptExecuter(IDbConnection connection)
        {
            _connection = connection;
        }

        public void ExecuteCreateScripts(IEnumerable<Script> scripts)
        {
            using (IDbTransaction transaction = _connection.BeginTransaction())
            {
                try
                {
                    foreach (var script in scripts)
                    {
                        IDbCommand command = _connection.CreateCommand();
                        command.CommandText = script.Text;
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Insert<T>(T entity)
        {
            Script script = DataScriptGenerator.GenerateInsertFor(entity);
            using (IDbTransaction transaction = _connection.BeginTransaction())
            {
                try
                {
                    IDbCommand command = _connection.CreateCommand();
                    command.CommandText = script.Text;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
