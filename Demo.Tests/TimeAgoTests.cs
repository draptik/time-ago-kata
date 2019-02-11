using System;
using FluentAssertions;
using Xunit;

namespace Demo.Tests
{
    public class TimeAgoTests
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
        [InlineData(oneMonth *3, "vor 3 Monaten")]
        [InlineData(oneYear, "vor einem Jahr")]
        [InlineData(oneYear + oneMonth, "vor einem Jahr")]
        [InlineData(oneYear * 2, "vor 2 Jahren")]
        public void TimeAgo_returns_correct_result(int secondsToSubstract, string expected)
        {
            DateTime.Now.AddSeconds(-secondsToSubstract).TimeAgo().Should().Be(expected);
        }
    }
}
