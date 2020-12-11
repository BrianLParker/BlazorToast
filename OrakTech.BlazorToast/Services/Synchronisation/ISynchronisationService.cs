namespace OrakTech.BlazorToast.Services.Synchronisation
{
    using System;
    using System.Threading.Tasks;

    public interface ISynchronisationService
    {
        event Func<DateTimeOffset, ValueTask> SynchroniseAsync;
    }
}
