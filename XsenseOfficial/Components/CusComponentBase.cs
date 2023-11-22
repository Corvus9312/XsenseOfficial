using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace XsenseOfficial.Components;

public class CusComponentBase : ComponentBase
{
    [Inject] public IConfiguration Configuration { get; set; } = null!;

    [Inject] public HttpClient HttpClient { get; set; } = null!;

    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

    [Inject] public NavigationManager Navigator { get; set; } = null!;

    [Inject] public IWebHostEnvironment Environment { get; set; } = null!;

    public string EnvName => Configuration["Env"] ?? string.Empty;

    public string BackEndUrl => Configuration["BackEndUrl"] ?? string.Empty;

    public CultureInfo CultureInfo = new("zh-TW");

    //protected override async Task OnInitializedAsync()
    //{
    //    var result = await JsRuntime.InvokeAsync<string>("blazorCulture.get");
    //    CultureInfo = string.IsNullOrWhiteSpace(result) ? new CultureInfo("zh-TW") : new CultureInfo(result);
    //}
}