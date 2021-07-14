using FinanceManager.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FinanceManager.Application.Common.Enums;

namespace FinanceManager.Application.Categories.Queries
{
    public class GetCategoriesListQuery : IRequest<Dictionary<Guid, string>>
    {
        public TransactionType TransactionType { get; set; }

        class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, Dictionary<Guid, string>>
        {
            private readonly IFinanceManagerContext _financeManagerContext;

            public GetCategoriesListQueryHandler(IFinanceManagerContext financeManagerContext)
            {
                _financeManagerContext = financeManagerContext;
            }

            public async Task<Dictionary<Guid, string>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
            {
                var categories = await _financeManagerContext
                    .TransactionCategories
                    .Where(x=>x.TransactionType == request.TransactionType.ToString())
                    .ToDictionaryAsync(x => x.Id, y => y.Name);

                return categories;
            }
        }
    }
}
