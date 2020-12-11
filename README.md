# BlazorToast

Enable Bootstraps toast popups in blazor

`Startup.cs`
```
using OrakTech.BlazorToast;
...
services.AddToastServices();
```

`Program.cs`
```
using OrakTech.BlazorToast;
...
builder.Services.AddToastServices();
```

`_Imports.razor`
```
@using OrakTech.BlazorToast
@using OrakTech.BlazorToast.Models
@using OrakTech.BlazorToast.Views.Components
@using OrakTech.BlazorToast.Services.Toasts
```

### Example Usage
```
<button @onclick="Launch">Pop</button>

@code {

    [Inject]
    public IToastService toaster { get; set; }

    void Launch()
    {
        toaster.AddToast(toast);
    }

    ToastModel toast => new ToastModel
    {
        Title = "Demonstration",
        Content = "Hello",
        IconColor = "red"
    };
}
```
