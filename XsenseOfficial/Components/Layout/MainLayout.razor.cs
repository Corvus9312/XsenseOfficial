using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace XsenseOfficial.Shared;

public class MainLayoutBase : LayoutComponentBase
{
    [Inject] public NavigationManager Nav { get; set; } = null!;

    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

    public bool IsLoadCompleted = false;

    public List<CultureInfo> SupportedCultures { get; set; } =
        [ 
            new CultureInfo("zh-TW"),
            new CultureInfo("zh-CN"), 
            new CultureInfo("en-US") 
        ];

    public CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var js = (IJSInProcessRuntime)JsRuntime;
                js.InvokeVoid("blazorCulture.set", value.Name);
                var url = Nav.Uri.Contains('#') ? Nav.Uri.Remove(Nav.Uri.IndexOf('#')) : Nav.Uri;
                Nav.NavigateTo(url, true);
            }
        }
    }

    protected override void OnInitialized()
    {
        IsLoadCompleted = true;
    }
}
