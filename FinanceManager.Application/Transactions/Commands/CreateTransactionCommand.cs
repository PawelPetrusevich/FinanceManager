using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinanceManager.Application.Common.Enums;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Domain.DbModels;
using MediatR;

namespace FinanceManager.Application.Transactions.Commands
{
    public class CreateTransactionCommand : IRequest<TransactionVM>
    {
        public Guid UserId { get; set; }

        public decimal Value { get; set; }

        public string CategoryId { get; set; }

        public string SubCategoryId { get; set; }

        public string Description { get; set; }

        public string AccountId { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public TransactionType TransactionType { get; set; }

        public class CreateExpenseCommandHandler : IRequestHandler<CreateTransactionCommand, TransactionVM>
        {
            private readonly IFinanceManagerContext _financeManagerContext;
            private readonly IMapper _mapper;

            public CreateExpenseCommandHandler(IFinanceManagerContext financeManagerContext, IMapper mapper)
            {
                _financeManagerContext = financeManagerContext;
                _mapper = mapper;
            }

            public async Task<TransactionVM> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
            {
                var entity = new TransactionDbModel();

                _financeManagerContext.Transactions.Add(entity);

                entity.UserId = request.UserId;
                entity.Value = request.Value;
                entity.CategoryId = Guid.Parse(request.CategoryId);
                entity.SubCategoryId = Guid.Parse(request.SubCategoryId);
                entity.Description = request.Description;
                entity.AccountId = Guid.Parse(request.AccountId);
                entity.Date = request.Date;
                entity.TransactionType = request.TransactionType.ToString();

                //await _financeManagerContext.SaveChangesAsync(cancellationToken);

                var result = _mapper.Map<TransactionDbModel, TransactionVM>(entity);

                return result;
            }
        }
    }
}