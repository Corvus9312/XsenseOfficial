using Microsoft.AspNetCore.Localization;
using System.Globalization;
using XsenseOfficial.Localizers;

namespace XsenseOfficial.Middlewares;

public class MultilingualMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(
        HttpContext context,
        MultilingualLocalizer multilingual)
    {
        var url = $"{context.Request.Scheme}://{context.Request.Host.Value}{context.Request.Path.Value}";

        Uri route = new(url);

        if (route.Segments.Length > 1)
        {
            string language = route.Segments[1].TrimEnd('/');

            if (multilingual.SupportedCultures.Any(x => x.Name.Equals(language)))
            {
                var redirect = !CultureInfo.CurrentCulture.Name.Equals(language);

                multilingual.SetCulture(new(language));

                context.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(
                        new RequestCulture(new CultureInfo(language), new CultureInfo(language))));

                if (redirect)
                    context.Response.Redirect(url);
            }
        }

        await _next(context);
    }
}