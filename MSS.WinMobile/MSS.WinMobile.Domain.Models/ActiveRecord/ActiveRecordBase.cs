using System;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;

namespace MSS.WinMobile.Domain.Models.ActiveRecord
{
    public abstract class ActiveRecordBase
    {
        protected string ConnectionString;

        protected ActiveRecordBase()
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        protected abstract string InsertCommand { get; }

        public void Create()
        {
            if (_inTransaction)
                TransactionContext.Enqueue(InsertCommand);
            else
            {
                using (IDbConnection connection = new SqlCeConnection(ConnectionString))
                {
                    connection.Open();
                    using (IDbTransaction transaction = connection.BeginTransaction())
                    {
                        using (IDbCommand command = connection.CreateCommand())
                        {
                            command.CommandText = InsertCommand;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    connection.Close();
                }
            }
        }

        protected abstract string UpdateCommand { get; }

        public void Update()
        {
            if (_inTransaction)
                TransactionContext.Enqueue(UpdateCommand);
            else
            {
                using (IDbConnection connection = new SqlCeConnection(ConnectionString))
                {
                    connection.Open();
                    using (IDbTransaction transaction = connection.BeginTransaction())
                    {
                        using (IDbCommand command = connection.CreateCommand())
                        {
                            command.CommandText = UpdateCommand;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    connection.Close();
                }
            }
        }

        protected abstract string DeleteCommand { get; }

        public void Delete()
        {
            if (_inTransaction)
                TransactionContext.Enqueue(DeleteCommand);
            else
            {
                using (IDbConnection connection = new SqlCeConnection(ConnectionString))
                {
                    connection.Open();
                    using (IDbTransaction transaction = connection.BeginTransaction())
                    {
                        using (IDbCommand command = connection.CreateCommand())
                        {
                            command.CommandText = DeleteCommand;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    connection.Close();
                }
            }
        }

        private static bool _inTransaction;

        public static void BeginTransaction()
        {
            if (_inTransaction)
                throw new AlreadyInTransactionException();

            _inTransaction = true;
        }

        public static void Commit()
        {
            try
            {
                using (
                    IDbConnection connection = new SqlCeConnection(ConfigurationManager.AppSettings["ConnectionString"])
                    )
                {
                    connection.Open();
                    using (IDbTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            while (TransactionContext.Count > 0)
                            {
                                using (IDbCommand command = connection.CreateCommand())
                                {
                                    command.CommandText = TransactionContext.Dequeue();
                                    command.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                        }
                    }
                    connection.Close();
                }
            }
            finally
            {
                _inTransaction = false;
            }
        }

        public static void Rollback()
        {
            try
            {
                TransactionContext.Clear();
            }
            finally
            {
                _inTransaction = false;
            }
        }

        public static void Initialize(bool recreate)
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            string fileName = string.Empty;
            string[] parameters = connectionString.Split(';');
            foreach (var parameter in parameters)
            {
                string[] parameterKv = parameter.Split('=');
                if (parameterKv[0] == "Data Source")
                    fileName = parameterKv[1];
            }

            if (recreate && File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            if (!File.Exists(fileName))
            {
                var sqlCeEngine = new SqlCeEngine(connectionString);
                sqlCeEngine.CreateDatabase();

                string schemaScript;
                using (StreamReader reader = File.OpenText(Context.GetAppPath() + @"\Resources\Database\Schema.sqlce"))
                {
                    schemaScript = reader.ReadToEnd();
                }

                using (IDbConnection connection = new SqlCeConnection(connectionString))
                {
                    connection.Open();
                    using (IDbTransaction transaction = connection.BeginTransaction())
                    {
                        using (IDbCommand command = connection.CreateCommand())
                        {
                            string[] schemaStatements = schemaScript.Split(';');
                            foreach (var schemaStatement in schemaStatements)
                            {
                                command.CommandText = schemaStatement;
                                command.ExecuteNonQuery();        
                            }
                            
                            transaction.Commit();
                        }
                    }
                    connection.Close();
                }
            }
        }
    }
}
