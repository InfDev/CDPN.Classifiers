using BootstrapBlazor.Components;
using BootstrapBlazorApp.Shared;
using BootstrapBlazorApp.Shared.Data;
using CDPN.Classifiers.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
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

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            var apiGatewayClassifiersUrl = builder.Configuration.GetValue<string>("ApiGatewayClassifiers:Url");
            builder.Services.AddHttpClient<ClassifiersClient>(client => client.BaseAddress = new Uri(apiGatewayClassifiersUrl));

            //builder.Configuration.
            builder.Services.AddBootstrapBlazor(blazorOptions => {
                //blazorOptions.DefaultCultureInfo = "ru";
            }, localizerOptions =>
            {
                // Подключение многоязычных файлов ресурсов в формате RESX, например: Program.{CultureName}.resx
                localizerOptions.ResourceManagerStringLocalizerType = typeof(Program);

                // Подключение встроенных файлов ресурсов в формате Json
                localizerOptions.AdditionalJsonAssemblies = new[] { typeof(BootstrapBlazorApp.Shared.App).Assembly };                
            });

            //builder.Services.AddRequestLocalization<IOptions<BootstrapBlazorOptions>>((localizerOption, blazorOption) =>
            //{
            //    var supportedCultures = blazorOption.Value.GetSupportedCultures();

            //    localizerOption.SupportedCultures = supportedCultures;
            //    localizerOption.SupportedUICultures = supportedCultures;
            //});

            //builder.Services.AddSingleton<WeatherForecastService>();

            //// 增加 Table 数据服务操作类
            //builder.Services.AddTableDemoDataService();

            var host = builder.Build();

            host.Services.RegisterProvider();

            await host.RunAsync();
        }
    }
}
