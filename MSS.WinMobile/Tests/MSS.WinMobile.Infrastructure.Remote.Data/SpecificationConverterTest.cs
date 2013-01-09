using System;
using System.Diagnostics;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Remote.Data.Repositories.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSS.WinMobile.Domain.Specifications;

namespace Tests.MSS.WinMobile.Infrastructure.Remote.Data
{
    /// <summary>
    /// Summary description for SpecificationConverterTest
    /// </summary>
    [TestClass]
    public class SpecificationConverterTest
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
        public void RouteByDateConverterTest()
        {
            var date = new DateTime(1985, 7, 7);
            var specification = new RouteByDateSpecification(date);

            const string expected = "date=07.07.1985";
            string actual = SpecificationConverter<Route>.ToQueryString(specification);
            Trace.Write(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AndConverterTest()
        {
            var firstDate = new DateTime(1985, 7, 6);
            var secondDate = new DateTime(1985, 7, 7);

            var specificationLeft = new RouteByDateSpecification(firstDate);
            var andSpecification = specificationLeft.And(new RouteByDateSpecification(secondDate));

            const string expected = "date=06.07.1985&date=07.07.1985";
            string actual = SpecificationConverter<Route>.ToQueryString(andSpecification);
            Trace.Write(actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
