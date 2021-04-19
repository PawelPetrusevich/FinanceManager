using System;
using System.Threading;
using System.Threading.Tasks;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Common.DbModels;
using MediatR;

namespace FinanceManager.Application.Accounts.Commands
{
    public class CreateAccountCommand : IRequest
    {
        public string AcconuntName { get; set; }

        public decimal AccountSum { get; set; }

        public string Currency { get; set; }

        public Guid UserId { get; set; }

        public Guid BudgetId { get; set; }

        public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand>
        {
            private readonly IFinanceManagerContext _context;

            public CreateAccountCommandHandler(IFinanceManagerContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
            {
                AccountDbModel entity = new AccountDbModel();

                _context.Accounts.Add(entity);

                entity.AccauntSum = request.AccountSum;
                entity.AccountName = request.AcconuntName;
                entity.Currency = request.Currency;
                entity.BudgetId = request.BudgetId;
                entity.UserId = request.UserId;

                await _context.SaveChangesAsync(cancellationToken);

                return default(Unit);
            }
        }
    }
}