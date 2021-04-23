using System;
using System.Collections.Generic;
using System.Linq;
using FinanceManager.Application.Common.Enums;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;

namespace FinanceManager.Application.Common.Services
{
    public class CurrencyService : ICurrencyService
    {
        public List<string> GetAllCurrency()
        {
            var result = Enum.GetValues(typeof(Currency))
                .Cast<Currency>()
                .Select(x => x.ToString())
                .ToList();

            return result;
        }
    }
}