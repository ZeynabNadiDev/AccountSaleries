using System.Globalization;

namespace Salary.Application.Helper
{
    public static class PersianDate
    {
        public static DateTime ParsePersianDate(string persianDate)
        {
            var year = int.Parse(persianDate.Substring(0, 4));
            var month = int.Parse(persianDate.Substring(4, 2));
            var day = int.Parse(persianDate.Substring(6, 2));

            return new PersianCalendar().ToDateTime(year, month, day, 0, 0, 0, 0);
        }

    }
}
