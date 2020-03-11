using MD.PersianDateTime;
using System;

namespace DateDimGen
{
    public class DimDate
    {
        public DimDate(DateTime d)
        {
            var j = new PersianDateTime(d);

            Date = d;
            LongDate = d.ToLongDateString();
            DayOfWeek = (int)d.DayOfWeek + 1;
            DayOfWeekName = d.DayOfWeek.ToString();
            DayOfMonth = d.Day;
            DayOfYear = d.DayOfYear;
            Month = d.Month;
            MonthName = GetMonthName(d.Month);
            Year = d.Year;

            PersianDate = j.ToShortDateString();
            PersianDateInt = j.ToShortDateInt();
            PersianLongDate = j.ToLongDateString();
            PersianDayOfWeek = (int)j.PersianDayOfWeek + 1;
            PersianDayOfWeekName = j.GetLongDayOfWeekName;
            PersianDayOfMonth = j.Day;
            PersianDayOfYear = j.GetDayOfYear;
            PersianWeekOfMonth = j.GetWeekOfMonth;
            PersianWeekOfYear = j.GetWeekOfYear;
            PersianMonth = j.Month;
            PersianMonthName = j.MonthName;
            PersianQuarter = GetQuarter(j.Month);
            PersianQuarterName = GetPersinQuarterName(PersianQuarter);
            PersianHalfYear = GetHalfYear(j.Month);
            PersianHalfYearName = GetPersianHalfYearName(PersianHalfYear);
            PersianYear = j.Year;
            PersianIsLeapYear = j.IsLeapYear;
        }

        // تاریخ
        public DateTime Date { get; set; }
        public string LongDate { get; }

        // روز در هفته
        public int DayOfWeek { get; }
        public string DayOfWeekName { get; }

        // روز در ماه
        public int DayOfMonth { get; }

        // روز در سال
        public int DayOfYear { get; }

        // ماه در سال
        public int Month { get; }
        public string MonthName { get; }

        // سال
        public int Year { get; }

        // -------------------------------------------------------

        // تاریخ
        public int PersianDateInt { get; }
        public string PersianDate { get; set; }
        public string PersianLongDate { get; }

        // روز در هفته
        public int PersianDayOfWeek { get; }
        public string PersianDayOfWeekName { get; }

        // روز در ماه
        public int PersianDayOfMonth { get; }

        // روز در سال
        public int PersianDayOfYear { get; }

        // هفته در ماه
        public int PersianWeekOfMonth { get; }

        // هفته در سال
        public int PersianWeekOfYear { get; }

        // ماه در سال
        public int PersianMonth { get; }
        public string PersianMonthName { get; }

        // فصل
        public int PersianQuarter { get; set; }
        public string PersianQuarterName { get; set; }

        // نیمه سال
        public int PersianHalfYear { get; set; }
        public string PersianHalfYearName { get; set; }

        // سال
        public int PersianYear { get; }
        public bool PersianIsLeapYear { get; set; }

        private int GetQuarter(int m)
        {
            var i = m - 1;
            return ((i - (i % 3)) / 3) + 1;
        }

        private int GetHalfYear(int m) => m > 6 ? 2 : 1;

        private string GetQuarterName(int q)
        {
            switch (q)
            {
                case 1: return "Spring";
                case 2: return "Summer";
                case 3: return "Fall";
                case 4: return "Winter";
                default: throw new ArgumentOutOfRangeException("quarter");
            }
        }

        private string GetPersinQuarterName(int q)
        {
            switch (q)
            {
                case 1: return "بهار";
                case 2: return "تابستان";
                case 3: return "پاییز";
                case 4: return "زمستان";
                default: throw new ArgumentOutOfRangeException("jalili quarter");
            }
        }

        private string GetPersianHalfYearName(int h)
        {
            switch (h)
            {
                case 1: return "نیمه‌ی اول";
                case 2: return "نیمه‌ی دوم";
                default: throw new ArgumentOutOfRangeException("half");
            }
        }

        private string GetMonthName(int m)
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
    }
}
