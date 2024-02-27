using XsenseOfficial.Components.Pages.ComponetBase;

namespace XsenseOfficial.Components.Pages;

public class JoinUsBase : CusComponentBase
{
    protected string TrainingImageUrl => $"/images/joinUs/PersonnelTraining.{Language}.webp";

    protected string EnviromentHtml { get; set; } = string.Empty;

    protected string WelfareHtml { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var fileFolder = Path.Combine(Environment.ContentRootPath, "Templates", "JoinUs");

        EnviromentHtml = File.ReadAllText(Path.Combine(fileFolder, $"Environment.{Language}.html"));

        WelfareHtml = File.ReadAllText(Path.Combine(fileFolder, $"Welfare.{Language}.html"));
    }
}
