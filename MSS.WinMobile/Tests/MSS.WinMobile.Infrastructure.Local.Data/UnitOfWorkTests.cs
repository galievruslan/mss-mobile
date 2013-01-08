﻿using System.IO;
using MSS.WinMobile.Infrastructure.Local.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.MSS.WinMobile.Infrastructure.Local.Data
{
    /// <summary>
    /// Summary description for UnitOfWorkTests
    /// </summary>
    [TestClass]
    public class UnitOfWorkTests
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void UnitOfWorkConstructorTest()
        {
            const string testFileName = "testStorage.sdf";
            var unitOfWork = new Session(testFileName);

            const bool expected = true;
            bool actual = File.Exists(testFileName);
            Assert.AreEqual(expected, actual);

            File.Delete(testFileName);
        }
    }
}
