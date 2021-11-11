﻿using BootstrapBlazor.Components;
using BootstrapBlazorApp.Shared.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using CDPN.Classifiers.Client;
using Microsoft.AspNetCore.HttpOverrides;

namespace BootstrapBlazorApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            // services.AddCors();
            services.AddResponseCompression();

            services.AddControllers();
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddBootstrapBlazor(null, options =>
            {
                // Настройте многоязычные файлы ресурсов в формате RESX, например: Program.{CultureName}.resx
                options.ResourceManagerStringLocalizerType = typeof(Program);

                // Установить встроенный файл ресурсов в формате Json
                options.AdditionalJsonAssemblies = new[] { typeof(BootstrapBlazorApp.Shared.App).Assembly };

            //    // Установить файл физического пути Json
            //    options.AdditionalJsonFiles = new string[]
            //    {
            //@"D:\Argo\src\BootstrapBlazor\src\BootstrapBlazor.Server\Locales\zh-TW.json",
            //@"D:\Argo\src\BootstrapBlazor\src\BootstrapBlazor.Server\Locales\zh-CN.json"
            //    };
            });
            //services.AddBootstrapBlazorServices(Configuration.GetSection("Themes")
            //    .GetChildren()
            //    .Select(c => new KeyValuePair<string, string>(c.Key, c.Value)));

            services.AddRequestLocalization<IOptions<BootstrapBlazorOptions>>((localizerOption, blazorOption) =>
            {
                var supportedCultures = blazorOption.Value.GetSupportedCultures();

                localizerOption.SupportedCultures = supportedCultures;
                localizerOption.SupportedUICultures = supportedCultures;
            });

            var apiGatewayClassifiersUrl = Configuration.GetValue<string>("ApiGatewayClassifiers:Url");
            services.AddHttpClient<ClassifiersClient>(client => client.BaseAddress = new Uri(apiGatewayClassifiersUrl));

            services.AddSingleton<WeatherForecastService>();

            // 增加 Table 数据服务操作类
            services.AddTableDemoDataService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplicationServices.RegisterProvider();
            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>()!.Value);
            app.UseForwardedHeaders(new ForwardedHeadersOptions() { ForwardedHeaders = ForwardedHeaders.All });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseResponseCompression();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseCors(builder => builder.WithOrigins(Configuration["AllowOrigins"].Split(',', StringSplitOptions.RemoveEmptyEntries))
            //    .AllowAnyHeader()
            //    .AllowAnyMethod()
            //    .AllowCredentials());

            //app.UseBootstrapBlazor();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
