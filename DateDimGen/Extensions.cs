using System;

namespace DateDimGen
{
    public static class Extensions
    {
        public static PersianDate ToPersianDate(this DateTime dateTime)
        {
            return new PersianDate(dateTime);
        }
    }
}
