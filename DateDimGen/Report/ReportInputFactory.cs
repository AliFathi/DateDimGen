namespace DateDimGen.Report
{
    public class ReportInputFactory
    {
        private readonly DateTimeService _dateSvc;

        public ReportInputFactory(DateTimeService dateTimeService)
        {
            _dateSvc = dateTimeService;
        }

        public ReportInput Create(
            int? month = null, int? year = null,
            int? takeDays = null, int? takeMonths = null, int? takeYears = null,
            int? fromMonth = null, int? fromYear = null,
            int? toMonth = null, int? toYear = null
        )
        {
            if (month.HasValue)
            {
                var from = new PersianDate(year ?? _dateSvc.PersianUtcNow.Year, month.Value);
                var to = from.AddMonths(1);

                return new ReportInput
                {
                    From = from.ToDateTime(),
                    To = to.ToDateTime(),
                    GroupBy = ReportGroupMetric.PersianDay,
                };
            }

            if (year.HasValue)
            {
                var from = new PersianDate(year.Value);
                var to = from.AddYears(1);

                return new ReportInput
                {
                    From = from.ToDateTime(),
                    To = to.ToDateTime(),
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (takeDays.HasValue)
            {
                var tomorrow = _dateSvc.UtcNow.Date.AddDays(1);

                return new ReportInput
                {
                    From = tomorrow.AddDays(-takeDays.Value),
                    To = tomorrow,
                    GroupBy = ReportGroupMetric.PersianDay,
                };
            }

            if (takeMonths.HasValue)
            {
                var to = new PersianDate(_dateSvc.PersianUtcNow.Year, _dateSvc.PersianUtcNow.Month).AddMonths(1);
                var from = to.AddMonths(-takeMonths.Value);

                return new ReportInput
                {
                    From = from.ToDateTime(),
                    To = to.ToDateTime(),
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (takeYears.HasValue)
            {
                var to = new PersianDate(_dateSvc.PersianUtcNow.Year).AddYears(1);
                var from = to.AddYears(-takeYears.Value);

                return new ReportInput
                {
                    From = from.ToDateTime(),
                    To = to.ToDateTime(),
                    GroupBy = ReportGroupMetric.PersianYear,
                };
            }

            if (fromMonth.HasValue)
            {
                var from = new PersianDate(fromYear ?? _dateSvc.PersianUtcNow.Year, fromMonth.Value);
                PersianDate to;

                if (toMonth.HasValue)
                    to = new PersianDate(toYear ?? _dateSvc.PersianUtcNow.Year, toMonth.Value);
                else if (toYear.HasValue)
                    to = new PersianDate(toYear.Value);
                else
                    //to = new PersianDate(_dateSvc.PersianYear, _dateSvc.PersianMonth).AddMonth(1);
                    to = PersianDate.Max;

                return new ReportInput
                {
                    From = from.ToDateTime(),
                    To = to.ToDateTime(),
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (fromYear.HasValue)
            {
                var from = new PersianDate(fromYear.Value);
                PersianDate to;

                if (toMonth.HasValue)
                    to = new PersianDate(toYear ?? _dateSvc.PersianUtcNow.Year, toMonth.Value);
                else if (toYear.HasValue)
                    to = new PersianDate(toYear.Value);
                else
                    //to = new PersianDate(_dateSvc.PersianYear).AddYear(1);
                    to = PersianDate.Max;

                return new ReportInput
                {
                    From = from.ToDateTime(),
                    To = to.ToDateTime(),
                    GroupBy = toMonth.HasValue ? ReportGroupMetric.PersianMonth : ReportGroupMetric.PersianYear,
                };
            }

            if (toMonth.HasValue)
            {
                return new ReportInput
                {
                    From = null,
                    To = new PersianDate(toYear ?? _dateSvc.PersianUtcNow.Year, toMonth.Value).ToDateTime(),
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (toYear.HasValue)
            {
                return new ReportInput
                {
                    From = null,
                    To = new PersianDate(toYear.Value).ToDateTime(),
                    GroupBy = ReportGroupMetric.PersianYear,
                };
            }

            return new ReportInput
            {
                From = null,
                To = null,
                GroupBy = ReportGroupMetric.PersianYear,
            };
        }
    }
}
