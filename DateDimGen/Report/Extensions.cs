using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace DateDimGen.Report
{
    public static class DateTimeExtensions
    {
        private static readonly PersianCalendar _pc = new PersianCalendar();

        public static PersianInt ToPersianInt(this DateTime dateTime)
        {
            return PersianInt.Create(
                _pc.GetYear(dateTime),
                _pc.GetMonth(dateTime),
                _pc.GetDayOfMonth(dateTime)
            );
        }

        public static IQueryable<CountReportItem<int>> ToJoinReport<TEntity>(
            this IQueryable<TEntity> source,
            IQueryable<DimDate> dimDate,
            ReportInput reportInput,
            Expression<Func<TEntity, DateTime>> innerKey
        ) where TEntity : class
        {
            var join = source
                .Join(dimDate, innerKey, d => d.Date, (e, d) => new Joint<TEntity> { E = e, D = d });

            if (reportInput.From != PersianInt.Min)
                join = join.Where(a => a.D.PersianDateInt >= reportInput.From.ToInt());

            if (reportInput.To != PersianInt.Max)
                join = join.Where(a => a.D.PersianDateInt < reportInput.To.ToInt());

            var dates = join.Select(j => j.D);
            IQueryable<CountReportItem<int>> select;
            switch (reportInput.GroupBy)
            {
                case ReportGroupMetric.PersianDay:
                    select = dates.GroupBy(d => new
                    {
                        d.PersianDayOfMonth,
                        d.PersianDayOfWeekName,
                        d.PersianMonth,
                        d.PersianMonthName,
                        d.PersianYear,
                    })
                    .Select(g => new CountReportItem<int>
                    {
                        Key = g.Key.PersianYear * 10000 + g.Key.PersianMonth * 100 + g.Key.PersianDayOfMonth,
                        Value = g.Count(),

                        Day = g.Key.PersianDayOfMonth,
                        DayName = g.Key.PersianDayOfWeekName,
                        Month = g.Key.PersianMonth,
                        MonthName = g.Key.PersianMonthName,
                        Year = g.Key.PersianYear,
                    });
                    break;

                case ReportGroupMetric.PersianMonth:
                    select = dates.GroupBy(d => new
                    {
                        d.PersianMonth,
                        d.PersianMonthName,
                        d.PersianYear,
                    })
                    .Select(g => new CountReportItem<int>
                    {
                        Key = g.Key.PersianYear * 100 + g.Key.PersianMonth,
                        Value = g.Count(),

                        Day = 0,
                        DayName = null,
                        Month = g.Key.PersianMonth,
                        MonthName = g.Key.PersianMonthName,
                        Year = g.Key.PersianYear,
                    });
                    break;

                case ReportGroupMetric.PersianYear:
                    select = dates.GroupBy(d => new
                    {
                        d.PersianYear
                    })
                    .Select(g => new CountReportItem<int>
                    {
                        Key = g.Key.PersianYear,
                        Value = g.Count(),

                        Day = 0,
                        DayName = null,
                        Month = 0,
                        MonthName = null,
                        Year = g.Key.PersianYear,
                    });
                    break;

                default:
                    throw new InvalidOperationException($"Grouping by {reportInput.GroupBy} not supported.");
            }

            return select.OrderBy(i => i.Key);
        }

        public static IQueryable<CountReportItem<int>> ToLeftJoinReport<TEntity>(
            this IQueryable<TEntity> source,
            IQueryable<DimDate> dimDate,
            ReportInput reportInput,
            Expression<Func<TEntity, DateTime>> innerKey
        ) where TEntity : class
        {
            var leftJoin = dimDate
                .GroupJoin(source, d => d.Date, innerKey, (d, e) => new GroupJoint<TEntity> { D = d, E = e })
                .SelectMany(g => g.E.DefaultIfEmpty(), (g, e) => new Joint<TEntity> { D = g.D, E = e });

            if (reportInput.From != PersianInt.Min)
                leftJoin = leftJoin.Where(a => a.D.PersianDateInt >= reportInput.From.ToInt());

            if (reportInput.To != PersianInt.Max)
                leftJoin = leftJoin.Where(a => a.D.PersianDateInt < reportInput.To.ToInt());

            var dates = leftJoin.Select(j => j.D);
            IQueryable<CountReportItem<int>> select;
            switch (reportInput.GroupBy)
            {
                case ReportGroupMetric.PersianDay:
                    select = dates.GroupBy(d => new
                    {
                        d.PersianDayOfMonth,
                        d.PersianDayOfWeekName,
                        d.PersianMonth,
                        d.PersianMonthName,
                        d.PersianYear,
                    })
                    .Select(g => new CountReportItem<int>
                    {
                        Key = g.Key.PersianYear * 10000 + g.Key.PersianMonth * 100 + g.Key.PersianDayOfMonth,
                        Value = g.Count(),

                        Day = g.Key.PersianDayOfMonth,
                        DayName = g.Key.PersianDayOfWeekName,
                        Month = g.Key.PersianMonth,
                        MonthName = g.Key.PersianMonthName,
                        Year = g.Key.PersianYear,
                    });
                    break;

                case ReportGroupMetric.PersianMonth:
                    select = dates.GroupBy(d => new
                    {
                        d.PersianMonth,
                        d.PersianMonthName,
                        d.PersianYear,
                    })
                    .Select(g => new CountReportItem<int>
                    {
                        Key = g.Key.PersianYear * 100 + g.Key.PersianMonth,
                        Value = g.Count(),

                        Day = 0,
                        DayName = null,
                        Month = g.Key.PersianMonth,
                        MonthName = g.Key.PersianMonthName,
                        Year = g.Key.PersianYear,
                    });
                    break;

                case ReportGroupMetric.PersianYear:
                    select = dates.GroupBy(d => new
                    {
                        d.PersianYear
                    })
                    .Select(g => new CountReportItem<int>
                    {
                        Key = g.Key.PersianYear,
                        Value = g.Count(),

                        Day = 0,
                        DayName = null,
                        Month = 0,
                        MonthName = null,
                        Year = g.Key.PersianYear,
                    });
                    break;

                default:
                    throw new InvalidOperationException($"Grouping by {reportInput.GroupBy} not supported.");
            }

            return select.OrderBy(i => i.Key);
        }

        #region Helpers

        private class Joint<TEntity>
        {
            public DimDate D { get; set; }
            public TEntity E { get; set; }
        }

        private class GroupJoint<TEntity>
        {
            public DimDate D { get; set; }
            public IEnumerable<TEntity> E { get; set; }
        }

        #endregion
    }
}
