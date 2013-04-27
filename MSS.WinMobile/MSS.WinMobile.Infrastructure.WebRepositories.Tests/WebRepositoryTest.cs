using System;
using System.Globalization;
using System.Linq;
using MSS.WinMobile.Infrastructure.WebRepositories;
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
            WebServer webServer = new WebServer("http://mss.alkotorg.com");
            WebConnectionFactory webConnectionFactory = new WebConnectionFactory(webServer, "manager", "423200");
            WebRepository<StatusDto> target = new WebRepository<StatusDto>(webConnectionFactory);
            IQueryObject<StatusDto, HttpWebRequest, WebConnection> actual = target.Find();

            foreach (var statusDto in actual.ToArray())
            {
                Console.Write(statusDto.Id.ToString(CultureInfo.InvariantCulture) + '\t');
                Console.Write(statusDto.Validity.ToString() + '\t');
                Console.Write(statusDto.Name + '\n');
            }
        }
    }
}
