namespace DateDimGen.Report
{
    public class ReportInput
    {
        public PersianInt From { get; set; }

        public PersianInt To { get; set; }

        public ReportGroupMetric GroupBy { get; set; }

        public bool IsValid => From <= To;

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
