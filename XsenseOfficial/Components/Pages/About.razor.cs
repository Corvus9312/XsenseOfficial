using System.Globalization;
using System.Text.Json;
using XsenseOfficial.ViewModels;
using XsenseOfficial_Admin.ViewModels;

namespace XsenseOfficial.Components.Pages;

public class AboutBase : CusComponentBase
{
    public string ProfileHtml { get; set; } = string.Empty;

    public string VisionImgUrl => $"/images/about/Vision.{Language}.png";

    public string CompetenceHtml { get; set; } = string.Empty;

    public List<MileStoneVM> MileStones { get; set; } = [];

    public string QualityImgUrl => $"/images/about/Quality.{Language}.png";

    public List<SidebarVM> Sidebars { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        // Timeline sample: https://codepen.io/brady_wright/pen/NNOvrW

        SetSidebarList();

        var fileFolder = Path.Combine(Environment.ContentRootPath, "Templates", "Abouts");

        ProfileHtml = File.ReadAllText(Path.Combine(fileFolder, $"Profile.{Language}.html"));
        
        CompetenceHtml = File.ReadAllText(Path.Combine(fileFolder, $"Competence.{Language}.html"));

        var mileStone = File.ReadAllText(Path.Combine(fileFolder, $"MileStones.{Language}.json"));
        MileStones = JsonSerializer.Deserialize<List<MileStoneVM>>(mileStone) ?? [];
    }

    private void SetSidebarList()
    {
        Sidebars =
            [
                new()
                {
                    Title = Localizer["公司介紹"],
                    Href = "javascript:BlazorScrollToId('profile')"
                },
                new()
                {
                    Title = Localizer["核心競爭力"],
                    Href = "javascript:BlazorScrollToId('competence')",
                },
                new()
                {
                    Title = Localizer["里程碑"],
                    Href = "javascript:BlazorScrollToId('milestone')",
                },
                new()
                {
                    Title = Localizer["品質政策"],
                    Href = "javascript:BlazorScrollToId('quality')",
                },
                new()
                {
                    Title = Localizer["相關證照"],
                    Href = "javascript:BlazorScrollToId('sgs')",
                }
            ];
    }
}