using System.Globalization;
using System.Text.Json;
using XsenseOfficial.Components.Pages.ComponetBase;
using XsenseOfficial.ViewModels;

namespace XsenseOfficial.Components.Pages;

public class EnterpriseSustainableBase : CusComponentBase
{
    protected string ManagePolicy { get; set; } = null!;

    protected string ConflictMetal { get; set; } = null!;

    protected string SupplierManagement { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var fileFolder = Path.Combine(Environment.ContentRootPath, "Templates", "EnterpriseSustainables");

        ManagePolicy = File.ReadAllText(Path.Combine(fileFolder, $"ManagePolicy.{Language}.html"));
        ConflictMetal = File.ReadAllText(Path.Combine(fileFolder, $"ConflictMetal.{Language}.html"));
        SupplierManagement = File.ReadAllText(Path.Combine(fileFolder, $"SupplierManagement.{Language}.html"));
    }
}