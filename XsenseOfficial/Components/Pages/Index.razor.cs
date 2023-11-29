using Microsoft.JSInterop;

namespace XsenseOfficial.Components.Pages;

public class IndexBase : CusComponentBase
{
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
