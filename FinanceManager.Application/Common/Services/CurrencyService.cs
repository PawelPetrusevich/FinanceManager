using System.Collections.Generic;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;

namespace FinanceManager.Application.Common.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly List<CurrencyVM> currencyList = new()
        {
            new CurrencyVM
            {
                ShortName = "EUR",
                LongName = "EURO"
            },
            new CurrencyVM
            {
                ShortName = "USD",
                LongName = "USD"
            },
            new CurrencyVM
            {
                ShortName = "BYN",
                LongName = "BYN"
            }
        };

        public List<CurrencyVM> GetAllCurrency()
        {
            return currencyList;
        }
    }
}