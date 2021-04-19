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
    public class GetAccountsListQuery : IRequest<IEnumerable<AccountVM>>
    {
        public Guid UserId { get; set; }

        public class GetAccountsListQueryHandler : IRequestHandler<GetAccountsListQuery, IEnumerable<AccountVM>>
        {
            private readonly IFinanceManagerContext _financeManagerContext;
            private readonly IMapper _mapper;

            public GetAccountsListQueryHandler(IFinanceManagerContext financeManagerContext, IMapper mapper)
            {
                _financeManagerContext = financeManagerContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<AccountVM>> Handle(GetAccountsListQuery request, CancellationToken cancellationToken)
            {
                var accounts = await _financeManagerContext
                    .Accounts
                    .Where(x => x.UserId == request.UserId)
                    .ProjectTo<AccountVM>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);

                return accounts;
            }
        }
    }
}