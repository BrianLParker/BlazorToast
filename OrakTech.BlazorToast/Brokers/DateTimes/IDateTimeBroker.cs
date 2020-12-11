namespace OrakTech.BlazorToast.Brokers.DateTimes
{
    using System;

    public interface IDateTimeBroker
    {
        DateTimeOffset GetDateTime();
    }
}
