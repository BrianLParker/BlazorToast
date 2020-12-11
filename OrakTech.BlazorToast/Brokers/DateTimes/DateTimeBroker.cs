namespace OrakTech.BlazorToast.Brokers.DateTimes
{
    using System;

    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset GetDateTime() => DateTimeOffset.Now;
    }
}
