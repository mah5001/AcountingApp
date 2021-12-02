using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace System
{
    public static class Convertor
    {
        public static string ToShamsi(this DateTime date)
        {
PersianCalendar p = new PersianCalendar();
            return string.Format("{0:0000}/{1:00}/{2:00}",
                    p.GetYear(date),
                    p.GetMonth(date),
                    p.GetDayOfMonth(date));
        }

        public static string ToRial(this int value)
        {
            return value.ToString("#,0 ریال");
        }

        public static DateTime ToDateTime(this string value)
        {
            var res = Convert.ToDateTime(value);
            return res.ToMiladi();
        }

        public static DateTime ToMiladi(this DateTime value)
        {
            return new DateTime(value.Year,value.Month,value.Day,value.Hour,value.Minute,value.Second, new System.Globalization.PersianCalendar());
        }
       
    }
}
