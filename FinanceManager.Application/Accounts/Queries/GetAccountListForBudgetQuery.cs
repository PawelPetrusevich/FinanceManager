using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Application.Accounts.Queries
{
    public class GetAccountListForBudgetQuery : IRequest<IEnumerable<AccountVM>>
    {
        public Guid BudgetId { get; set; }


        public class GetAccountListForBudgetQueryHandler : IRequestHandler<GetAccountListForBudgetQuery, IEnumerable<AccountVM>>
        {
            private readonly IFinanceManagerContext _financeManagerContext;
            private readonly IMapper _mapper;

            public GetAccountListForBudgetQueryHandler(IFinanceManagerContext financeManagerContext, IMapper mapper)
            {
                _financeManagerContext = financeManagerContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<AccountVM>> Handle(GetAccountListForBudgetQuery request, CancellationToken cancellationToken)
            {
                var accounts = await _financeManagerContext
                    .Accounts
                    .Where(x => x.BudgetId == request.BudgetId)
                    .ProjectTo<AccountVM>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return accounts;
            }
        }
    }
}