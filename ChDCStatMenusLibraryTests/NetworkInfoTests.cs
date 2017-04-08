using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChDCStatMenusLibrary.Tests
{
    [TestClass()]
    public class NetworkInfoTests
    {
        [TestMethod()]
        public void GetPublicIPTest()
        {
            Assert.AreEqual("59.46.127.59", NetworkInfo.GetPublicIP());
        }
    }
}