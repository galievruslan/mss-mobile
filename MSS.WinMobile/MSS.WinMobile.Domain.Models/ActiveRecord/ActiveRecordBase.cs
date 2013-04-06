using System;
using System.Data;
using System.IO;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using log4net;

namespace MSS.WinMobile.Domain.Models.ActiveRecord
{
    public abstract class ActiveRecordBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ActiveRecordBase));

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
                    catch (Exception exception) {
                        transaction.Rollback();
                        Log.ErrorFormat("Transaction failed", exception);
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
            string fileName = ConfigurationManager.AppSettings["DbFileName"];
            string fullFileName = string.Format("{0}\\{1}", Context.GetAppPath(), fileName);

            if (recreate || !File.Exists(fullFileName))
            {
                if (File.Exists(fullFileName))
                    File.Delete(fullFileName);

                System.Data.SQLite.SQLiteConnection.CreateFile(fullFileName);
                IDbConnection connection = ConnectionFactory.GetConnection();

                string schemaScript;
                using (StreamReader reader = File.OpenText(Context.GetAppPath() + @"\Resources\Database\Schema.sql"))
                {
                    schemaScript = reader.ReadToEnd();
                }

                using (IDbTransaction transaction = connection.BeginTransaction()) {
                    using (IDbCommand command = connection.CreateCommand()) {

                        command.CommandText = schemaScript;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                    }
                }
            }
        }
    }
}
