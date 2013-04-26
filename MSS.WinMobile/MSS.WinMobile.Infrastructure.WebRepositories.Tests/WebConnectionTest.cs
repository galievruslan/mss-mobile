using System;
using MSS.WinMobile.Infrastructure.WebRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace MSS.WinMobile.Infrastructure.WebRepositories.Tests
{
    
    
    /// <summary>
    ///This is a test class for WebConnectionTest and is intended
    ///to contain all WebConnectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WebConnectionTest
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
        ///A test for Post
        ///</summary>
        [TestMethod()]
        public void PostTest()
        {
            WebServer webServer = null; // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string password = string.Empty; // TODO: Initialize to an appropriate value
            WebConnection target = new WebConnection(webServer, username, password); // TODO: Initialize to an appropriate value
            HttpWebRequest httpWebRequest = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Post(httpWebRequest);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Open
        ///</summary>
        [TestMethod()]
        public void OpenTest()
        {
            WebServer webServer = null; // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string password = string.Empty; // TODO: Initialize to an appropriate value
            WebConnection target = new WebConnection(webServer, username, password); // TODO: Initialize to an appropriate value
            target.Open();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Get
        ///</summary>
        [TestMethod()]
        public void GetTest()
        {
            WebServer webServer = null; // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string password = string.Empty; // TODO: Initialize to an appropriate value
            WebConnection target = new WebConnection(webServer, username, password); // TODO: Initialize to an appropriate value
            HttpWebRequest httpWebRequest = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Get(httpWebRequest);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            WebServer webServer = null; // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string password = string.Empty; // TODO: Initialize to an appropriate value
            WebConnection target = new WebConnection(webServer, username, password); // TODO: Initialize to an appropriate value
            target.Dispose();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WebConnection Constructor
        ///</summary>
        [TestMethod()]
        public void WebConnectionConstructorTest()
        {
            var webServer = new WebServer("http://mss.alkotorg.com");
            const string username = "";
            const string password = "";
            var target = new WebConnection(webServer, username, password);
            target.Open();

            Console.WriteLine("CSRF token - {0}", target.CsrfTokenContainer.CsrfToken);
            Assert.AreNotEqual(string.Empty, target.CsrfTokenContainer.CsrfToken);
        }
    }
}
