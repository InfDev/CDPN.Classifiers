using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CDPN.Classifiers.Client.Models;


namespace CDPN.Classifiers.Client
{
    public class ClassifiersClient
    {
        private const int DefaultPage = 1;
        private const int DefaultPageSize = 20;

        private readonly HttpClient httpClient;

        public ClassifiersClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<PagingResponse<Currency>> GetCurrenciesAsync(
            int page = DefaultPage, int pageSize = DefaultPageSize, string orderBy = null, string filter = null)
        {
            var uri = GetUri("Currencies", page, pageSize, orderBy, filter);
            var response = await httpClient.GetFromJsonAsync<PagingResponse<Currency>>(uri);
            return response;
        }

        public async Task<PagingResponse<Country>> GetCountriesAsync(
            int page = DefaultPage, int pageSize = DefaultPageSize, string orderBy = null, string filter = null)
        {
            var uri = GetUri("Countries", page, pageSize, orderBy, filter);
            var response = await httpClient.GetFromJsonAsync<PagingResponse<Country>>(uri);
            return response;
        }

        public async Task<PagingResponse<AtdLevel>> GetAtdLevelsAsync(
            int page = DefaultPage, int pageSize = DefaultPageSize, string orderBy = null, string filter = null)
        {
            var uri = GetUri("AtdLevels", page, pageSize, orderBy, filter);
            var response = await httpClient.GetFromJsonAsync<PagingResponse<AtdLevel>>(uri);
            return response;
        }

        public async Task<PagingResponse<AtdCategory>> GetAtdCategoriesAsync(
            int page = DefaultPage, int pageSize = DefaultPageSize, string orderBy = null, string filter = null)
        {
            var uri = GetUri("AtdCategories", page, pageSize, orderBy, filter);
            var response = await httpClient.GetFromJsonAsync<PagingResponse<AtdCategory>>(uri);
            return response;
        }

        public async Task<PagingResponse<AtdUnit>> GetAtdUnitsAsync(
            int page = DefaultPage, int pageSize = DefaultPageSize, string orderBy = null, string filter = null)
        {
            var uri = GetUri("AtdUnits", page, pageSize, orderBy, filter);
            var response = await httpClient.GetFromJsonAsync<PagingResponse<AtdUnit>>(uri);
            return response;
        }

        public async Task<PagingResponse<AtdUnit>> GetAtdUnitsOfUkraineMainRegionsAsync(bool withCountry = true, bool withOccupied = true)
        {
            var levelIdCondition = withCountry ? "<2" : "=1";
            var filter = $"Id^UA,AtdLevelId{levelIdCondition}";
            // Исключить оккупированные
            if (!withOccupied)
                filter += ",Name!*окуп";
            return await GetAtdUnitsAsync(1, 50, null, filter);
        }

        public async Task<PagingResponse<PaperSize>> GetPaperSizesAsync(
            int page = DefaultPage, int pageSize = DefaultPageSize, string orderBy = null, string filter = null)
        {
            var uri = GetUri("PaperSizes", page, pageSize, orderBy, filter);
            var response = await httpClient.GetFromJsonAsync<PagingResponse<PaperSize>>(uri);
            return response;
        }

        public static string GetUri(string uri, int page, int pageSize, string orderBy, string filter)
        {
            var paramList = new List<string>()
            {
                $"Page={page}",
                $"PageSize={pageSize}",
            };
            if (!string.IsNullOrEmpty(orderBy))
                paramList.Add($"OrderBy={Uri.EscapeDataString(orderBy)}");
            if (!string.IsNullOrEmpty(filter))
                paramList.Add($"Filter={Uri.EscapeDataString(filter)}");
            var parameters = string.Join('&', paramList);
            
            var uriWithParameters = $"{uri}?{parameters}";
            return uriWithParameters;
        }
    }
}
