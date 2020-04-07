using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DateDimGen.Report
{
    public static class Extensions
    {
        private static readonly ReportRangeGenerator _rangeGen = new ReportRangeGenerator();

        public static IEnumerable<ReportItem<TValue>> FillTheGaps<TValue>(
            this IEnumerable<ReportItem<TValue>> report,
            ReportInput input
        ) where TValue : struct
        {
            var range = _rangeGen.Generate<TValue>(input);
            return report.Union(range).OrderBy(r => r.Key).ToList();
        }

        public static PersianDate ToPersianDate(this DateTime dateTime)
        {
            return new PersianDate(dateTime);
        }

        public static IQueryable<ReportItem<int>> ToJoinReport<TEntity>(
            this IQueryable<TEntity> source,
            IQueryable<DimDate> dimDate,
            ReportInput reportInput,
            Expression<Func<TEntity, DateTime>> innerKey
        ) where TEntity : class
        {
            var join = source
                .Join(dimDate, innerKey, d => d.Date, (e, d) => new Joint<TEntity> { E = e, D = d });

            if (reportInput.From.HasValue)
                join = join.Where(a => a.D.Date >= reportInput.From.Value);

            if (reportInput.To.HasValue)
                join = join.Where(a => a.D.Date < reportInput.To.Value);

            var dates = join.Select(j => j.D);
            IQueryable<ReportItem<int>> select;
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
                    .Select(g => new ReportItem<int>
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
                    .Select(g => new ReportItem<int>
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
                    .Select(g => new ReportItem<int>
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

        public static IQueryable<ReportItem<int>> ToLeftJoinReport<TEntity>(
            this IQueryable<TEntity> source,
            IQueryable<DimDate> dimDate,
            ReportInput reportInput,
            Expression<Func<TEntity, DateTime>> innerKey
        ) where TEntity : class
        {
            var leftJoin = dimDate
                .GroupJoin(source, d => d.Date, innerKey, (d, e) => new GroupJoint<TEntity> { D = d, E = e })
                .SelectMany(g => g.E.DefaultIfEmpty(), (g, e) => new Joint<TEntity> { D = g.D, E = e });

            if (reportInput.From.HasValue)
                leftJoin = leftJoin.Where(a => a.D.Date >= reportInput.From.Value);

            if (reportInput.To.HasValue)
                leftJoin = leftJoin.Where(a => a.D.Date < reportInput.To.Value);

            var dates = leftJoin.Select(j => j.D);
            IQueryable<ReportItem<int>> select;
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
                    .Select(g => new ReportItem<int>
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
                    .Select(g => new ReportItem<int>
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
                    .Select(g => new ReportItem<int>
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
