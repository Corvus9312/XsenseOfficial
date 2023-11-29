using System.Globalization;

namespace XsenseOfficial.Components.Pages;

public class ContactBase : CusComponentBase
{
    public string ContactForm { get; set; } = null!;

    public string ContactInfo { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var fileFolder = Path.Combine(Environment.ContentRootPath, "Templates", "Contact");

        ContactForm = File.ReadAllText(Path.Combine(fileFolder, $"ContactForm.{CultureInfo.CurrentCulture.Name}.html"));
        ContactInfo = File.ReadAllText(Path.Combine(fileFolder, $"ContactInfo.{CultureInfo.CurrentCulture.Name}.html"));
    }
}
