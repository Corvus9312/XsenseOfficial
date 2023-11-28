﻿using Microsoft.JSInterop;

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
        await JsRuntime.InvokeVoidAsync("SetSwiper");

        await base.OnAfterRenderAsync(firstRender);
    }
}
