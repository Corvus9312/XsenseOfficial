using System.Globalization;

namespace XsenseOfficial.ViewModels;

public class PorductCategoryVM
{
    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public List<PorductVM> Products { get; set; } = null!;
}

public class PorductVM
{
    public int Serial { get; set; }

    public string Name { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string SideBarName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public string Uri
    {
        get
        {
            return $"/{CultureInfo.CurrentCulture.Name}/Product/{Serial}";
        }
    }
}