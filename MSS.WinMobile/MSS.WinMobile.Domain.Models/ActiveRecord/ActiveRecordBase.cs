using System;
using System.Data;

namespace MSS.WinMobile.Domain.Models.ActiveRecord
{
    public abstract class ActiveRecordBase
    {
        public int Id { get; protected set; }

        protected abstract string InsertCommand { get; }

        public void Create()
        {
            if (_inTransaction)
                TransactionContext.Enqueue(InsertCommand);
            else {
                IDbConnection connection = ConnectionFactory.GetConnection();
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (IDbTransaction transaction = connection.BeginTransaction()) {
                    using (IDbCommand command = connection.CreateCommand()) {
                        command.CommandText = InsertCommand;
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
            }
        }

        protected abstract string UpdateCommand { get; }

        public void Update()
        {
            if (_inTransaction)
                TransactionContext.Enqueue(UpdateCommand);
            else {
                IDbConnection connection = ConnectionFactory.GetConnection();
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (IDbTransaction transaction = connection.BeginTransaction()) {
                    using (IDbCommand command = connection.CreateCommand()) {
                        command.CommandText = UpdateCommand;
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
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
                IDbConnection connection = ConnectionFactory.GetConnection();
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (IDbTransaction transaction = connection.BeginTransaction()) {
                    using (IDbCommand command = connection.CreateCommand()) {
                        command.CommandText = DeleteCommand;
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
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
            try {
                IDbConnection connection = ConnectionFactory.GetConnection();
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (IDbTransaction transaction = connection.BeginTransaction()) {
                    try {
                        while (TransactionContext.Count > 0) {
                            using (IDbCommand command = connection.CreateCommand()) {
                                command.CommandText = TransactionContext.Dequeue();
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception) {
                        transaction.Rollback();
                    }
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
            //string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            //string fileName = string.Empty;
            //string[] parameters = connectionString.Split(';');
            //foreach (var parameter in parameters)
            //{
            //    string[] parameterKv = parameter.Split('=');
            //    if (parameterKv[0] == "Data Source")
            //        fileName = parameterKv[1];
            //}

            //if (recreate && File.Exists(fileName))
            //{
            //    File.Delete(fileName);
            //}

            IDbConnection connection = ConnectionFactory.GetConnection();
            //if (connection.State != ConnectionState.Open)
            //    connection.Open();

            //if (!File.Exists(fileName))
            //{
            //    var sqlCeEngine = new System.Data.SQLite. SqlCeEngine(connectionString);
            //    sqlCeEngine.CreateDatabase();

            //    string schemaScript;
            //    using (StreamReader reader = File.OpenText(Context.GetAppPath() + @"\Resources\Database\Schema.sqlce"))
            //    {
            //        schemaScript = reader.ReadToEnd();
            //    }

            //    using (IDbTransaction transaction = connection.BeginTransaction()) {
            //        using (IDbCommand command = connection.CreateCommand()) {
            //            string[] schemaStatements = schemaScript.Split(';');
            //            foreach (var schemaStatement in schemaStatements) {
            //                command.CommandText = schemaStatement;
            //                command.ExecuteNonQuery();
            //            }

            //            transaction.Commit();
            //        }
            //    }
            //}
        }
    }
}
