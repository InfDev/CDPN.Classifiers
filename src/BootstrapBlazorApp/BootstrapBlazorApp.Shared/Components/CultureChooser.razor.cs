// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapBlazorApp.Shared.Components
{
    public partial class CultureChooser
    {
        [Inject]
        [NotNull]
        private IOptions<BootstrapBlazorOptions> BootstrapOptions { get; set; }

        [Inject]
        [NotNull]
        private IStringLocalizer<CultureChooser> Localizer { get; set; }

        [Inject]
        [NotNull]
        private NavigationManager NavigationManager { get; set; }

        private string ClassString => CssBuilder.Default("culture-selector")
            .AddClassFromAttributes(AdditionalAttributes)
            .Build();

        private string SelectedCulture { get; set; } = CultureInfo.CurrentUICulture.Name;

        [NotNull]
        private string Label { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Label ??= Localizer[nameof(Label)];
        }

        private async Task SetCulture(SelectedItem item)
        {
            if (OperatingSystem.IsBrowser())
            {
                var cultureName = item.Value;
                if (cultureName != CultureInfo.CurrentCulture.Name)
                {
                    await JSRuntime.InvokeVoidAsync(identifier: "$.blazorCulture.set", cultureName);
                    var culture = new CultureInfo(cultureName);
                    CultureInfo.CurrentCulture = culture;
                    CultureInfo.CurrentUICulture = culture;

                    NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
                }
            }
            else
            {
                if (SelectedCulture != item.Value)
                {
                    var culture = item.Value;
                    var uri = new Uri(NavigationManager.Uri).GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
                    var query = $"?culture={Uri.EscapeDataString(culture)}&redirectUri={Uri.EscapeDataString(uri)}";

                    // use a path that matches your culture redirect controller from the previous steps
                    NavigationManager.NavigateTo("/Culture/SetCulture" + query, forceLoad: true);
                }
            }
        }

        private static string GetDisplayName(CultureInfo culture)
        {            
            var result = culture.NativeName.Split(new char[] { ' ', '-' })[0].ToLower();
            if (OperatingSystem.IsBrowser())
            {
                switch (result)
                {
                    case "en": result = "English"; break;
                    case "ru": result = "Русский"; break;
                    case "uk": result = "Українська"; break;
                }
            }
            return result;
        }
    }
}
