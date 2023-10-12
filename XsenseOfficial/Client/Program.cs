using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

namespace XsenseOfficial
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddLocalization();

            var app = builder.Build();

            #region �h��y�t�]�w
            var js = app.Services.GetRequiredService<IJSRuntime>();
            var result = await js.InvokeAsync<string>("blazorCulture.get");// ���o JS localStorage���x�s���e
            var culture = string.IsNullOrWhiteSpace(result) ? new CultureInfo("zh-TW") : new CultureInfo(result); 
            if (result == null)
                await js.InvokeVoidAsync("blazorCulture.set", "zh-TW");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            #endregion

            await app.RunAsync();
        }
    }
}