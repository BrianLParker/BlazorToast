namespace OrakTech.BlazorToast.Views.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using OrakTech.BlazorToast.Brokers.DateTimes;
    using OrakTech.BlazorToast.Services.Synchronisation;

    public partial class TimeAgo : ComponentBase, IDisposable
    {
        [Inject]
        ISynchronisationService Synchronisation { get; set; }

        [Inject]
        IDateTimeBroker Clock { get; set; }

        [Parameter]
        public DateTimeOffset StartTime { get; set; }

        protected override void OnInitialized()
        {
            if (StartTime == default)
            {
                StartTime = Clock.GetDateTime();
            }
            Display = GetDisplayText(Clock.GetDateTime());
            Synchronisation.SynchroniseAsync += OnSynchronisation;
            base.OnInitialized();
        }

        private async ValueTask OnSynchronisation(DateTimeOffset when)
        {
            await InvokeAsync(() =>
            {
                var display = GetDisplayText(when);
                if (Display != display)
                {
                    Display = display;
                    StateHasChanged();
                }
            });

        }

        public string Display { get; set; }

        private string GetDisplayText(DateTimeOffset when)
        {
            var duration = when - StartTime;
            var suffix = "";
            double quantity = 0;
            if (duration >= TimeSpan.FromHours(1))
            {
                quantity = Math.Floor(duration.TotalHours);
                suffix = "hour" + (quantity > 1 ? "s" : "");
            }
            else
            {
                if (duration >= TimeSpan.FromMinutes(1))
                {
                    quantity = duration.Minutes;
                    suffix = "minute" + (quantity > 1 ? "s" : "");
                }
                else
                {
                    if (duration >= TimeSpan.FromSeconds(5))
                    {
                        quantity = duration.Seconds;
                        suffix = "seconds";
                    }
                    else
                    {
                        return "just then";
                    }
                }
            }
            return $"{quantity} {suffix} ago";
        }

        public void Dispose()
        {
            Synchronisation.SynchroniseAsync -= OnSynchronisation;
        }
    }
}
