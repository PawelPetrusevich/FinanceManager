using System;
using System.Threading;
using System.Threading.Tasks;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.DbModels;
using MediatR;

namespace FinanceManager.Application.Transactions.Commands
{
    public class CreateExpenseCommand : IRequest
    {
        public Guid UserId { get; set; }

        public decimal Value { get; set; }

        public string CategoryId { get; set; }

        public string SubCategoryId { get; set; }

        public string Description { get; set; }

        public Guid AccountId { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand>
        {
            private readonly IFinanceManagerContext _financeManagerContext;

            public CreateExpenseCommandHandler(IFinanceManagerContext financeManagerContext)
            {
                _financeManagerContext = financeManagerContext;
            }

            public async Task<Unit> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
            {
                var entity = new TransactionDbModel();

                _financeManagerContext.Transactions.Add(entity);

                entity.UserId = request.UserId;
                entity.Value = request.Value;
                entity.CategoryId = Guid.Parse(request.CategoryId);
                entity.SubCategoryId = Guid.Parse(request.SubCategoryId);
                entity.Description = request.Description;
                entity.AccountId = request.AccountId;
                entity.Date = request.Date;

                await _financeManagerContext.SaveChangesAsync(cancellationToken);

                return default(Unit);
            }
        }
    }
}