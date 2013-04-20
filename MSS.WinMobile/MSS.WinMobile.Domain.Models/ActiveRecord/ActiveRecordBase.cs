using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using MSS.WinMobile.Application.Environment;
using log4net;

namespace MSS.WinMobile.Domain.Models.ActiveRecord
{
    public abstract class ActiveRecordBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ActiveRecordBase));

        public int Id { get; protected set; }

        protected abstract string SaveCommand { get; }

        public void Save()
        {
            if (InTransaction)
                TransactionContext.Enqueue(SaveCommand);
            else {
                SQLiteConnection connection = ConnectionFactory.GetConnection();
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                
                using (IDbTransaction transaction = connection.BeginTransaction()) {
                    using (IDbCommand command = connection.CreateCommand()) {
                        command.CommandText = SaveCommand;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();

                    if (Id == 0)
                    {
                        Id = (int)connection.LastInsertRowId;
                    }
                }
            }
        }

        protected abstract string DeleteCommand { get; }

        public void Delete()
        {
            if (InTransaction)
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

        static bool InTransaction { get; set; }

        public static void BeginTransaction()
        {
            if (InTransaction)
                throw new AlreadyInTransactionException();

            InTransaction = true;
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
                        Rollback();
                        Log.Error("Transaction failed", exception);
                    }
                }
            }
            finally
            {
                InTransaction = false;
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
                InTransaction = false;
            }
        }
        
        public static void Initialize(bool recreate)
        {
            var manager = new Application.Configuration.ConfigurationManager(Environments.AppPath);
            string fileName = manager.GetConfig("Commom").GetSection("Database").GetSetting("FileName").Value;
            string fullFileName = string.Format("{0}\\{1}", Environments.AppPath, fileName);

            if (recreate || !File.Exists(fullFileName))
            {
                CreateDatabase(fullFileName);
            }
        }

        private static void CreateDatabase(string databaseFilePath)
        {
            if (File.Exists(databaseFilePath))
                File.Delete(databaseFilePath);

            SQLiteConnection.CreateFile(databaseFilePath);
            IDbConnection connection = ConnectionFactory.GetConnection();

            string schemaScript;
            using (StreamReader reader = File.OpenText(Environments.AppPath + @"\Resources\Database\Schema.sql"))
            {
                schemaScript = reader.ReadToEnd();
            }

            using (IDbTransaction transaction = connection.BeginTransaction())
            {
                using (IDbCommand command = connection.CreateCommand())
                {

                    command.CommandText = schemaScript;
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        protected const string SelectPostfix = ".select.sql";
        protected const string SavePostfix = ".save.sql";
        protected const string DeletePostfix = ".delete.sql";
    }
}
