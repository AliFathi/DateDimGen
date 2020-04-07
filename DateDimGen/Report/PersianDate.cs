using System.Globalization;

namespace DateDimGen.Report
{
    public readonly struct PersianDate
    {
        /// <summary>
        /// Represents the smallest possible value of <see cref="PersianDate"/>, which is 0001/01/01 (1/01/01)
        /// </summary>
        public static readonly PersianDate Min = new PersianDate(1, 1, 1);

        /// <summary>
        /// Represents the largest possible value of <see cref="PersianDate"/>, which is 9378/10/13 (9378/10/13)
        /// </summary>
        public static readonly PersianDate Max = new PersianDate(9378, 10, 13);

        public readonly System.DateTime _date;
        public readonly PersianCalendar _pc;

        public PersianDate(int year, int month = 1, int day = 1)
        {
            _pc = new PersianCalendar();
            _date = _pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            Day = day;
            Month = month;
            Year = year;
        }

        public PersianDate(System.DateTime date)
        {
            _pc = new PersianCalendar();
            _date = date;
            Day = _pc.GetDayOfMonth(date);
            Month = _pc.GetMonth(date);
            Year = _pc.GetYear(date);
        }

        public static PersianDate Now => new PersianDate(System.DateTime.Now);

        public static PersianDate UtcNow => new PersianDate(System.DateTime.UtcNow);

        public static PersianDate Today => new PersianDate(System.DateTime.Today);

        public int Day { get; }

        public int Month { get; }

        public int Year { get; }

        public PersianDate AddDays(int days)
        {
            return new PersianDate(_pc.AddDays(_date, days));
        }

        public PersianDate AddMonths(int months)
        {
            return new PersianDate(_pc.AddMonths(_date, months));
        }

        public PersianDate AddYears(int years)
        {
            return new PersianDate(_pc.AddYears(_date, years));
        }

        public System.DateTime ToDateTime()
        {
            return _date;
        }

        public int ToInt()
        {
            return (Year * 10000) + (Month * 100) + Day;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is PersianDate that)
                return this.ToInt().Equals(that.ToInt());

            return false;
        }

        public override int GetHashCode()
        {
            return this.ToInt().GetHashCode();
        }

        public override string ToString()
        {
            return ToString(separator: '-');
        }

        public string ToString(char separator)
        {
            return $"{Year,4}{separator}{Month,2:00}{separator}{Day,2:00}";
        }

        public static bool operator ==(PersianDate a, PersianDate b)
        {
            return a.ToInt() == b.ToInt();
        }

        public static bool operator !=(PersianDate a, PersianDate b)
        {
            return a.ToInt() != b.ToInt();
        }

        public static bool operator >(PersianDate a, PersianDate b)
        {
            return a.ToInt() > b.ToInt();
        }

        public static bool operator >=(PersianDate a, PersianDate b)
        {
            return a.ToInt() >= b.ToInt();
        }

        public static bool operator <(PersianDate a, PersianDate b)
        {
            return a.ToInt() < b.ToInt();
        }

        public static bool operator <=(PersianDate a, PersianDate b)
        {
            return a.ToInt() <= b.ToInt();
        }
    }
}
