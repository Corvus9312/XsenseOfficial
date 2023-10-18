using Microsoft.JSInterop;
using Xsense_Front_End.Pages;

namespace XsenseOfficial.Pages;

public class IndexBase : CusComponentBase
{
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JsRuntime.InvokeVoidAsync("SetSwiper");

        await base.OnAfterRenderAsync(firstRender);
    }
}
