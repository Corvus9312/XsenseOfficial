using System.Globalization;

namespace XsenseOfficial.Localizers;

public class MultilingualLocalizer
{
    public List<CultureInfo> SupportedCultures { get; private set; } = [new("zh-TW"), new("zh-CN")];

    public void SetCulture(CultureInfo culture)
    {
        if (SupportedCultures.Any(x => x.Name.Equals(culture.Name)))
        {
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}