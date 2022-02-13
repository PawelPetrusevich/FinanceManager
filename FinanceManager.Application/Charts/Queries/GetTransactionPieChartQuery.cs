using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models.Charts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Charts.Queries
{
    public class GetTransactionPieChartQuery : IRequest<IEnumerable<TransactionChartItem>>
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public class GetTransactionPieChartQueryHandler : IRequestHandler<GetTransactionPieChartQuery, IEnumerable<TransactionChartItem>>
        {
            private readonly IFinanceManagerContext financeManagerContext;
            private readonly ICurrencyService currencyService;

            public GetTransactionPieChartQueryHandler(IFinanceManagerContext financeManagerContext, ICurrencyService currencyService)
            {
                this.financeManagerContext = financeManagerContext;
                this.currencyService = currencyService;
            }

            public async Task<IEnumerable<TransactionChartItem>> Handle(GetTransactionPieChartQuery request, CancellationToken cancellationToken)
            {
                var transactions = await financeManagerContext
                    .Transactions
                    .Include(x => x.Category)
                    .Include(x => x.SubCategory)
                    .Include(x => x.Account)
                    .Where(x => x.Date.Year == request.Year)
                    .Where(x => x.Date.Month == request.Month)
                    .ToListAsync();

                transactions.ForEach(async x => await currencyService.ConvertSumToByn(x.Account.Currency, x.Date.Year));

                var response = transactions
                    .GroupBy(x => x.Category.Name)
                    .Select(x => new TransactionChartItem
                    {
                        Sum = x.Sum(y=>y.Value),
                        Category = x.Key
                    });

                return response;
            }
        }
    }
}
