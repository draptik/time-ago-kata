using System;
using FluentAssertions;
using Xunit;

namespace Demo.Tests
{
    public class UnitTests
    {
        private const int oneMinute = 60;
        private const int oneHour = oneMinute * 60;
        private const int oneDay = oneHour * 24;
        private const int oneMonth = oneDay * 30;
        private const int oneYear = oneDay * 365;


        [Theory]
        [InlineData(10, "vor 10 Sekunden")]
        [InlineData(59, "vor 59 Sekunden")]
        [InlineData(oneMinute, "vor einer Minute")]
        [InlineData(61, "vor einer Minute")]
        [InlineData(oneHour - oneMinute, "vor 59 Minuten")]
        [InlineData(oneHour, "vor einer Stunde")]
        [InlineData(oneHour + oneMinute, "vor einer Stunde")]
        [InlineData(oneHour + oneHour, "vor 2 Stunden")]
        [InlineData(oneDay, "Gestern")]
        [InlineData(oneDay + oneMinute, "Gestern")]
        [InlineData(oneDay + oneHour, "Gestern")]
        [InlineData(oneDay + oneDay, "vor 2 Tagen")]
        [InlineData(oneMonth, "vor einem Monat")]
        [InlineData(oneMonth + oneDay, "vor einem Monat")]
        [InlineData(oneMonth + oneMonth, "vor 2 Monaten")]
        [InlineData(oneYear, "vor einem Jahr")]
        public void TimeAgo_returns_correct_result(int secondsToSubstract, string expected)
        {
            DateTime.Now.AddSeconds(-secondsToSubstract).TimeAgo().Should().Be(expected);
        }
    }

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

                if (timeSpan.Days > 30)
                {
                    if (timeSpan.Days / 30 == 1)
                    {
                        result = aMonthAgo;
                    }
                    else
                    {
                        result = $"vor {timeSpan.Days / 30} Monaten";
                    }
                }
                result = aMonthAgo;
            }
            else
            {
                result = timeSpan.Days > 365
                    ? $"vor {timeSpan.Days / 365} Jahren"
                    : "vor einem Jahr";
            }
            return result;
        }
    }
}
