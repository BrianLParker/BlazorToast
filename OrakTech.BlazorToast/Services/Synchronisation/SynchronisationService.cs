namespace OrakTech.BlazorToast.Services.Synchronisation
{
    using System;
    using System.Threading.Tasks;
    using System.Timers;
    using OrakTech.BlazorToast.Brokers.DateTimes;

    public class SynchronisationService : ISynchronisationService, IDisposable
    {
        private readonly IDateTimeBroker clock;
        private readonly Timer timer;

        public SynchronisationService(IDateTimeBroker dateTimeBroker, double interval = 1000)
        {
            clock = dateTimeBroker;
            timer = new Timer
            {
                Interval = interval,
                AutoReset = true
            };

            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }

        public event Func<DateTimeOffset, ValueTask> SynchroniseAsync;

        public void Dispose()
        {
            timer.Stop();
            timer.Elapsed -= OnTimerElapsed;
            timer.Dispose();
        }

        private async void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (SynchroniseAsync is not null)
            {
                await SynchroniseAsync.Invoke(clock.GetDateTime());
            }
        }
    }
}
