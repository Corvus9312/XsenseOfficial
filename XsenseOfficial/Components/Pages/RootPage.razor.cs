using System.Globalization;

namespace XsenseOfficial.Components.Pages;

public class RootPageBase : CusComponentBase
{
    protected override void OnInitialized()
    {
        Navigator.NavigateTo($"/{CultureInfo.CurrentCulture}/index");
    }
}
