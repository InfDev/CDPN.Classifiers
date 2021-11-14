using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootstrapBlazorApp.Shared.Shared
{
    public sealed partial class MainLayout
    {
        [Inject]
        private IStringLocalizer<MainLayout> Localizer { get; set; }


        private bool UseTabSet { get; set; } = true;

        private string Theme { get; set; } = "";

        private bool IsOpen { get; set; }

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = true;

        private List<MenuItem> Menus { get; set; }

        private Dictionary<string, string> TabItemTextDictionary { get; set; }

        /// <summary>
        /// OnInitialized method
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            // Имитация асинхронного переключения потоков, удалите эту строку кода из официального кода
            await Task.Yield();

            // Меню можно получить через базу данных. Ниже меню собрано непосредственно в коде
            TabItemTextDictionary = new()
            {
                [""] = Localizer["Home"]
            };
            Menus = GetIconSideMenuItems();
        }

        private List<MenuItem> GetIconSideMenuItems()
        {
            var classifiersSubmenu = new List<MenuItem>() { 
                new MenuItem() { Text = Localizer["Currencies"], Icon = "fa fa-fw fa-money", Url = "/Currencies" },
                new MenuItem() { Text = Localizer["Countries"], Icon = "fa fa-fw fa-flag", Url = "/Countries" },
                new MenuItem() { Text = Localizer["AtdLevels"], Icon = "fa fa-fw fa-map-marker", Url = "/AtdLevels" },
                new MenuItem() { Text = Localizer["AtdCategories"], Icon = "fa fa-fw fa-map-marker", Url = "/AtdCategories" },
                new MenuItem() { Text = Localizer["AtdUnits"], Icon = "fa fa-fw fa-map-marker", Url = "/AtdUnits" },
                new MenuItem() { Text = Localizer["PaperSizes"], Icon = "fa fa-fw fa-envelope", Url = "/PaperSizes" },
            };

            
            var menus = new List<MenuItem>
            {
                // new MenuItem() { Text = "Компоненты", Icon = "fa fa-fw fa-home", Url = "https://www.blazor.zone/components" },
                new MenuItem() { Text = Localizer["Home"], Icon = "fa fa-fw fa-home", Url = "/" , Match = NavLinkMatch.All},
                new MenuItem() { Text = Localizer["Classifiers"], Icon = "fa fa-fw fa-book", Items = classifiersSubmenu, IsCollapsed = false }
            };

            return menus;
        }
    }
}
