using System;

namespace DateDimGen
{
    public static class DateUtility
    {
        public static int GetQuarter(int month)
        {
            var i = month - 1;
            return ((i - (i % 3)) / 3) + 1;
        }

        public static string GetQuarterName(int quarter)
        {
            switch (quarter)
            {
                case 1: return "Spring";
                case 2: return "Summer";
                case 3: return "Fall";
                case 4: return "Winter";
                default: throw new ArgumentOutOfRangeException("quarter");
            }
        }

        public static string GetPersinQuarterName(int quarter)
        {
            switch (quarter)
            {
                case 1: return "بهار";
                case 2: return "تابستان";
                case 3: return "پاییز";
                case 4: return "زمستان";
                default: throw new ArgumentOutOfRangeException("jalili quarter");
            }
        }

        public static int GetHalfYear(int month)
        {
            return month > 6 ? 2 : 1;
        }

        public static string GetHalfYearName(int h)
        {
            switch (h)
            {
                case 1: return "First half";
                case 2: return "Second half";
                default: throw new ArgumentOutOfRangeException("half");
            }
        }

        public static string GetPersianHalfYearName(int h)
        {
            switch (h)
            {
                case 1: return "نیمه‌ی اول";
                case 2: return "نیمه‌ی دوم";
                default: throw new ArgumentOutOfRangeException("half");
            }
        }

        public static string GetMonthName(int m)
        {
            switch (m)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
                default: throw new ArgumentOutOfRangeException("month");
            }
        }

        public static string GetPersianMonthName(int m)
        {
            switch (m)
            {
                case 1: return "فروردین";
                case 2: return "اردیبهشت";
                case 3: return "خرداد";
                case 4: return "تیر";
                case 5: return "مرداد";
                case 6: return "شهریور";
                case 7: return "مهر";
                case 8: return "آبان";
                case 9: return "آذر";
                case 10: return "دی";
                case 11: return "بهمن";
                case 12: return "اسفند";
                default: throw new ArgumentOutOfRangeException("month");
            }
        }

        public static string GetPersianDayName(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday: return "یکشنبه";
                case DayOfWeek.Monday: return "دوشنبه";
                case DayOfWeek.Tuesday: return "سه شنبه";
                case DayOfWeek.Wednesday: return "چهارشنبه";
                case DayOfWeek.Thursday: return "پنج شنبه";
                case DayOfWeek.Friday: return "جمعه";
                case DayOfWeek.Saturday: return "شنبه";
                default: return null;
            }
        }
    }
}
