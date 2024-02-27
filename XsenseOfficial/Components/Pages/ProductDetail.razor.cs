using Microsoft.AspNetCore.Components;
using static XsenseOfficial.Enums;
using XsenseOfficial.ViewModels;
using System.Globalization;
using System.Text.Json;
using XsenseOfficial.Models;
using System.Xml;
using HtmlAgilityPack;

namespace XsenseOfficial.Components.Pages;

public class ProductDetailBase : CusComponentBase
{
    [Parameter]
    public int? TypeID { get; set; }

    public ProductType ProductType
    {
        get
        {
            return TypeID is null ? ProductType.邊射型雷射用 : (ProductType)TypeID.GetValueOrDefault();
        }
    }

    protected PorductDetailVM ProductVM { get; set; } = new();

    protected List<SidebarVM> Sidebars { get; set; } = [];

    protected List<PorductCategoryVM> Categorys { get; set; } = null!;

    protected PorductCategoryVM Category { get; set; } = null!;

    protected PorductVM Product { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        BuildData();

        SetSideBar();
    }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        BuildData();
    }

    private void BuildData()
    {
        var fileFolder = Path.Combine(Environment.ContentRootPath, "Templates", "Products");

        var productJson = File.ReadAllText(Path.Combine(fileFolder, $"Product.{Language}.json"));

        Categorys = JsonSerializer.Deserialize<List<PorductCategoryVM>>(productJson) ?? [];

        Category = Categorys?.Single(x => x.Products.Select(x => x.Serial).Contains(TypeID ?? 0)) ?? new();

        Product = Category.Products.Single(x => x.Serial.Equals(TypeID)) ?? new();
        var a = Path.Combine(fileFolder, Category.Category, $"{Product.Name}.{Language}.html");
        ProductVM = new()
        {
            Title = Product.ProductName,
            Content = File.ReadAllText(Path.Combine(fileFolder, Category.Category, $"{Product.Name}.{Language}.html"))
        };

        StateHasChanged();
    }

    private void SetSideBar()
    {
        Sidebars.Add(new() { Title = "top", Disabled = false, Href = $"/{Language}/product" });

        Sidebars.AddRange(
            Categorys
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
