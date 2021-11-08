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
    public partial class Currencies
    {
        public Currencies()
        {
        }

        [Inject]
        private IStringLocalizer<Currencies> Localizer { get; set; }

        [Inject]
        private ClassifiersClient ClassifiersClient { get; set; }

        /// <summary>
        /// Установить допустимые размеры страниц
        /// </summary>
        private IEnumerable<int> PageItemsSource => new int[] { 20, 10, 50 };

        private async Task<QueryData<Currency>> OnQueryAsync(QueryPageOptions options)
        {
            var request = options.PagingRequest();
            var response = await ClassifiersClient.GetCurrenciesAsync(
                request.Page, request.PageSize, request.OrderBy, request.Filter);

            var isSearch = false;
            var isFiltered = false;
            var isSorted = false;
            return new QueryData<Currency>
            {
                Items = response.Data,
                TotalCount = response.TotalRecords,
                IsFiltered = isFiltered,
                IsSorted = isSorted,
                IsSearch = isSearch,
            };

            //var task = Task.Run(() => {

            //    var request = PagingRequestFrom(options);

            //    var response = ClassifiersClient.GetCurrenciesAsync().GetAwaiter().GetResult();
            //    var isSearch = false;
            //    var isFiltered = false;
            //    var isSorted = false;

            //    return Task.FromResult(new QueryData<Currency> { 
            //            Items = response.Data.AsEnumerable(),
            //            TotalCount = response.TotalRecords,
            //            IsFiltered = isFiltered,
            //            IsSorted = isSorted,
            //            IsSearch = isSearch,
            //        });
            //});
            //return task;
        }
    }
}
