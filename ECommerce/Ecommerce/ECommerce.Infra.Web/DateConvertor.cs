using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ECommerce.Infra.Web
{
    public static class DateConvertor
    {
        public static string PersianDate(this PersianCalendar persian,DateTime dateTime)
        {
            TimeSpan time = dateTime.ToLocalTime() - dateTime;
            DateTime thistime = dateTime.AddMinutes(time.TotalMinutes);
            var result = $"{persian.GetHour(thistime).ToString().PadLeft(2,'0')}:{persian.GetMinute(thistime).ToString().PadLeft(2, '0')}," +
                $" {persian.GetDayOfMonth(thistime).ToString().PadLeft(2, '0')}/{persian.GetMonth(thistime).ToString().PadLeft(2, '0')}/{persian.GetYear(thistime)}";

            return result;
        }
    }
}
