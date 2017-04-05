using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChDCStatMenusLibrary.Tests
{
    [TestClass()]
    public class ProcessInfoTests
    {
        [TestMethod()]
        public void GetStorageSizeStringTest()
        {
            Assert.AreEqual("1KB", ProcessInfo.GetStorageSizeString(1024));
            Assert.AreEqual("0 B", ProcessInfo.GetStorageSizeString(0));
            Assert.AreEqual("-1KB", ProcessInfo.GetStorageSizeString(-1024));
            Assert.AreEqual("1KB", ProcessInfo.GetStorageSizeString(1025));
            Assert.AreEqual("128 B", ProcessInfo.GetStorageSizeString(128));
            Assert.AreEqual("1.9KB", ProcessInfo.GetStorageSizeString(2000));
            Assert.AreEqual("0.9KB", ProcessInfo.GetStorageSizeString(1023));

            Assert.AreEqual("0.9GB", ProcessInfo.GetStorageSizeString(1063700000));
            Assert.AreEqual("1KB", ProcessInfo.GetStorageSizeString(1025));
        }
    }
}