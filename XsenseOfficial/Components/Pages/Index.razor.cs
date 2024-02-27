using Microsoft.JSInterop;
using XsenseOfficial.Components.Pages.ComponetBase;

namespace XsenseOfficial.Components.Pages;

public class IndexBase : CusComponentBase
{
    protected List<string> SwiperImgs => 
        [
            $"/images/index/swiper1.{Language}.webp", 
            $"/images/index/swiper2.{Language}.webp"
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
