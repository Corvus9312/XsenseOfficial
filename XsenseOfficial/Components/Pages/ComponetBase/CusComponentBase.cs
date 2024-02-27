using HtmlAgilityPack;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using XsenseOfficial.Localizers;
using XsenseOfficial.ResourceFiles;

namespace XsenseOfficial.Components.Pages.ComponetBase;

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

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        if (!string.IsNullOrWhiteSpace(Language) &&
            MultilingualLocalizer.SupportedCultures.Any(x => x.Culture.Name.Equals(Language))
        )
        {
            _ = MultilingualLocalizer.SetCulture(new(Language));
        }
        else
        {
            var culture = MultilingualLocalizer.SetCulture();

            Language = culture.Name;
        }

        StateHasChanged();
    }

    public string ReplaceHtmlTag(string descHtml)
    {
        HtmlDocument doc = new();
        doc.LoadHtml(descHtml);

        return doc.DocumentNode.InnerText
            .Replace("\n", "")
            .Replace("\r", "")
            .Replace("\t", "")
            .Replace(" ", "");
    }
}