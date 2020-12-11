namespace OrakTech.BlazorToast.Services.Toasts
{
    using System;
    using System.Collections.Generic;
    using OrakTech.BlazorToast.Models;

    public interface IToastService
    {
        IReadOnlyList<ToastModel> ToastModels { get; }

        event EventHandler<IReadOnlyList<ToastModel>> ToastModelsChanged;

        void AddToast(ToastModel toastModel);
        void RemoveToast(ToastModel toastModel);
    }
}
