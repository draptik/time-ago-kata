using System;

namespace Demo.Tests
{
    public static class Ext
    {
        public static string TimeAgo(this DateTime dateTime)
        {
            string result;
            var timeSpan = DateTime.Now.Subtract(dateTime);
            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = $"vor {Math.Floor(timeSpan.TotalSeconds)} Sekunden";
            }

            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1
                    ? $"vor {timeSpan.Minutes} Minuten"
                    : "vor einer Minute";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1
                    ? $"vor {timeSpan.Hours} Stunden"
                    : "vor einer Stunde";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1
                    ? $"vor {timeSpan.Days} Tagen"
                    : "Gestern";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                const string aMonthAgo = "vor einem Monat";
                var isSingleMonth = (timeSpan.Days / 30) == 1;
                result = timeSpan.Days > 30
                    ? isSingleMonth ? aMonthAgo : $"vor {timeSpan.Days / 30} Monaten"
                    : aMonthAgo;
            }
            else
            {
                const string aYearAgo = "vor einem Jahr";
                var isSingleYear = (timeSpan.Days / 365) == 1;
                result = timeSpan.Days > 365
                    ? isSingleYear ? aYearAgo : $"vor {timeSpan.Days / 365} Jahren"
                    : aYearAgo;
            }
            return result;
        }
    }
}