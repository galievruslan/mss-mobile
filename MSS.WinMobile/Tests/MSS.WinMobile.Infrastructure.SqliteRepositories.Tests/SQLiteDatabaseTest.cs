using System;
using System.IO;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties;
using MSS.WinMobile.Infrastructure.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helpers;
using System.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositories.Tests
{
    
    
    /// <summary>
    ///This is a test class for SQLiteDatabaseTest and is intended
    ///to contain all SQLiteDatabaseTest Unit Tests
    ///</summary>
    [TestClass]
    public class SqLiteDatabaseTest
    {

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for SQLiteDatabase Constructor
        ///</summary>
        [TestMethod]
        public void SqLiteDatabaseInMemoryDbTest()
        {
            const string dbScriptFileName = @"\schema.sql";
            string databaseScriptFullPath = TestEnvironment.GetApplicationDirectory() + dbScriptFileName;
            var storageManager = new SqLiteStorageManager();
            var target = storageManager.InitializeInMemoryStorage(databaseScriptFullPath);

            int actualTablesCount = GetDdTablesCount(target);
            const int expectedTablesCount = 17;
            Assert.AreEqual(expectedTablesCount, actualTablesCount);
            target.Dispose();
        }

        /// <summary>
        ///A test for SQLiteDatabase Constructor
        ///</summary>
        [TestMethod]
        public void SqLiteDatabaseFileDbInitializationTest()
        {
            const string dbFileName = @"\storage.sqlite";
            const string dbScriptFileName = @"\schema.sql";

            string databaseFullPath = TestEnvironment.GetApplicationDirectory() + dbFileName;
            string databaseScriptFullPath = TestEnvironment.GetApplicationDirectory() + dbScriptFileName;
            var storageManager = new SqLiteStorageManager();
            var target = storageManager.CreateOrOpenStorage(databaseFullPath, databaseScriptFullPath);
            Console.WriteLine(databaseFullPath);
            Assert.IsTrue(File.Exists(databaseFullPath));

            int actualTablesCount = GetDdTablesCount(target);
            const int expectedTablesCount = 17;
            Assert.AreEqual(expectedTablesCount, actualTablesCount);
            target.Dispose();
        }

        private int GetDdTablesCount(IStorage sqLiteStorage) {
            IDbConnection connection = sqLiteStorage.Connect();
            using (connection.BeginTransaction()) {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT count(*) FROM sqlite_master WHERE type='table';";
                    object result = command.ExecuteScalar();
                    Console.WriteLine("Get tables count result \"{0}\"", result);
                    return Convert.ToInt32(result);
                }
            }
        }
    }
}
