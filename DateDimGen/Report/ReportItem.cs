namespace DateDimGen.Report
{
    public class ReportInput
    {
        public System.DateTime? From { get; set; }

        public System.DateTime? To { get; set; }

        public ReportGroupMetric GroupBy { get; set; }

        public bool IsValid => From <= To;
    }

    public class ReportItem<TValue> : System.IEquatable<ReportItem<TValue>>
    {
        public int Key { get; set; }

        public TValue Value { get; set; }

        public int Day { get; set; }

        public string DayName { get; set; }

        public int Month { get; set; }

        public string MonthName { get; set; }

        public int Year { get; set; }

        public bool Equals(ReportItem<TValue> other)
        {
            return Key.Equals(other.Key);
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }

    public enum ReportGroupMetric
    {
        Default,

        Day,

        Week,

        Month,

        Quarter,

        Year,

        PersianDay,

        PersianWeek,

        PersianMonth,

        PersianQuarter,

        PersianYear,
    }
}
