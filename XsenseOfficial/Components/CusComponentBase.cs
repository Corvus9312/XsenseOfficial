using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using XsenseOfficial.Localizers;
using XsenseOfficial.ResourceFiles;

namespace XsenseOfficial.Components;

public class CusComponentBase : ComponentBase
{
    [Inject] public IConfiguration Configuration { get; set; } = null!;

    [Inject] public HttpClient HttpClient { get; set; } = null!;

    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

    [Inject] public NavigationManager Navigator { get; set; } = null!;

    [Inject] public IWebHostEnvironment Environment { get; set; } = null!;

    [Inject] public IStringLocalizer<Multilingual> Localizer { get; set; } = null!;

    [Inject] public MultilingualLocalizer MultilingualLocalizer { get; set; } = null!;

    [Parameter] public string? Language { get; set; }

    public string EnvName => Configuration["Env"] ?? string.Empty;

    public string BackEndUrl => Configuration["BackEndUrl"] ?? string.Empty;
}