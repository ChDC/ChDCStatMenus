using System;
using System.Diagnostics;
using System.Globalization;

namespace ChDCStatMenusLibrary
{
    public class TimeInfo
    {

        //C# 获取农历日期

        ///<summary>
        /// 实例化一个 ChineseLunisolarCalendar
        ///</summary>
        private static ChineseLunisolarCalendar ChineseCalendar = new ChineseLunisolarCalendar();

        ///<summary>
        /// 十天干
        ///</summary>
        private static string[] tg = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };

        ///<summary>
        /// 十二地支
        ///</summary>
        private static string[] dz = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };

        ///<summary>
        /// 十二生肖
        ///</summary>
        private static string[] sx = { "鼠", "牛", "虎", "免", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };

        ///<summary>
        /// 农历月
        ///</summary>

        ///<return s></return s>
        private static string[] months = { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "腊" };

        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] decadeDays = { "初", "十", "廿", "三" };
        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] days = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };

        ///<summary>
        /// 返回农历天干地支年
        ///</summary>
        ///<param name="year">农历年</param>
        ///<return s></return s>
        public static string GetLunisolarYear(int year)
        {
            Trace.Assert(year > 0, "Illegal Year");
            int tgIndex = (year + 6) % 10;
            int dzIndex = (year + 8) % 12;

            return string.Concat(tg[tgIndex], dz[dzIndex]);
        }

        /// <summary>
        /// 获取指定年份的属相
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static string GetChineseZodiac(int year)
        {
            Trace.Assert(year > 0, "Illegal Year");
            int dzIndex = (year + 8) % 12;
            return sx[dzIndex];
        }
        
        ///<summary>
        /// 返回农历月
        ///</summary>
        ///<param name="month">月份</param>
        ///<return s></return s>
        public static string GetLunisolarMonth(int month)
        {
            Trace.Assert(month < 13 && month > 0, "Illegal Month");
            return months[month - 1];
        }

        ///<summary>
        /// 返回农历日
        ///</summary>
        ///<param name="day">天</param>
        ///<return s></return s>
        public static string GetLunisolarDay(int day)
        {
            Trace.Assert(day > 0 && day < 32, "Illegal Day");

            if (day == 20 || day == 30)
            {
                // 二十 三十
                return string.Concat(days[(day - 1) / 10], decadeDays[1]);
            }
            else
            {
                return string.Concat(decadeDays[(day - 1) / 10], days[(day - 1) % 10]);
            }
        }



        ///<summary>
        /// 根据公历获取农历日期
        ///</summary>
        ///<param name="datetime">公历日期</param>
        ///<return s></return s>
        public static string GetChineseDateTime(DateTime datetime)
        {
            int year = ChineseCalendar.GetYear(datetime);
            int month = ChineseCalendar.GetMonth(datetime);
            int day = ChineseCalendar.GetDayOfMonth(datetime);

            //获取闰月， 0 则表示没有闰月
            int leapMonth = ChineseCalendar.GetLeapMonth(year);

            bool isleap = false;

            if (leapMonth > 0)
            {
                if (leapMonth == month)
                {
                    //闰月
                    isleap = true;
                    month--;
                }
                else if (month > leapMonth)
                {
                    month--;
                }
            }

            return String.Format("{0}[{1}]年{2}{3}月{4}", 
                GetLunisolarYear(year), 
                GetChineseZodiac(year),
                isleap ? "闰" : string.Empty, GetLunisolarMonth(month),
                GetLunisolarDay(day)
                );
        }

    }
}
