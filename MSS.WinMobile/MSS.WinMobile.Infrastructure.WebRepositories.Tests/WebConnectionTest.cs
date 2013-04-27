using System;
using MSS.WinMobile.Infrastructure.WebRepositories;
using MSS.WinMobile.Infrastructure.WebRepositories.Utilites;
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
            WebServer webServer = new WebServer("http://mss.alkotorg.com");
            string username = "manager";
            string password = "423200";
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
            var webServer = new WebServer("http://mss.alkotorg.com");
            string username = "manager";
            string password = "423200";
            var target = new WebConnection(webServer, username, password);
            target.Open();
        }

        /// <summary>
        ///A test for Get
        ///</summary>
        [TestMethod()]
        public void GetTest()
        {
            WebServer webServer = new WebServer("http://mss.alkotorg.com");
            string username = "manager";
            string password = "423200";
            WebConnection target = new WebConnection(webServer, username, password);
            HttpWebRequest httpWebRequest = RequestFactory.CreateGetRequest(target, @"users/sign_in");
            string expected = RequestDispatcher.Dispatch(target, httpWebRequest);
            Console.WriteLine("Response - \"{0}\"", expected);
            Console.WriteLine("CSRF token - \"{0}\"", target.CsrfTokenContainer.CsrfToken);
            Console.WriteLine("Cookies - \"{0}\"", target.CookieContainer.Cookie);
            Assert.AreNotEqual(string.Empty, target.CsrfTokenContainer.CsrfToken);
        }
    }
}
