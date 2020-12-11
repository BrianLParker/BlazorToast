namespace OrakTech.BlazorToast.Models
{
    using System;

    public class ToastModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string IconColor { get; set; }
        public string ImageSource { get; set; }
        public string ImageAlt { get; set; }
        public string Title { get; set; }
        public object Content { get; set; }
        public event EventHandler Close;
        public void CloseClick() => Close?.Invoke(this, default);
    }
}
