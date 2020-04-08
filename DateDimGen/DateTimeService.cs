using System;

namespace DateDimGen
{
    public class DateTimeService
    {
        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;

        public PersianDate PersianNow => Now.ToPersianDate();

        public PersianDate PersianUtcNow => UtcNow.ToPersianDate();
    }
}
