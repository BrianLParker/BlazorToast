namespace OrakTech.BlazorToast.Views.Components
{
    using ModelToComponentMapper;
    using OrakTech.BlazorToast.Models;

    public partial class ToastView : ViewComponentBase<ToastModel>
    {
        void CloseClick() => Model.CloseClick();
        public string Id => Model.Id;

        public string IconColor => Model.IconColor ?? "#007aff";
    }
}
