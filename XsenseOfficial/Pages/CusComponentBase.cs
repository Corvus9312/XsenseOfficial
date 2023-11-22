using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System.Globalization;
using XsenseOfficial.ResourceFiles;

namespace XsenseOfficial.Pages;

public class CusComponentBase : ComponentBase
{
    [Inject] public IConfiguration Configuration { get; set; } = null!;

    [Inject] public HttpClient HttpClient { get; set; } = null!;

    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

    [Inject] public IStringLocalizer<Resource> Localizer { get; set; } = null!;

    [Inject] public NavigationManager Navigator { get; set; } = null!;

    public string EnvName => Configuration["Env"];

    public string BackEndUrl => Configuration["BackEndUrl"];

    public CultureInfo CultureInfo = null!;

    protected override async Task OnInitializedAsync()
    {
        var result = await JsRuntime.InvokeAsync<string>("blazorCulture.get");
        CultureInfo = string.IsNullOrWhiteSpace(result) ? new CultureInfo("zh-TW") : new CultureInfo(result);
    }
}