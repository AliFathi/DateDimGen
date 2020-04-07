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
            int? takeDays = null, int? takeMonth = null, int? takeYear = null,
            int? fromMonth = null, int? fromYear = null,
            int? toMonth = null, int? toYear = null
        )
        {
            if (month.HasValue)
            {
                var from = PersianDate.Create(year ?? _dateSvc.PersianUtcNow.Year, month.Value);
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
                var from = PersianDate.Create(year.Value);
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

            if (takeMonth.HasValue)
            {
                var to = PersianDate.Create(_dateSvc.PersianUtcNow.Year, _dateSvc.PersianUtcNow.Month).AddMonths(1);
                var from = to.AddMonths(-takeMonth.Value);

                return new ReportInput
                {
                    From = from.ToDateTime(),
                    To = to.ToDateTime(),
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (takeYear.HasValue)
            {
                var to = PersianDate.Create(_dateSvc.PersianUtcNow.Year).AddYears(1);
                var from = to.AddYears(-takeYear.Value);

                return new ReportInput
                {
                    From = from.ToDateTime(),
                    To = to.ToDateTime(),
                    GroupBy = ReportGroupMetric.PersianYear,
                };
            }

            if (fromMonth.HasValue)
            {
                var from = PersianDate.Create(fromYear ?? _dateSvc.PersianUtcNow.Year, fromMonth.Value);
                PersianDate to;

                if (toMonth.HasValue)
                    to = PersianDate.Create(toYear ?? _dateSvc.PersianUtcNow.Year, toMonth.Value);
                else if (toYear.HasValue)
                    to = PersianDate.Create(toYear.Value);
                else
                    //to = PersianDate.Create(_dateSvc.PersianYear, _dateSvc.PersianMonth).AddMonth(1);
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
                var from = PersianDate.Create(fromYear.Value);
                PersianDate to;

                if (toMonth.HasValue)
                    to = PersianDate.Create(toYear ?? _dateSvc.PersianUtcNow.Year, toMonth.Value);
                else if (toYear.HasValue)
                    to = PersianDate.Create(toYear.Value);
                else
                    //to = PersianDate.Create(_dateSvc.PersianYear).AddYear(1);
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
                    To = PersianDate.Create(toYear ?? _dateSvc.PersianUtcNow.Year, toMonth.Value).ToDateTime(),
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (toYear.HasValue)
            {
                return new ReportInput
                {
                    From = null,
                    To = PersianDate.Create(toYear.Value).ToDateTime(),
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

        public PersianReportInput CreatePersian(
            int? month = null, int? year = null,
            int? takeDays = null, int? takeMonth = null, int? takeYear = null,
            int? fromMonth = null, int? fromYear = null,
            int? toMonth = null, int? toYear = null
        )
        {
            if (month.HasValue)
            {
                var from = PersianDate.Create(year ?? _dateSvc.PersianNow.Year, month.Value);
                var to = from.AddMonths(1);

                return new PersianReportInput
                {
                    From = from,
                    To = to,
                    GroupBy = ReportGroupMetric.PersianDay,
                };
            }

            if (year.HasValue)
            {
                var from = PersianDate.Create(year.Value);
                var to = from.AddYears(1);

                return new PersianReportInput
                {
                    From = from,
                    To = to,
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (takeDays.HasValue)
            {
                var tomorrow = _dateSvc.UtcNow.AddDays(1);

                return new PersianReportInput
                {
                    From = tomorrow.AddDays(-takeDays.Value).ToPersianDate(),
                    To = tomorrow.ToPersianDate(),
                    GroupBy = ReportGroupMetric.PersianDay,
                };
            }

            if (takeMonth.HasValue)
            {
                var to = PersianDate.Create(_dateSvc.PersianNow.Year, _dateSvc.PersianNow.Month).AddMonths(1);
                var from = to.AddMonths(-takeMonth.Value);

                return new PersianReportInput
                {
                    From = from,
                    To = to,
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (takeYear.HasValue)
            {
                var to = PersianDate.Create(_dateSvc.PersianNow.Year).AddYears(1);
                var from = to.AddYears(-takeYear.Value);

                return new PersianReportInput
                {
                    From = from,
                    To = to,
                    GroupBy = ReportGroupMetric.PersianYear,
                };
            }

            if (fromMonth.HasValue)
            {
                var from = PersianDate.Create(fromYear ?? _dateSvc.PersianNow.Year, fromMonth.Value);
                PersianDate to;

                if (toMonth.HasValue)
                    to = PersianDate.Create(toYear ?? _dateSvc.PersianNow.Year, toMonth.Value);
                else if (toYear.HasValue)
                    to = PersianDate.Create(toYear.Value);
                else
                    //to = PersianDate.Create(_dateSvc.PersianYear, _dateSvc.PersianMonth).AddMonth(1);
                    to = PersianDate.Max;

                return new PersianReportInput
                {
                    From = from,
                    To = to,
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (fromYear.HasValue)
            {
                var from = PersianDate.Create(fromYear.Value);
                PersianDate to;

                if (toMonth.HasValue)
                    to = PersianDate.Create(toYear ?? _dateSvc.PersianNow.Year, toMonth.Value);
                else if (toYear.HasValue)
                    to = PersianDate.Create(toYear.Value);
                else
                    //to = PersianDate.Create(_dateSvc.PersianYear).AddYear(1);
                    to = PersianDate.Max;

                return new PersianReportInput
                {
                    From = from,
                    To = to,
                    GroupBy = toMonth.HasValue ? ReportGroupMetric.PersianMonth : ReportGroupMetric.PersianYear,
                };
            }

            if (toMonth.HasValue)
            {
                return new PersianReportInput
                {
                    From = PersianDate.Min,
                    To = PersianDate.Create(toYear ?? _dateSvc.PersianNow.Year, toMonth.Value),
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (toYear.HasValue)
            {
                return new PersianReportInput
                {
                    From = PersianDate.Min,
                    To = PersianDate.Create(toYear.Value),
                    GroupBy = ReportGroupMetric.PersianYear,
                };
            }

            return new PersianReportInput
            {
                From = PersianDate.Min,
                To = PersianDate.Max,
                GroupBy = ReportGroupMetric.PersianYear,
            };
        }
    }
}
