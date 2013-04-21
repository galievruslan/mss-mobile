using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Infrastructure.Data;
using log4net;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class SqliteUnitOfWork : IUnitOfWork
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqliteUnitOfWork));

        private static volatile SqliteUnitOfWork _instance;
        private static readonly object SyncRoot = new Object();

        private SqliteUnitOfWork()
        {
            var manager = new ConfigurationManager(Environments.AppPath);
            string fileName = manager.GetConfig("Commom").GetSection("Database").GetSetting("FileName").Value;
            string fullFileName = string.Format("{0}\\{1}", Environments.AppPath, fileName);

            if (!File.Exists(fullFileName))
            {
                SQLiteConnection.CreateFile(fullFileName);
                IDbConnection connection = SqliteConnectionFactory.Instance.GetConnection();

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
        }

        public static SqliteUnitOfWork Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new SqliteUnitOfWork();
                    }
                }

                return _instance;
            }
        }

        public bool InTransaction {
            get { return _transaction != null; }
        }

        private SQLiteTransaction _transaction;
        public void BeginTransaction()
        {
            _transaction = SqliteConnectionFactory.Instance.GetConnection().BeginTransaction();
        }

        public void Commit()
        {
            try{
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }
}
