using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using BootstrapBlazor.Components;
using Microsoft.Extensions.Localization;
using System.Linq;
using System.Threading.Tasks;
using CDPN.Classifiers.Client;
using CDPN.Classifiers.Client.Models;
using BootstrapBlazorApp.Shared.Extensions;

namespace BootstrapBlazorApp.Shared.Pages
{
    public partial class AtdUnits
    {
        public AtdUnits()
        {

        }

        [Inject]
        private IStringLocalizer<AtdUnits> Localizer { get; set; }

        [Inject]
        private ClassifiersClient ClassifiersClient { get; set; }

        /// <summary>
        /// Установить допустимые размеры страниц
        /// </summary>
        private IEnumerable<int> PageItemsSource => new int[] { 20, 10, 50 };

        private async Task<QueryData<AtdUnit>> OnQueryAsync(QueryPageOptions options)
        {
            var request = options.PagingRequest();
            var response = await ClassifiersClient.GetAtdUnitsAsync(
                    request.Page, request.PageSize, request.OrderBy, request.Filter);
            return new QueryData<AtdUnit>
            {
                Items = response.Data,
                TotalCount = response.TotalRecords,
                IsFiltered = !string.IsNullOrEmpty(request.Filter),
                IsSorted = !string.IsNullOrEmpty(request.OrderBy),
                IsSearch = false,
            };
        }
    }
}
