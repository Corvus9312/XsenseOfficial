using Microsoft.AspNetCore.Components;
using Xsense_Front_End.Pages;
using XsenseOfficial.ViewModels;
using static XsenseOfficial.Enums;

namespace XsenseOfficial.Pages;

public class ProductBase : CusComponentBase
{
    [Parameter]
    public int? TypeID
    {
        get
        {
            return TypeID;
        }
        set
        {
            ProductType = (ProductType)value.GetValueOrDefault();
        }
    }

    public ProductType ProductType { get; set; }

    public PorductVM ProductVM { get; set; } = new();

    public List<SidebarVM> Sidebars { get; set; } = new();

    public string PageTitle { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        PageTitle = $"{Localizer["艾格生科技"]} - {Localizer["產品"]}";

        await BuildData();

        SetSidebarList();
    }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        await BuildData();
    }

    private async Task BuildData()
    {
        ProductVM = new();

        switch (ProductType)
        {
            case ProductType.SubMount:
                PageTitle = $"{Localizer["艾格生科技"]} - {ProductType.SubMount}";
                break;
            case ProductType.邊射型雷射用:
                PageTitle = $"{Localizer["艾格生科技"]} - {ProductType.邊射型雷射用}";
                ProductVM.Title = ProductType.邊射型雷射用.ToString();
                ProductVM.Content = (await HttpClient.GetStringAsync(Path.Combine(Navigator.BaseUri, "templates", "product", "SubMount", $"MetalEdgeEmittingLaserSubMount.{CultureInfo.Name}.html"))).Replace("{{BaseUri}}", Navigator.BaseUri);
                break;
            case ProductType.高頻元件用:
                PageTitle = $"{Localizer["艾格生科技"]} - {ProductType.高頻元件用}";
                ProductVM.Title = ProductType.高頻元件用.ToString();
                ProductVM.Content = (await HttpClient.GetStringAsync(Path.Combine(Navigator.BaseUri, "templates", "product", "SubMount", $"HighFrequencyDeviceSubMount.{CultureInfo.Name}.html"))).Replace("{{BaseUri}}", Navigator.BaseUri);
                break;
            case ProductType.Foundry:
                PageTitle = $"{Localizer["艾格生科技"]} - {ProductType.Foundry}";
                break;
            case ProductType.金錫合金鍍膜:
                PageTitle = $"{Localizer["艾格生科技"]} - {ProductType.金錫合金鍍膜}";
                ProductVM.Title = "金錫合金鍍膜 (AuSn)";
                ProductVM.Content = (await HttpClient.GetStringAsync(Path.Combine(Navigator.BaseUri, "templates", "product", "FoundryService", $"1.{CultureInfo.Name}.html"))).Replace("{{BaseUri}}", Navigator.BaseUri);
                break;
            case ProductType.薄膜金屬化加工:
                PageTitle = $"{Localizer["艾格生科技"]} - {ProductType.薄膜金屬化加工}";
                ProductVM.Title = "薄膜金屬化加工(Ni , Au, Pt…)";
                ProductVM.Content = (await HttpClient.GetStringAsync(Path.Combine(Navigator.BaseUri, "templates", "product", "FoundryService", $"3.{CultureInfo.Name}.html"))).Replace("{{BaseUri}}", Navigator.BaseUri);
                break;
            case ProductType.黃光_蝕刻製程:
                PageTitle = $"{Localizer["艾格生科技"]} - {ProductType.黃光_蝕刻製程}";
                ProductVM.Title = "黃光.蝕刻製程: (Wafer size : 4”~8”)";
                ProductVM.Content = (await HttpClient.GetStringAsync(Path.Combine(Navigator.BaseUri, "templates", "product", "FoundryService", $"2.{CultureInfo.Name}.html"))).Replace("{{BaseUri}}", Navigator.BaseUri);
                break;
            default:
                break;
        }

        StateHasChanged();
    }

    private void SetSidebarList()
    {
        Sidebars =
            new()
            {
                new ()
                {
                    Title = Localizer["散熱基板"],
                    Href = "/Product/0",
                    Disabled = true,
                    SubSidebars = new()
                    {
                        new()
                        {
                            Title = Localizer["邊射型雷射用"],
                            Href = "/Product/1"
                        },
                        new()
                        {
                            Title = Localizer["高頻元件用"],
                            Href = "/Product/2"
                        }
                    }
                },
                new ()
                {
                    Title = Localizer["代工服務"],
                    Href = "/Product/3",
                    Disabled = true,
                    SubSidebars = new()
                    {
                        new()
                        {
                            Title = Localizer["金錫合金鍍膜"],
                            Href = "/Product/4"
                        },
                        new()
                        {
                            Title = Localizer["薄膜金屬化加工"],
                            Href = "/Product/5"
                        },
                        new()
                        {
                            Title = Localizer["黃光.蝕刻製程加工"],
                            Href = "/Product/6"
                        }
                    }
                }
            };
    }
}