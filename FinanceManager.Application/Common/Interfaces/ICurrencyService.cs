using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Application.Common.Models;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface ICurrencyService
    {
        List<string> GetAllCurrency();

        Task<decimal> ConvertSumToByn(string currency, decimal sum);
    }
}