using System.Text.Json;
using XsenseOfficial.Models;
using XsenseOfficial.ViewModels;

namespace XsenseOfficial.Components.Pages;

public class ProductBase : CusComponentBase
{
    protected List<PorductCategoryVM> ProductCategorys { get; set; } = null!;

    protected List<SidebarVM> Sidebars { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var fileFolder = Path.Combine(Environment.ContentRootPath, "Templates", "Products");

        var productJson = File.ReadAllText(Path.Combine(fileFolder, $"Product.{Language}.json"));
        ProductCategorys = JsonSerializer.Deserialize<List<PorductCategoryVM>>(productJson) ?? [];

        SetSideBar();
    }

    private void SetSideBar()
    {
        Sidebars.Add(new() { Title = "top", Disabled = false, Href = $"/{Language}/product" });

        Sidebars.AddRange(
            ProductCategorys
            .Select(
                x => new SidebarVM
                {
                    Title = x.Name,
                    Disabled = true,
                    SubSidebars = x.Products.Select(x => new SidebarModel { Title = x.SideBarName, Href = x.Uri }).ToList()
                }).ToList()
        );
    }
}