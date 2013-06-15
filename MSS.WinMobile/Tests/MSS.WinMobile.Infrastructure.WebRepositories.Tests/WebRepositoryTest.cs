using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;
using System.Net;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.WebRepositories.Tests
{
    
    
    /// <summary>
    ///This is a test class for WebRepositoryTest and is intended
    ///to contain all WebRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WebRepositoryTest
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

        [TestMethod()]
        public void FindTest()
        {
            var webServer = new WebServer("http://mss.alkotorg.com");
            var webConnectionFactory = new WebConnectionFactory(webServer, "manager", "423200");
            var target = new WebRepository<StatusDto>(webConnectionFactory);
            IQueryObject<StatusDto, IDictionary<string,object>, WebConnection> actual = target.Find();

            foreach (var statusDto in actual.ToArray())
            {
                Console.Write(statusDto.Id.ToString(CultureInfo.InvariantCulture) + '\t');
                Console.Write(statusDto.Validity.ToString() + '\t');
                Console.Write(statusDto.Name + '\n');
            }

            Assert.AreEqual(4, actual.ToArray().Length);
        }

        [TestMethod()]
        public void FindPageTest()
        {
            var webServer = new WebServer("http://mss.alkotorg.com");
            var webConnectionFactory = new WebConnectionFactory(webServer, "manager", "423200");
            var target = new WebRepository<StatusDto>(webConnectionFactory);
            IQueryObject<StatusDto, IDictionary<string, object>, WebConnection> actual = target.Find().Paged(2, 2);

            foreach (var statusDto in actual.ToArray())
            {
                Console.Write(statusDto.Id.ToString(CultureInfo.InvariantCulture) + '\t');
                Console.Write(statusDto.Validity.ToString() + '\t');
                Console.Write(statusDto.Name + '\n');
            }

            Assert.AreEqual(2, actual.ToArray().Length);
        }
        

        [TestMethod()]
        public void FindOlderThanTest()
        {
            var webServer = new WebServer("http://mss.alkotorg.com");
            var webConnectionFactory = new WebConnectionFactory(webServer, "manager", "423200");
            var target = new WebRepository<StatusDto>(webConnectionFactory);
            IQueryObject<StatusDto, IDictionary<string, object>, WebConnection> actual = target.Find().UpdatedAfter(new DateTime(2013, 04, 24, 8, 15, 0));

            foreach (var statusDto in actual.ToArray())
            {
                Console.Write(statusDto.Id.ToString(CultureInfo.InvariantCulture) + '\t');
                Console.Write(statusDto.Validity.ToString() + '\t');
                Console.Write(statusDto.Name + '\n');
            }

            Assert.AreEqual(4, actual.ToArray().Length);

            actual = target.Find().UpdatedAfter(new DateTime(2013, 04, 24, 8, 16, 0));

            foreach (var statusDto in actual.ToArray())
            {
                Console.Write(statusDto.Id.ToString(CultureInfo.InvariantCulture) + '\t');
                Console.Write(statusDto.Validity.ToString() + '\t');
                Console.Write(statusDto.Name + '\n');
            }

            Assert.AreEqual(0, actual.ToArray().Length);
        }
    }
}
