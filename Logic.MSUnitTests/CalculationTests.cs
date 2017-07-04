using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logic.MSUnitTests
{
    [TestClass]
    public class CalculationTests
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\Numbers.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("Logic.MSUnitTests\\Numbers.xml")]
        [TestMethod]
        public void InsertBits_TransferBitsFromSourceToDestination_NumberWithReplacedBits()
        {
            int source = Convert.ToInt32(TestContext.DataRow["Source"]);
            int destination = Convert.ToInt32(TestContext.DataRow["Destination"]);
            int start = Convert.ToInt32(TestContext.DataRow["Start"]);
            int end = Convert.ToInt32(TestContext.DataRow["End"]);

            int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            int actual = Calculation.InsertBits(source, destination, start, end);

            Assert.AreEqual(expected, actual);
        }
    }
}
