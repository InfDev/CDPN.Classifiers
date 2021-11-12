using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootstrapBlazorApp.Shared.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainLayout
    {
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
                [""] = "Начало"
            };
            Menus = GetIconSideMenuItems();
        }

        private static List<MenuItem> GetIconSideMenuItems()
        {
            var classifiersSubmenu = new List<MenuItem>() { 
                new MenuItem() { Text = "Валюты", Icon = "fa fa-fw fa-money", Url = "/Currencies" },
                new MenuItem() { Text = "Страны", Icon = "fa fa-fw fa-flag", Url = "/Countries" },
                new MenuItem() { Text = "АТУ. Уровни", Icon = "fa fa-fw fa-map-marker", Url = "/AtdLevels" },
                new MenuItem() { Text = "АТУ. Категории", Icon = "fa fa-fw fa-map-marker", Url = "/AtdCategories" },
                new MenuItem() { Text = "АТУ. Единицы", Icon = "fa fa-fw fa-map-marker", Url = "/AtdUnits" },
                new MenuItem() { Text = "Размеры бумаги", Icon = "fa fa-fw fa-envelope", Url = "/PaperSizes" },
            };

            
            var menus = new List<MenuItem>
            {
                // new MenuItem() { Text = "Компоненты", Icon = "fa fa-fw fa-home", Url = "https://www.blazor.zone/components" },
                new MenuItem() { Text = "Начало", Icon = "fa fa-fw fa-home", Url = "/" , Match = NavLinkMatch.All},
                new MenuItem() { Text = "Классификаторы", Icon = "fa fa-fw fa-book", Items = classifiersSubmenu, IsCollapsed = false }
                //new MenuItem() { Text = "Счетчик", Icon = "fa fa-fw fa-check-square-o", Url = "/counter" },
                //new MenuItem() { Text = "FetchData", Icon = "fa fa-fw fa-database", Url = "fetchdata" },
                //new MenuItem() { Text = "Table", Icon = "fa fa-fw fa-table", Url = "table" },
                //new MenuItem() { Text = "花名册", Icon = "fa fa-fw fa-users", Url = "users" }
            };

            return menus;
        }
    }
}
