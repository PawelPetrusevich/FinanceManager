using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinanceManager.Application.Common.Enums;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Application.Transactions.Queries
{
    public class GetTransactionsListQuery : IRequest<List<TransactionVM>>
    {
        public Guid? UserId { get; set; }

        public TransactionType TransactionType { get; set; }

        public class GetTransactionsListQueryHandler : IRequestHandler<GetTransactionsListQuery, List<TransactionVM>>
        {
            private readonly IFinanceManagerContext _financeManagerContext;
            private readonly IMapper _mapper;

            public GetTransactionsListQueryHandler(IFinanceManagerContext financeManagerContext, IMapper mapper)
            {
                _financeManagerContext = financeManagerContext;
                _mapper = mapper;
            }

            public async Task<List<TransactionVM>> Handle(GetTransactionsListQuery request, CancellationToken cancellationToken)
            {
                var response = await _financeManagerContext
                    .Transactions
                    .Include(x => x.Category)
                    .Include(x => x.SubCategory)
                    .Include(x => x.Account)
                    .Where(x => x.UserId == request.UserId)
                    .Where(x=>x.TransactionType == request.TransactionType.ToString())
                    .ProjectTo<TransactionVM>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return response;
            }
        }
    }
}