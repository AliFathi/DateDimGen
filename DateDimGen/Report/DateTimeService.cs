using System;
using System.Globalization;

namespace DateDimGen.Report
{
    public class DateTimeService
    {
        private readonly PersianCalendar _pc;

        public DateTimeService()
        {
            _pc = new PersianCalendar();
        }

        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;

        public PersianInt PersianNow => Now.ToPersianInt();

        public PersianInt PersianUtcNow => UtcNow.ToPersianInt();
    }
}
