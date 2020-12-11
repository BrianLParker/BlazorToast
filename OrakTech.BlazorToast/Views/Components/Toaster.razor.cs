namespace OrakTech.BlazorToast.Views.Components
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using Microsoft.AspNetCore.Components;
    using ModelToComponentMapper.Models.Elements;
    using OrakTech.BlazorToast.Models;
    using OrakTech.BlazorToast.Services.Toasts;

    public partial class Toaster : ComponentBase
    {
        [Inject]
        IToastService ToastService { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public ToastModel Toast { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditionalAttributes { get; set; }

        void PopClick()
        {
            if (Toast is not null)
            {
                Toast.Id = Guid.NewGuid().ToString();
                ToastService.AddToast(Toast);
            }
        }
    }
}
