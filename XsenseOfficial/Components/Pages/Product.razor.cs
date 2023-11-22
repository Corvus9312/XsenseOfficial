using Microsoft.AspNetCore.Components;
using XsenseOfficial.ViewModels;
using static XsenseOfficial.Enums;

namespace XsenseOfficial.Components.Pages;

public class ProductBase : CusComponentBase
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

    public PorductVM ProductVM { get; set; } = new();

    public List<SidebarVM> Sidebars { get; set; } = new();

    public string PageTitle { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        PageTitle = $"艾格生科技 - 產品";

        BuildData();

        SetSidebarList();
    }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        BuildData();
    }

    private void BuildData()
    {
        ProductVM = new();

        var fileFolder = Path.Combine(Environment.ContentRootPath, "Templates", "Products");

        switch (ProductType)
        {
            case ProductType.SubMount:
                PageTitle = $"艾格生科技 - {ProductType.SubMount}";
                break;
            case ProductType.邊射型雷射用:
                PageTitle = $"艾格生科技 - {ProductType.邊射型雷射用}";
                ProductVM.Title = ProductType.邊射型雷射用.ToString();
                ProductVM.Content = File.ReadAllText(Path.Combine(fileFolder, "SubMount", $"MetalEdgeEmittingLaserSubMount.{CultureInfo.Name}.html")).Replace("{{BaseUri}}", Navigator.BaseUri);
                break;
            case ProductType.高頻元件用:
                PageTitle = $"艾格生科技 - {ProductType.高頻元件用}";
                ProductVM.Title = ProductType.高頻元件用.ToString(); 
                ProductVM.Content = File.ReadAllText(Path.Combine(fileFolder, "SubMount", $"HighFrequencyDeviceSubMount.{CultureInfo.Name}.html")).Replace("{{BaseUri}}", Navigator.BaseUri);
                break;
            case ProductType.功率元件:
                PageTitle = $"艾格生科技 - {ProductType.功率元件}";
                ProductVM.Title = ProductType.功率元件.ToString(); 
                ProductVM.Content = File.ReadAllText(Path.Combine(fileFolder, "SubMount", $"PowerDeviceSubMount.{CultureInfo.Name}.html")).Replace("{{BaseUri}}", Navigator.BaseUri);
                break;
            case ProductType.Foundry:
                PageTitle = $"艾格生科技 - {ProductType.Foundry}";
                break;
            case ProductType.金錫合金鍍膜:
                PageTitle = $"艾格生科技 - {ProductType.金錫合金鍍膜}";
                ProductVM.Title = "金錫合金鍍膜 (AuSn)";
                ProductVM.Content = File.ReadAllText(Path.Combine(fileFolder, "FoundryService", $"1.{CultureInfo.Name}.html")).Replace("{{BaseUri}}", Navigator.BaseUri);
                break;
            case ProductType.薄膜金屬化加工:
                PageTitle = $"艾格生科技 - {ProductType.薄膜金屬化加工}";
                ProductVM.Title = "薄膜金屬化加工(Ni , Au, Pt…)";
                ProductVM.Content = File.ReadAllText(Path.Combine(fileFolder, "FoundryService", $"3.{CultureInfo.Name}.html")).Replace("{{BaseUri}}", Navigator.BaseUri);
                break;
            case ProductType.黃光_蝕刻製程:
                PageTitle = $"艾格生科技 - {ProductType.黃光_蝕刻製程}";
                ProductVM.Title = "黃光.蝕刻製程: (Wafer size : 4”~8”)";
                ProductVM.Content = File.ReadAllText(Path.Combine(fileFolder, "FoundryService", $"2.{CultureInfo.Name}.html")).Replace("{{BaseUri}}", Navigator.BaseUri);
                break;
            default:
                break;
        }

        StateHasChanged();
    }

    private void SetSidebarList() => Sidebars =
            [
                new ()
                {
                    Title = "散熱基板",
                    Href = "/Product/0",
                    Disabled = true,
                    SubSidebars =
                    [
                        new()
                        {
                            Title = "邊射型雷射用",
                            Href = "/Product/1"
                        },
                        new()
                        {
                            Title = "高頻元件用",
                            Href = "/Product/2"
                        }
                    ]
                },
                new()
                {
                    Title = "功率元件",
                    Href = "/Product/3"
                },
                new ()
                {
                    Title = "代工服務",
                    Href = "/Product/4",
                    Disabled = true,
                    SubSidebars =
                    [
                        new()
                        {
                            Title = "金錫合金鍍膜",
                            Href = "/Product/5"
                        },
                        new()
                        {
                            Title = "薄膜金屬化加工",
                            Href = "/Product/6"
                        },
                        new()
                        {
                            Title = "黃光.蝕刻製程加工",
                            Href = "/Product/7"
                        }
                    ]
                }
            ];
}