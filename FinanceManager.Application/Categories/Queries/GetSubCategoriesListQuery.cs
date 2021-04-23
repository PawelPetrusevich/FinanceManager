using FinanceManager.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Categories.Queries
{
    class GetSubCategoriesListQuery : IRequest<Dictionary<Guid, string>>
    {
        public Guid CategoryId { get; set; }

        public class GetSubCategoriesListQueryGandler : IRequestHandler<GetSubCategoriesListQuery, Dictionary<Guid, string>>
        {
            private readonly IFinanceManagerContext _financeManagerContext;

            public GetSubCategoriesListQueryGandler(IFinanceManagerContext financeManagerContext)
            {
                _financeManagerContext = financeManagerContext;
            }

            public async Task<Dictionary<Guid, string>> Handle(GetSubCategoriesListQuery request, CancellationToken cancellationToken)
            {
                var subCategories = await _financeManagerContext
                    .TransactionSubCategories
                    .Where(x => x.CategoryId == request.CategoryId)
                    .ToDictionaryAsync(x => x.Id, y => y.Name);

                return subCategories;
            }
        }
    }
}
