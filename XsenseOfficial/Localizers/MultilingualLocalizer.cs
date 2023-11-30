using System.Globalization;

namespace XsenseOfficial.Localizers;

public class MultilingualLocalizer
{
    // public List<CultureInfo> SupportedCultures { get; private set; } = [new("zh-TW"), new("zh-CN")];

    public List<CustomCultureInfo> SupportedCultures { get; private set; } =
        [
            new() { Name = "繁體中文", Culture = new("zh-TW"), DefaultLocalizer = true },
            new() { Name = "簡體中文", Culture = new("zh-CN") }
        ];

    public void SetCulture(CultureInfo culture)
    {
        if (SupportedCultures.Any(x => x.Culture.Name.Equals(culture.Name)))
        {
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }

    public class CustomCultureInfo
    {
        public string Name { get; set; } = null!;

        public CultureInfo Culture { get; set; } = null!;

        public bool DefaultLocalizer { get; set; } = false;
    }
}