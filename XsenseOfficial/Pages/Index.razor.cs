using Microsoft.JSInterop;
using Xsense_Front_End.Pages;

namespace XsenseOfficial.Pages;

public class IndexBase : CusComponentBase
{
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        await JsRuntime.InvokeAsync<IJSObjectReference>("import", "./Pages/Index.razor.js");
    }
}
