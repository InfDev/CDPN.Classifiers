using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CDPN.Classifiers.Client.Models;


namespace CDPN.Classifiers.Client
{
    public class ClassiffersClient
    {
        private const int DefaultPage = 1;
        private const int DefaultPageSize = 20;

        private readonly HttpClient httpClient;

        public ClassiffersClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Response<Currency>> GetCurrenciesAsync(
            int page = DefaultPage, int pageSize = DefaultPageSize, string orderBy = null, string filter = null)
        {
            var uri = GetUri("Currencies", page, pageSize, orderBy, filter);
            var response = await httpClient.GetFromJsonAsync<Response<Currency>>(uri);
            return response;
        }

        public async Task<Response<Country>> GetCountriesAsync(
            int page = DefaultPage, int pageSize = DefaultPageSize, string orderBy = null, string filter = null)
        {
            var uri = GetUri("Countries", page, pageSize, orderBy, filter);
            var response = await httpClient.GetFromJsonAsync<Response<Country>>(uri);
            return response;
        }

        public async Task<Response<AtdLevel>> GetAtdLevelsAsync(
            int page = DefaultPage, int pageSize = DefaultPageSize, string orderBy = null, string filter = null)
        {
            var uri = GetUri("AtdLevels", page, pageSize, orderBy, filter);
            var response = await httpClient.GetFromJsonAsync<Response<AtdLevel>>(uri);
            return response;
        }

        public async Task<Response<AtdCategory>> GetAtdCategoriesAsync(
            int page = DefaultPage, int pageSize = DefaultPageSize, string orderBy = null, string filter = null)
        {
            var uri = GetUri("AtdCategories", page, pageSize, orderBy, filter);
            var response = await httpClient.GetFromJsonAsync<Response<AtdCategory>>(uri);
            return response;
        }


        public async Task<Response<AtdUnit>> GetAtdUnitsAsync(
            int page = DefaultPage, int pageSize = DefaultPageSize, string orderBy = null, string filter = null)
        {
            var uri = GetUri("AtdUnits", page, pageSize, orderBy, filter);
            var response = await httpClient.GetFromJsonAsync<Response<AtdUnit>>(uri);
            return response;
        }

        public async Task<Response<AtdUnit>> GetAtdUnitsOfUkraineMainRegionsAsync(bool withCountry = true, bool withOccupied = true)
        {
            var levelIdCondition = withCountry ? "<2" : "=1";
            var filter = $"Id^UA,AtdLevelId{levelIdCondition}";
            // Исключить оккупированные
            if (!withOccupied)
                filter += ",Name!*окуп";
            return await GetAtdUnitsAsync(1, 50, null, filter);
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
