using Microsoft.JSInterop;
using System.Globalization;

namespace XsenseOfficial.Components.Pages;

public class IndexBase : CusComponentBase
{
    protected List<string> SwiperImgs => 
        [
            $"/images/index/swiper1.{CultureInfo.CurrentCulture.Name}.png", 
            $"/images/index/swiper2.{CultureInfo.CurrentCulture.Name}.png"
        ];

    protected override void OnInitialized()
    {
        base.OnInitialized();

        StateHasChanged();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await JsRuntime.InvokeVoidAsync("SetSwiper");
        }
    }
}
