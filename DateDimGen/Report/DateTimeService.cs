using System;

namespace DateDimGen.Report
{
    public class DateTimeService
    {
        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;

        public PersianDate PersianNow => Now.ToPersianDate();

        public PersianDate PersianUtcNow => UtcNow.ToPersianDate();
    }
}
