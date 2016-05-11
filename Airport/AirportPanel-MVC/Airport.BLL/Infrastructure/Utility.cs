
namespace Airport.BLL.Infrastructure
{
    using System;

    public static class Utility
    {
        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static int? CheckForNull(this int? id)
        {
            if (id == null)
                throw new ValidationException("id is null.", "");
            return id;
        }
        public static T CheckForNull<T>(this T item)
        {
            if (item == null)
                throw new ValidationException("item not found.", "");
            return item;
        }
    }
}
