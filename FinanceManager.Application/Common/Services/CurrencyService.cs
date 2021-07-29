using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FinanceManager.Application.Common.Enums;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using Newtonsoft.Json;

namespace FinanceManager.Application.Common.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CurrencyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<string> GetAllCurrency()
        {
            var result = Enum.GetValues(typeof(Currency))
                .Cast<Currency>()
                .Select(x => x.ToString())
                .ToList();

            return result;
        }

        public async Task<decimal> ConvertSumToByn(string currency, decimal sum)
        {
            if (currency == Currency.BYN.ToString())
            {
                return sum;
            }

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://www.nbrb.by/api/exrates/rates/{currency}?parammode=2");

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            dynamic currencyInfo = JsonConvert.DeserializeObject(responseBody);

            var result = sum * (decimal)currencyInfo.Cur_OfficialRate;

            return result;
        }
    }
}