using XsenseOfficial.ViewModels;
using XsenseOfficial_Admin.ViewModels;

namespace XsenseOfficial.Pages;

public class AboutBase : CusComponentBase
{
    public string Profile { get; set; } = null!;
    public string Vision { get; set; } = null!;
    public string Competence { get; set; } = null!;
    public string Quality { get; set; } = null!;
    public string SGS { get; set; } = null!;

    public List<MileStoneVM> MileStones { get; set; } = new();

    public List<SidebarVM> Sidebars { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        // Timeline sample: https://codepen.io/brady_wright/pen/NNOvrW
        
        SetSidebarList();

        Profile = (await HttpClient.GetStringAsync(Path.Combine(Navigator.BaseUri, "templates", "about", $"Profile.{CultureInfo.Name}.html"))).Replace("{{BaseUri}}", Navigator.BaseUri);
        Vision = (await HttpClient.GetStringAsync(Path.Combine(Navigator.BaseUri, "templates", "about", $"Vision.{CultureInfo.Name}.html"))).Replace("{{BaseUri}}", Navigator.BaseUri);
        Competence = (await HttpClient.GetStringAsync(Path.Combine(Navigator.BaseUri, "templates", "about", $"Competence.{CultureInfo.Name}.html"))).Replace("{{BaseUri}}", Navigator.BaseUri);
        MileStones = new()
        {
            new() { Time = "2014-10", EventTitle = "Team up", Content = "成員來自學界，醫材，電子，微機電，與半導體業界優秀人才。" },
            new() { Time = "2014-11", EventTitle = "成立公司", Content = "並於同月通過新竹科學園區管局以及科技部審查，核准進駐園區。" },
            new() { Time = "2016-03", EventTitle = "開始生產", Content = "廠房完成生產線裝機，正式開始試產" },
            new() { Time = "2017-01", EventTitle = "取得ISO9001認證", Content = "取得ISO9001認證" },
            new() { Time = "2020-09", EventTitle = "完成遷址", Content = "完成遷址至竹南科學園區科北一路" },
            new() { Time = "2020-12", EventTitle = "產品試產成功", Content = "EEL產品試產成功" },
            new() { Time = "2021-03", EventTitle = "成為光罩子公司", Content = "成為台灣光罩子公司" },
            new() { Time = "2021-06", EventTitle = "熱沉量產", Content = "EEL熱沉量產出貨" },
            new() { Time = "2023-06", EventTitle = "熱沉出貨累計1500萬顆", Content = "EEL熱沉出貨累計突破1500萬顆" },
        };
        Quality = (await HttpClient.GetStringAsync(Path.Combine(Navigator.BaseUri, "templates", "about", $"Quality.{CultureInfo.Name}.html"))).Replace("{{BaseUri}}", Navigator.BaseUri);
        SGS = (await HttpClient.GetStringAsync(Path.Combine(Navigator.BaseUri, "templates", "about", $"SGS.{CultureInfo.Name}.html"))).Replace("{{BaseUri}}", Navigator.BaseUri);
    }

    private void SetSidebarList()
    {
        Sidebars =
            new()
            {
                new ()
                {
                    Title = Localizer["公司基本介紹"],
                    Href = "javascript:BlazorScrollToId('profile')"
                },
                new ()
                {
                    Title = Localizer["核心競爭力"],
                    Href = "javascript:BlazorScrollToId('competence')",
                },
                new ()
                {
                    Title = Localizer["里程碑"],
                    Href = "javascript:BlazorScrollToId('milestone')",
                },
                new ()
                {
                    Title = Localizer["品質政策"],
                    Href = "javascript:BlazorScrollToId('quality')",
                },
                new ()
                {
                    Title = Localizer["SGS RoHS ISO"],
                    Href = "javascript:BlazorScrollToId('sgs')",
                }
            };
    }
}