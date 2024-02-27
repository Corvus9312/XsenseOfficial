using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System.Globalization;
using XsenseOfficial.Localizers;
using XsenseOfficial.ResourceFiles;

namespace XsenseOfficial.Shared;

public class MainLayoutBase : LayoutComponentBase
{
    [Inject] public NavigationManager Nav { get; set; } = null!;

    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

    [Inject] public MultilingualLocalizer MultilingualLocalizer { get; set; } = null!;

    [Inject] public IStringLocalizer<Multilingual> Localizer { get; set; } = null!;

    public bool IsLoadCompleted = false;

    public CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var uri = new Uri(Nav.Uri);
                var lang = uri.Segments[1].Replace("/", "");

                var url = $"{uri}".Replace(lang, value.Name);
                Nav.NavigateTo(url, true);
            }
        }
    }

    protected override void OnInitialized()
    {
        IsLoadCompleted = true;
    }
}