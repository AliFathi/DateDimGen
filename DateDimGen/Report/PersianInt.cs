namespace DateDimGen.Report
{
    public struct PersianInt
    {
        public PersianInt(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        /// <summary>
        /// Represents the smallest possible value of <see cref="PersianInt"/>, which is 10101 (1/01/01)
        /// </summary>
        public static readonly PersianInt Min = new PersianInt(1, 1, 1);

        /// <summary>
        /// Represents the largest possible value of <see cref="PersianInt"/>, which is 93781013 (9378/10/13)
        /// </summary>
        public static readonly PersianInt Max = new PersianInt(9378, 10, 13);

        public static PersianInt Create(int year, int month = 1, int day = 1) => new PersianInt(year, month, day);

        public int Day { get; }

        public int Month { get; }

        public int Year { get; }

        public PersianInt AddMonth(int value)
        {
            if (value > 0)
            {
                var newMonthIndex = this.Month + value;
                var newMonth = newMonthIndex % 12;
                var years = (newMonthIndex - newMonth) / 12;

                return this.AddYear(years).SetMonth(newMonth);
            }
            else
            {
                var inverseMonth = Inverse(this.Month);
                var newMonthIndex = inverseMonth - value;
                var newMonth = newMonthIndex % 12;
                var inverseNewMonth = Inverse(newMonth);
                var years = (newMonthIndex - newMonth) / 12;

                return this.AddYear(-years).SetMonth(inverseNewMonth);
            }
        }

        public PersianInt AddYear(int value) => new PersianInt(Year + value, Month, Day);

        public PersianInt SetDay(int day) => new PersianInt(Year, Month, day);

        public PersianInt SetMonth(int month) => new PersianInt(Year, month, Day);

        public PersianInt SetYear(int year) => new PersianInt(year, Month, Day);

        public int ToInt()
        {
            return (Year * 10000) + (Month * 100) + Day;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is PersianInt that)
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
            return Year.ToString().PadLeft(4) + separator
               + Month.ToString().PadLeft(2, '0') + separator
               + Day.ToString().PadLeft(2, '0');
        }

        public static bool operator ==(PersianInt a, PersianInt b)
        {
            return a.ToInt() == b.ToInt();
        }

        public static bool operator !=(PersianInt a, PersianInt b)
        {
            return a.ToInt() != b.ToInt();
        }

        private int Inverse(int value)
        {
            return 13 - value;
        }
    }
}
