using System.Globalization;
using XsenseOfficial.Components.Pages.ComponetBase;

namespace XsenseOfficial.Components.Pages;

public class RootPageBase : CusComponentBase
{
    protected override void OnInitialized()
    {
        Navigator.NavigateTo($"/{CultureInfo.CurrentCulture.Name}/index");
    }
}
