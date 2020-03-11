using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static System.Console;

namespace DateDimGen
{
    internal static class Generator
    {
        private const string _connectionString = "";

        public static void Run()
        {
            var start = new DateTime(2016, 03, 20); // 1395/01/01
            var end = new DateTime(2032, 03, 20);   // 1410/12/29

            var list = new List<DimDate>();
            while (start < end)
            {
                var dim = new DimDate(start);

                if (dim.PersianDayOfMonth == 1 && list.Count > 0)
                {
                    Insert(list);
                    list.Clear();
                }

                list.Add(dim);
                start = start.AddDays(1);
            }

            if (list.Count > 0)
                Insert(list);

            WriteLine();
            WriteLine("finish");
        }

        private static void Insert(List<DimDate> dimDates)
        {
            var firstDate = dimDates[0];
            WriteLine($"inserting {dimDates.Count} dates for month {firstDate.PersianMonth} of year {firstDate.PersianYear} ...");

            const string command = @"INSERT dbo.DateDimension
(
    Date,
    LongDate,
    DayOfWeek,
    DayOfWeekName,
    DayOfMonth,
    DayOfYear,
    Month,
    MonthName,
    Year,
    PersianDate,
    PersianDateInt,
    PersianLongDate,
    PersianDayOfWeek,
    PersianDayOfWeekName,
    PersianDayOfMonth,
    PersianDayOfYear,
    PersianWeekOfMonth,
    PersianWeekOfYear,
    PersianMonth,
    PersianMonthName,
    PersianQuarter,
    PersianQuarterName,
    PersianHalfYear,
    PersianHalfYearName,
    PersianYear,
    PersianIsLeapYear
)
VALUES
(   @Date
    ,@LongDate
    ,@DayOfWeek
    ,@DayOfWeekName
    ,@DayOfMonth
    ,@DayOfYear
    ,@Month
    ,@MonthName
    ,@Year
    ,@PersianDate
    ,@PersianDateInt
    ,@PersianLongDate
    ,@PersianDayOfWeek
    ,@PersianDayOfWeekName
    ,@PersianDayOfMonth
    ,@PersianDayOfYear
    ,@PersianWeekOfMonth
    ,@PersianWeekOfYear
    ,@PersianMonth
    ,@PersianMonthName
    ,@PersianQuarter
    ,@PersianQuarterName
    ,@PersianHalfYear
    ,@PersianHalfYearName
    ,@PersianYear
    ,@PersianIsLeapYear
)";

            using (var db = new SqlConnection(_connectionString))
            {
                db.Execute(command, param: dimDates);
            }
        }
    }
}
