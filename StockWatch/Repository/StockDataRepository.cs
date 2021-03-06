﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace StockWatch.Repository
{
    public class StockDataRepository : IStockDataRepository
    {
        private HttpClient httpClient;
        private static readonly string apiBaseAddress = "http://dev.markitondemand.com/MODApis/";

        public async Task<string> LookupStockName(string stockName) 
        {
            var requestUri = "Api/v2/Lookup/json?input=" + stockName;
            var result = await ProcessHttpRequest(requestUri);
            return result;
        }

        public async Task<string> GetStockQuoteDetails(string stockName)
        {
            var requestUri = "api/v2/quote/json?symbol=" + stockName;
            var result = await ProcessHttpRequest(requestUri);
            return result;
        }

        private async Task<string> ProcessHttpRequest(string requestUri)
        {
            var result = string.Empty;
            try
            {
                using (httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(apiBaseAddress);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(requestUri);
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        result = await httpResponseMessage.Content.ReadAsStringAsync();
                        return result;
                    }
                }
            }
            catch(ApplicationException aEx)
            {
                Trace.TraceError("Error occurred while making GET request - {0}", aEx);
            }

            return string.Empty;
        }
    }
}