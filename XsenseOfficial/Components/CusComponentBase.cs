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
}