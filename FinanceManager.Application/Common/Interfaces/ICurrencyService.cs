using System.Collections.Generic;
using FinanceManager.Application.Common.Models;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface ICurrencyService
    {
        List<CurrencyVM> GetAllCurrency();
    }
}