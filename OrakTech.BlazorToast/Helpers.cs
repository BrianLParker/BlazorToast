namespace OrakTech.BlazorToast
{
    using Microsoft.Extensions.DependencyInjection;
    using ModelToComponentMapper.Models.ViewSelectorModels;
    using OrakTech.BlazorToast.Brokers.DateTimes;
    using OrakTech.BlazorToast.Models;
    using OrakTech.BlazorToast.Services.Synchronisation;
    using OrakTech.BlazorToast.Services.Toasts;
    using OrakTech.BlazorToast.Views.Components;

    public static class Helpers
    {
        public static void AddToastServices(this IServiceCollection services)
        {
            services.AddScoped<IViewSelector>(sp =>
            {
                var viewModelComponentSelector = new ViewModelComponentSelector();
                viewModelComponentSelector.RegisterDefaults();
                viewModelComponentSelector.RegisterView<ToastModel, ToastView>();
                return viewModelComponentSelector;
            });
            services.AddScoped<IDateTimeBroker, DateTimeBroker>();
            services.AddScoped<ISynchronisationService, SynchronisationService>();
            services.AddScoped<IToastService, ToastService>();
        }
    }
}
