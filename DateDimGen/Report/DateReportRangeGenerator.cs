using System.Collections.Generic;
using System.Globalization;

namespace DateDimGen.Report
{
    public class DateReportRangeGenerator
    {
        private readonly System.DateTime _MIN = new System.DateTime(2016, 03, 20);
        private readonly System.DateTime _MAX = new System.DateTime(2032, 03, 19);
        private readonly PersianCalendar _pc = new PersianCalendar();

        public IEnumerable<ReportItem<TValue>> Generate<TValue>(ReportInput input)
        {
            if (input == null)
                throw new System.ArgumentNullException(nameof(input));

            switch (input.GroupBy)
            {
                case ReportGroupMetric.Day:
                    return GenerateByDay<TValue>(input.From, input.To);

                case ReportGroupMetric.Month:
                    return GenerateByMonth<TValue>(input.From, input.To);

                case ReportGroupMetric.Year:
                    return GenerateByYear<TValue>(input.From, input.To);

                case ReportGroupMetric.PersianDay:
                    return GenerateByPersianDay<TValue>(input.From, input.To);

                case ReportGroupMetric.PersianMonth:
                    return GenerateByPersianMonth<TValue>(input.From, input.To);

                case ReportGroupMetric.PersianYear:
                    return GenerateByPersianYear<TValue>(input.From, input.To);

                default:
                    return null;
            }
        }

        public IEnumerable<ReportItem<TValue>> GenerateByDay<TValue>(System.DateTime? from = null, System.DateTime? to = null)
        {
            System.DateTime f = from ?? _MIN, t = to ?? _MAX;

            while (f < t)
            {
                yield return new ReportItem<TValue>
                {
                    Key = f.Year * 10000 + f.Month * 100 + f.Day,
                    Day = f.Day,
                    DayName = f.DayOfWeek.ToString(),
                    Month = f.Month,
                    MonthName = DateUtility.GetMonthName(f.Month),
                    Year = f.Year,
                };

                f = f.AddDays(1);
            }
        }

        public IEnumerable<ReportItem<TValue>> GenerateByMonth<TValue>(System.DateTime? from = null, System.DateTime? to = null)
        {
            System.DateTime f = from ?? _MIN, t = to ?? _MAX;

            while (f < t)
            {
                yield return new ReportItem<TValue>
                {
                    Key = f.Year * 100 + f.Month,
                    Month = f.Month,
                    MonthName = DateUtility.GetMonthName(f.Month),
                    Year = f.Year,
                };

                f = f.AddMonths(1);
            }
        }

        public IEnumerable<ReportItem<TValue>> GenerateByYear<TValue>(System.DateTime? from = null, System.DateTime? to = null)
        {
            System.DateTime f = from ?? _MIN, t = to ?? _MAX;

            while (f < t)
            {
                yield return new ReportItem<TValue>
                {
                    Key = f.Year,
                    Year = f.Year,
                };

                f = f.AddYears(1);
            }
        }

        public IEnumerable<ReportItem<TValue>> GenerateByPersianDay<TValue>(System.DateTime? from = null, System.DateTime? to = null)
        {
            System.DateTime f = from ?? _MIN, t = to ?? _MAX;

            while (f < t)
            {
                var pf = f.ToPersianDate();
                yield return new ReportItem<TValue>
                {
                    Key = pf.Year * 10000 + pf.Month * 100 + pf.Day,
                    Day = pf.Day,
                    DayName = DateUtility.GetPersianDayName(_pc.GetDayOfWeek(f)),
                    Month = pf.Month,
                    MonthName = DateUtility.GetMonthName(pf.Month),
                    Year = pf.Year,
                };

                f = f.AddDays(1);
            }
        }

        public IEnumerable<ReportItem<TValue>> GenerateByPersianMonth<TValue>(System.DateTime? from = null, System.DateTime? to = null)
        {
            System.DateTime f = from ?? _MIN, t = to ?? _MAX;

            while (f < t)
            {
                var pf = f.ToPersianDate();
                yield return new ReportItem<TValue>
                {
                    Key = pf.Year * 100 + pf.Month,
                    Month = pf.Month,
                    MonthName = DateUtility.GetMonthName(pf.Month),
                    Year = pf.Year,
                };

                f = pf.AddMonths(1).ToDateTime();
            }
        }

        public IEnumerable<ReportItem<TValue>> GenerateByPersianYear<TValue>(System.DateTime? from = null, System.DateTime? to = null)
        {
            System.DateTime f = from ?? _MIN, t = to ?? _MAX;

            while (f < t)
            {
                var pf = f.ToPersianDate();
                yield return new ReportItem<TValue>
                {
                    Key = pf.Year,
                    Year = pf.Year,
                };

                f = pf.AddYears(1).ToDateTime();
            }
        }
    }
}
