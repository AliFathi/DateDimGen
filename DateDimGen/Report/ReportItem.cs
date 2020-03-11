namespace DateDimGen.Report
{
    public class ReportInput
    {
        public PersianInt From { get; set; }

        public PersianInt To { get; set; }

        public int FromPersianDateInt => From.ToInt();

        public int ToPersianDateInt => To.ToInt();

        public ReportGroupMetric GroupBy { get; set; }

        public bool IsValid => ToPersianDateInt >= FromPersianDateInt;

        public override string ToString()
        {
            return $"[{From}, {To}) group by {GroupBy} (valid: {IsValid})";
        }
    }

    public class ReportItem<TValue>
    {
        public int Key { get; set; }

        public string Label { get; set; }

        public TValue Value { get; set; }
    }

    public class CountReportItem<TValue>
    {
        public int Key { get; set; }

        public TValue Value { get; set; }

        public int Day { get; set; }

        public string DayName { get; set; }

        public int Month { get; set; }

        public string MonthName { get; set; }

        public int Year { get; set; }
    }

    public enum ReportGroupMetric
    {
        Default,
        PersianDay,
        PersianMonth,
        PersianYear,
    }
}
