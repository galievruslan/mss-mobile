using System;
using System.Diagnostics;
using System.IO;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helpers;

namespace MSS.WinMobile.Infrastructure.SqliteRepositories.Tests
{
    
    
    /// <summary>
    ///This is a test class for SQLiteDatabaseTest and is intended
    ///to contain all SQLiteDatabaseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SQLiteDatabaseTest
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
        [TestMethod()]
        public void SQLiteDatabaseInMemoryDbTest()
        {
            const string dbScriptFileName = @"\schema.sql";
            string databaseScriptFullPath = TestEnvironment.GetApplicationDirectory() + dbScriptFileName;
            SQLiteDatabase target = new SQLiteDatabase(databaseScriptFullPath);
        }

        /// <summary>
        ///A test for SQLiteDatabase Constructor
        ///</summary>
        [TestMethod()]
        public void SQLiteDatabaseFileDbInitializationTest()
        {
            const string dbFileName = @"\storage.sqlite";
            const string dbScriptFileName = @"\schema.sql";
            const string databaseVersion = "3";

            string databaseFullPath = TestEnvironment.GetApplicationDirectory() + dbFileName;
            string databaseScriptFullPath = TestEnvironment.GetApplicationDirectory() + dbScriptFileName;
            var target = new SQLiteDatabase(databaseFullPath, databaseVersion, databaseScriptFullPath);
            Console.WriteLine(databaseFullPath);
            Assert.IsTrue(File.Exists(databaseFullPath));
        }
    }
}
