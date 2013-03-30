using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Core.Extensions
{
    public static class StringExtensions
    {
        public static DateTime ParseTwitterDateTime(this string date)
        {
            string dayOfWeek = date.Substring(0, 3).Trim();
            string month = date.Substring(4, 3).Trim();
            string dayInMonth = date.Substring(8, 2).Trim();
            string time = date.Substring(11, 9).Trim();
            string offset = date.Substring(20, 5).Trim();
            string year = date.Substring(25, 5).Trim();
            string dateTime = string.Format("{0}-{1}-{2} {3}", dayInMonth, month, year, time);
            return DateTime.Parse(dateTime);
        }
    }
}
