using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders;
using log4net;

namespace MSS.WinMobile.Domain.Models.ActiveRecord
{
    public abstract class ActiveRecordBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ActiveRecordBase));

        public int Id { get; protected set; }

        public void Save()
        {
            Type type = GetType();
            QueryBinder<ActiveRecordBase> queryBinder = QueryBinders[type];
            string saveFor = RegistredTypes[SavePostfix][type];
            string saveCommand = queryBinder.SaveBinder(saveFor, this);

            if (InTransaction)
                TransactionContext.Enqueue(saveCommand);
            else {
                IDbConnection connection = ConnectionFactory.GetConnection();
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                
                using (IDbTransaction transaction = connection.BeginTransaction()) {
                    using (IDbCommand command = connection.CreateCommand()) {
                        command.CommandText = saveCommand;
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }

                    if (Id == 0)
                    {
                        using (IDbCommand command = connection.CreateCommand())
                        {
                            command.CommandText = @"select last_insert_rowid()";
                            Id = (int) command.ExecuteScalar();
                        }
                    }
                }
            }
        }

        public void Delete()
        {
            QueryBinder<ActiveRecordBase> queryBinder = QueryBinders[GetType()];
            string deleteFor = RegistredTypes[SavePostfix][GetType()];
            string deleteCommand = queryBinder.DeleteBinder(deleteFor, this);

            if (InTransaction)
                TransactionContext.Enqueue(deleteCommand);
            else
            {
                IDbConnection connection = ConnectionFactory.GetConnection();
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (IDbTransaction transaction = connection.BeginTransaction()) {
                    using (IDbCommand command = connection.CreateCommand()) {
                        command.CommandText = deleteCommand;
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
            string fileName = ConfigurationManager.AppSettings["DbFileName"];
            string fullFileName = string.Format("{0}\\{1}", Context.GetAppPath(), fileName);

            if (recreate || !File.Exists(fullFileName))
            {
                CreateDatabase(fullFileName);
            }
        }

        private static void CreateDatabase(string databaseFilePath)
        {
            if (File.Exists(databaseFilePath))
                File.Delete(databaseFilePath);

            System.Data.SQLite.SQLiteConnection.CreateFile(databaseFilePath);
            IDbConnection connection = ConnectionFactory.GetConnection();

            string schemaScript;
            using (StreamReader reader = File.OpenText(Context.GetAppPath() + @"\Resources\Database\Schema.sql"))
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

        private const string SelectPostfix = ".select.sql";
        private const string SavePostfix = ".save.sql";
        private const string DeletePostfix = ".delete.sql";

        private static readonly Dictionary<string, Dictionary<Type, string>> RegistredTypes =
            new Dictionary<string, Dictionary<Type, string>>
                {
                    {SelectPostfix, new Dictionary<Type, string>()},
                    {SavePostfix, new Dictionary<Type, string>()},
                    {DeletePostfix, new Dictionary<Type, string>()}
                };

        private static readonly Dictionary<Type, QueryBinder<ActiveRecordBase>> QueryBinders =
            new Dictionary<Type, QueryBinder<ActiveRecordBase>>();

        public static void Register<T>(QueryBinder<T> queryBinder) where T : ActiveRecordBase
        {
            Type typeToRegister = typeof (T);
            string scriptPath = string.Format("{0}\\Resources\\Database\\Queries\\{1}", Context.GetAppPath(), typeToRegister);
            string selectScriptPath = string.Format("{0}{1}", scriptPath, SelectPostfix);
            string saveScriptPath = string.Format("{0}{1}", scriptPath, SavePostfix);
            string deleteScriptPath = string.Format("{0}{1}", scriptPath, DeletePostfix);

            try
            {
                using (var reader = new StreamReader(selectScriptPath))
                {
                    string script = reader.ReadToEnd();
                    RegistredTypes[SelectPostfix].Add(typeToRegister, script);
                }

                using (var reader = new StreamReader(saveScriptPath))
                {
                    string script = reader.ReadToEnd();
                    RegistredTypes[SavePostfix].Add(typeToRegister, script);
                }

                using (var reader = new StreamReader(deleteScriptPath))
                {
                    string script = reader.ReadToEnd();
                    RegistredTypes[DeletePostfix].Add(typeToRegister, script);
                }


                QueryBinders.Add(typeToRegister, queryBinder as QueryBinder<ActiveRecordBase>);
            }
            catch (Exception exception)
            {
                Log.ErrorFormat("Type {0} registration failed!", typeof(T));
                Log.Fatal(exception);
            }
        }
    }
}
