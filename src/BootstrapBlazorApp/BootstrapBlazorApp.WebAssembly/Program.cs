using BootstrapBlazor.Components;
using BootstrapBlazorApp.Shared;
using CDPN.Classifiers.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BootstrapBlazorApp.WebAssembly
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            var apiGatewayClassifiersUrl = builder.Configuration.GetValue<string>("ApiGatewayClassifiers:Url");
            builder.Services.AddHttpClient<ClassifiersClient>(client => client.BaseAddress = new Uri(apiGatewayClassifiersUrl));

            builder.Services.AddBootstrapBlazor(blazorOptions => {
                //blazorOptions.DefaultCultureInfo = "ru";
            }, localizerOptions =>
            {
                // Подключение многоязычных файлов ресурсов в формате RESX, например: Program.{CultureName}.resx
                localizerOptions.ResourceManagerStringLocalizerType = typeof(Program);
                // Подключение встроенных файлов ресурсов в формате Json
                localizerOptions.AdditionalJsonAssemblies = new[] { typeof(BootstrapBlazorApp.Shared.App).Assembly };                
            });
            builder.Services.AddLocalization();

            var host = builder.Build();

            await SetCultureAsync(host);
            host.Services.RegisterProvider();

            await host.RunAsync();
        }

        // https://docs.microsoft.com/ru-ru/aspnet/core/blazor/globalization-localization?view=aspnetcore-6.0&pivots=webassembly
        static async Task SetCultureAsync(WebAssemblyHost host)
        {
            // Если язык не установлен в localStorage, используется язык, указанный в запросе браузера.
            var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();
            var cultureName = await jsRuntime.InvokeAsync<string>("$.blazorCulture.get");

            if (!string.IsNullOrEmpty(cultureName))
            {
                var culture = new CultureInfo(cultureName);

                // Обратите внимание, что в режиме wasm здесь необходимо использовать DefaultThreadCurrentCulture,
                // CurrentCulture использовать нельзя.
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            }
        }
    }
}
