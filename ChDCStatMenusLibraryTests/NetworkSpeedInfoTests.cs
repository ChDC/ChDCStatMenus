using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChDCStatMenusLibrary.Tests
{
    [TestClass()]
    public class NetworkSpeedInfoTests
    {
        [TestMethod()]
        public void GetSpeedStringTest()
        {
            Assert.AreEqual("1KB/s", NetworkSpeedInfo.GetSpeedString(1024));
            Assert.AreEqual("0 B/s", NetworkSpeedInfo.GetSpeedString(0));
            Assert.AreEqual("-1KB/s", NetworkSpeedInfo.GetSpeedString(-1024));
            Assert.AreEqual("1KB/s", NetworkSpeedInfo.GetSpeedString(1025));
            Assert.AreEqual("128 B/s", NetworkSpeedInfo.GetSpeedString(128));
            Assert.AreEqual("1.9KB/s", NetworkSpeedInfo.GetSpeedString(2000));
            Assert.AreEqual("0.9KB/s", NetworkSpeedInfo.GetSpeedString(1023));

            Assert.AreEqual("0.9GB/s", NetworkSpeedInfo.GetSpeedString(1063700000));
            Assert.AreEqual("1KB/s", NetworkSpeedInfo.GetSpeedString(1025));
        }
    }
}