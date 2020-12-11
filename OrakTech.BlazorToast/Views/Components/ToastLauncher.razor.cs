namespace OrakTech.BlazorToast.Views.Components
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;
    using ModelToComponentMapper.Models.Elements;
    using OrakTech.BlazorToast.Models;
    using OrakTech.BlazorToast.Services.Toasts;

    public partial class ToastLauncher : ComponentBase
    {
        protected override void OnInitialized()
        {
            ToastService.ToastModelsChanged += ToastModelsChanged;
            base.OnInitialized();
        }

        private void ToastModelsChanged(object sender, IReadOnlyList<ToastModel> e)
        {
            InvokeAsync(StateHasChanged);
        }

        [Inject]
        IToastService ToastService { get; set; }


    }
}
