using System.Net.Mail;
using System.Net;
using XsenseOfficial.Models;
using Microsoft.JSInterop;
using XsenseOfficial.Components.Pages.ComponetBase;

namespace XsenseOfficial.Components.Pages;

public class ContactBase : CusComponentBase
{
    protected string ContactInfo { get; set; } = null!;

    protected SendMailModel MailModel { get; set; } = new();

    protected string ContactFormContent => Localizer["ContactFormContent"];
    protected string Name => Localizer["ContactName"];
    protected string Phone => Localizer["ContactPhone"];
    protected string Subject => Localizer["ContactProductIssue"];
    protected string Content => Localizer["ContactContent"];

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var fileFolder = Path.Combine(Environment.ContentRootPath, "Templates", "Contact");

        ContactInfo = File.ReadAllText(Path.Combine(fileFolder, $"ContactInfo.{Language}.html"));

        MailModel = new() { Subject = Localizer["ContactProductIssue"] };

        StateHasChanged();
    }

    public async Task SendEmail()
    {
        using MailMessage msg = new();
        msg.From = new MailAddress("mis@xsensetw.com", "Xsense_SystemMail");
        msg.To.Add("xservice@xsensetw.com");
        msg.Subject = MailModel.Subject;
        msg.Body = MailModel.body;
        msg.IsBodyHtml = false;

        var a = "mis@xsensetw.com";
        var p = "Xsense123$$";

        using SmtpClient client = new()
        {
            EnableSsl = true,
            Host = "smtp.office365.com",
            Port = 587,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Credentials = new NetworkCredential(a, p)
        };

        await client.SendMailAsync(msg);

        await JsRuntime.InvokeVoidAsync("alert", "發信完成。");

        Navigator.NavigateTo($"/{Language}/contact", true);
    }
}
