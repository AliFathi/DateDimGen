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
            MonthName = DateUtility.GetMonthName(d.Month);
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
            PersianQuarter = DateUtility.GetQuarter(j.Month);
            PersianQuarterName = DateUtility.GetPersinQuarterName(PersianQuarter);
            PersianHalfYear = DateUtility.GetHalfYear(j.Month);
            PersianHalfYearName = DateUtility.GetPersianHalfYearName(PersianHalfYear);
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
    }
}
