using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChDCStatMenusLibrary.Tests
{
    [TestClass()]
    public class TimeInfoTests
    {
        [TestMethod()]
        public void GetLunisolarYearTest()
        {
            Assert.AreEqual("丁酉", TimeInfo.GetLunisolarYear(2017));
        }

        [TestMethod()]
        public void GetLunisolarMonthTest()
        {
            Assert.AreEqual("腊", TimeInfo.GetLunisolarMonth(12));
            Assert.AreEqual("十一", TimeInfo.GetLunisolarMonth(11));
        }

        [TestMethod()]
        public void GetLunisolarDayTest()
        {
            Assert.AreEqual("十二", TimeInfo.GetLunisolarDay(12));
            Assert.AreEqual("廿一", TimeInfo.GetLunisolarDay(21));
            Assert.AreEqual("二十", TimeInfo.GetLunisolarDay(20));
            Assert.AreEqual("初一", TimeInfo.GetLunisolarDay(1));

        }

        [TestMethod()]
        public void GetChineseDateTimeTest()
        {
            Assert.AreEqual("丁酉[鸡]年三月初九", TimeInfo.GetChineseDateTime(new DateTime(2017, 4, 5)));
        }

        [TestMethod()]
        public void GetChineseZodiacTest()
        {
            Assert.AreEqual("鸡", TimeInfo.GetChineseZodiac(2017));
        }
    }
}