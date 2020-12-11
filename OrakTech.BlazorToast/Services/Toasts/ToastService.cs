namespace OrakTech.BlazorToast.Services.Toasts
{
    using System;
    using System.Collections.Generic;
    using OrakTech.BlazorToast.Models;

    public class ToastService : IToastService
    {
        List<ToastModel> toastModels;

        public ToastService()
        {
            toastModels = new List<ToastModel>();
        }

        public IReadOnlyList<ToastModel> ToastModels => toastModels;

        public void AddToast(ToastModel toastModel)
        {
            toastModel.Close += ToastModel_Close;
            toastModels.Add(toastModel);
            NotifyListChange();
        }

        public void RemoveToast(ToastModel toastModel)
        {
            toastModel.Close -= ToastModel_Close;
            toastModels.Remove(toastModel);
            NotifyListChange();
        }

        private void ToastModel_Close(object sender, EventArgs e)
        {
            var toast = sender as ToastModel;
            RemoveToast(toast);
        }

        private void NotifyListChange()
        {
            if (ToastModelsChanged is not null)
            {
                ToastModelsChanged.Invoke(this, ToastModels);
            }
        }

        public event EventHandler<IReadOnlyList<ToastModel>> ToastModelsChanged;
    }
}
