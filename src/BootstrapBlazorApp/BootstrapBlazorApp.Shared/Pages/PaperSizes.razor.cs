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
    public partial class PaperSizes
    {
        public PaperSizes()
        {

        }

        [Inject]
        private IStringLocalizer<PaperSizes> Localizer { get; set; }

        [Inject]
        private ClassifiersClient ClassifiersClient { get; set; }

        /// <summary>
        /// Установить допустимые размеры страниц
        /// </summary>
        private IEnumerable<int> PageItemsSource => new int[] { 20, 10, 50 };

        private async Task<QueryData<PaperSize>> OnQueryAsync(QueryPageOptions options)
        {
            var request = options.PagingRequest();
            var response = await ClassifiersClient.GetPaperSizesAsync(
                    request.Page, request.PageSize, request.OrderBy, request.Filter);
            return new QueryData<PaperSize>
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
