using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ECommerce.Infra.Web
{
    public static class DateConvertor
    {
        public static string PersianDate(PersianCalendar persian,DateTime dateTime)
        {
            var result = $"{persian.GetHour(dateTime).ToString().PadLeft(2,'0')}:{persian.GetMinute(dateTime).ToString().PadLeft(2, '0')}," +
                $" {persian.GetDayOfMonth(dateTime).ToString().PadLeft(2, '0')}/{persian.GetMonth(dateTime).ToString().PadLeft(2, '0')}/{persian.GetYear(dateTime)}";

            return result;
        }
    }
}
