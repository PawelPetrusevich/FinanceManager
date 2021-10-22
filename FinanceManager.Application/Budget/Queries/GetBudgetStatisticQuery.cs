using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Domain.DbModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Application.Budget.Queries
{
    public class GetBudgetStatisticQuery : IRequest<BudgetStatisticVM>
    {
        public Guid BudgetId { get; set; }

        public class GetBudgetStatisticQueryHandler : IRequestHandler<GetBudgetStatisticQuery, BudgetStatisticVM>
        {
            private readonly IFinanceManagerContext _financeManagerContext;
            private readonly ICurrencyService _currencyService;

            public GetBudgetStatisticQueryHandler(
                IFinanceManagerContext financeManagerContext,
                ICurrencyService currencyService)
            {
                _financeManagerContext = financeManagerContext;
                _currencyService = currencyService;
            }

            public async Task<BudgetStatisticVM> Handle(GetBudgetStatisticQuery request, CancellationToken cancellationToken)
            {
                var response = await _financeManagerContext
                    .Transactions
                    .Include(x => x.Category)
                    .Include(x => x.SubCategory)
                    .Include(x => x.Account)
                    .Where(x => x.Account.BudgetId == request.BudgetId)
                    .Where(x => x.Date.Month >= DateTime.UtcNow.AddMonths(-1).Month && x.Date.Year == DateTime.UtcNow.Year)
                    .GroupBy(x => new
                    {
                        CategoryName = x.Category.Name,
                        SubCategory = x.SubCategory.Name,
                        Currency = x.Account.Currency,
                        Month = x.Date.Month,
                        Year = x.Date.Year,
                        TransactionType = x.TransactionType
                    })
                    .OrderBy(x => x.Key.CategoryName)
                    .Select(x => new BudgetStatisticItem()
                    {
                        Sum = x.Sum(y => y.Value),
                        CategoryName = x.Key.CategoryName,
                        SubCategoryName = x.Key.SubCategory,
                        Currency = x.Key.Currency,
                        Date = new DateTime(x.Key.Year, x.Key.Month, 1),
                        TransactionType = x.Key.TransactionType

                    })
                    .ToListAsync(cancellationToken);

                await ConvertCurrencyToByn(response);

                var result = BuildBudgetStatistic(response);

                return result;
            }

            private async Task ConvertCurrencyToByn(List<BudgetStatisticItem> statisticItems)
            {
                foreach (var budgetStatisticItemVm in statisticItems)
                {
                    budgetStatisticItemVm.Sum =
                        await _currencyService.ConvertSumToByn(
                            budgetStatisticItemVm.Currency,
                            budgetStatisticItemVm.Sum);
                }
            }

            private BudgetStatisticVM BuildBudgetStatistic(List<BudgetStatisticItem> statisticItems)
            {
                var statisticItemsVm = statisticItems
                    .GroupBy(x => new
                    {
                        Category = x.CategoryName,
                        TransactionType = x.TransactionType
                    })
                    .Select(x => new BudgetStatisticItemVM
                    {
                        Name = x.Key.Category,
                        TransactionType = x.Key.TransactionType,
                        Sum = x.Where(y => y.Date.Month == DateTime.UtcNow.Month).Sum(y => y.Sum),
                        SumPrevious = x.Where(y => y.Date.Month == DateTime.UtcNow.AddMonths(-1).Month).Sum(y => y.Sum),
                        ChildItems = x
                            .GroupBy(z => new
                            {
                                SubCategoryName = z.SubCategoryName
                            })
                            .Select(z => new BudgetStatisticItemVM
                            {
                                Name = z.Key.SubCategoryName,
                                Sum = z.Where(y => y.Date.Month == DateTime.UtcNow.Month).Sum(y => y.Sum),
                                SumPrevious = z.Where(y => y.Date.Month == DateTime.UtcNow.AddMonths(-1).Month).Sum(y => y.Sum)
                            })
                    });

                var result = new BudgetStatisticVM
                {
                    StatisticItems = statisticItemsVm.ToList()
                };

                return result;
            }
        }
    }
}