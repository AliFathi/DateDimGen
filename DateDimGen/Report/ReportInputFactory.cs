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
                var from = PersianInt.Create(year ?? _dateSvc.PersianNow.Year, month.Value);
                var to = from.AddMonth(1);

                return new ReportInput
                {
                    From = from,
                    To = to,
                    GroupBy = ReportGroupMetric.PersianDay,
                };
            }

            if (year.HasValue)
            {
                var from = PersianInt.Create(year.Value);
                var to = from.AddYear(1);

                return new ReportInput
                {
                    From = from,
                    To = to,
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (takeDays.HasValue)
            {
                var tomorrow = _dateSvc.UtcNow.AddDays(1);

                return new ReportInput
                {
                    From = tomorrow.AddDays(-takeDays.Value).ToPersianInt(),
                    To = tomorrow.ToPersianInt(),
                    GroupBy = ReportGroupMetric.PersianDay,
                };
            }

            if (takeMonth.HasValue)
            {
                //if (fromMonth.HasValue && false)
                //{
                //    //from = from.SetYear(fromYear ?? _dateSvc.PersianYear).SetMonth(fromMonth.Value);
                //    //to = from.AddMonth(takeMonth.Value);
                //}
                //else if (toMonth.HasValue && false)
                //{
                //    //from.SetYear(toYear ?? _dateSvc.PersianYear).SetMonth(toMonth.Value).AddMonth(-1).AddMonth(-takeMonth.Value);
                //    //to.SetYear(toYear ?? _dateSvc.PersianYear).SetMonth(toMonth.Value);
                //}
                //else
                //{
                //    //to = to.SetYear(toYear ?? _dateSvc.PersianYear).SetMonth(_dateSvc.PersianMonth).AddMonth(1);
                //    //from = to.AddMonth(-takeMonth.Value);
                //}

                var to = PersianInt.Create(_dateSvc.PersianNow.Year, _dateSvc.PersianNow.Month).AddMonth(1);
                var from = to.AddMonth(-takeMonth.Value);

                return new ReportInput
                {
                    From = from,
                    To = to,
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (takeYear.HasValue)
            {
                //if (fromYear.HasValue && false)
                //{
                //    //from.SetYear(fromYear.Value);
                //    //to.SetYear(fromYear.Value).AddYear(takeYear.Value);
                //}
                //else if (toYear.HasValue && false)
                //{
                //    //from.SetYear(toYear.Value).AddYear(-takeYear.Value);
                //    //to.SetYear(toYear.Value);
                //}
                //else
                //{
                //    //to = to.SetYear(_dateSvc.PersianYear).SetMonth(1).AddYear(1);
                //    //from = to.AddYear(-takeYear.Value);
                //}

                var to = PersianInt.Create(_dateSvc.PersianNow.Year).AddYear(1);
                var from = to.AddYear(-takeYear.Value);

                return new ReportInput
                {
                    From = from,
                    To = to,
                    GroupBy = ReportGroupMetric.PersianYear,
                };
            }

            if (fromMonth.HasValue)
            {
                var from = PersianInt.Create(fromYear ?? _dateSvc.PersianNow.Year, fromMonth.Value);
                PersianInt to;

                if (toMonth.HasValue)
                    to = PersianInt.Create(toYear ?? _dateSvc.PersianNow.Year, toMonth.Value);
                else if (toYear.HasValue)
                    to = PersianInt.Create(toYear.Value);
                else
                    //to = PersianInt.Create(_dateSvc.PersianYear, _dateSvc.PersianMonth).AddMonth(1);
                    to = PersianInt.Max;

                return new ReportInput
                {
                    From = from,
                    To = to,
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (fromYear.HasValue)
            {
                var from = PersianInt.Create(fromYear.Value);
                PersianInt to;

                if (toMonth.HasValue)
                    to = PersianInt.Create(toYear ?? _dateSvc.PersianNow.Year, toMonth.Value);
                else if (toYear.HasValue)
                    to = PersianInt.Create(toYear.Value);
                else
                    //to = PersianInt.Create(_dateSvc.PersianYear).AddYear(1);
                    to = PersianInt.Max;

                return new ReportInput
                {
                    From = from,
                    To = to,
                    GroupBy = toMonth.HasValue ? ReportGroupMetric.PersianMonth : ReportGroupMetric.PersianYear,
                };
            }

            if (toMonth.HasValue)
            {
                return new ReportInput
                {
                    From = PersianInt.Min,
                    To = PersianInt.Create(toYear ?? _dateSvc.PersianNow.Year, toMonth.Value),
                    GroupBy = ReportGroupMetric.PersianMonth,
                };
            }

            if (toYear.HasValue)
            {
                return new ReportInput
                {
                    From = PersianInt.Min,
                    To = PersianInt.Create(toYear.Value),
                    GroupBy = ReportGroupMetric.PersianYear,
                };
            }

            return new ReportInput
            {
                From = PersianInt.Min,
                To = PersianInt.Max,
                GroupBy = ReportGroupMetric.PersianYear,
            };
        }
    }
}
