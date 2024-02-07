using System.Globalization;
using System.Text.Json;
using XsenseOfficial.ViewModels;

namespace XsenseOfficial.Components.Pages;

public class ProductBase : CusComponentBase
{
    protected List<PorductCategoryVM> ProductCategorys { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var fileFolder = Path.Combine(Environment.ContentRootPath, "Templates", "Products");

        var productJson = File.ReadAllText(Path.Combine(fileFolder, $"Product.{Language}.json"));
        ProductCategorys = JsonSerializer.Deserialize<List<PorductCategoryVM>>(productJson) ?? [];
    }
}