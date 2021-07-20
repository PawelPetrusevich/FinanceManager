using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Application.Accounts.Queries;
using FinanceManager.Application.Categories.Queries;
using FinanceManager.Application.Common.Enums;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Application.Transactions.Queries;
using FinanceManager.Components.Transactions;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace FinanceManager.Pages
{
    public partial class Incomes
    {
        protected const TransactionType TransactionType = Application.Common.Enums.TransactionType.Income;

        [Inject]private IMediator _mediator { get; set; }

        [Inject]private ICurrentUserService _currentUserService { get; set; }

        protected List<TransactionVM> Transactions { get; set; }

        public TransactionsTableBase transactionTable;

        protected override async Task OnInitializedAsync()
        {
            Transactions = await _mediator.Send(new GetTransactionsListQuery
            {
                UserId = Guid.Parse(_currentUserService.User.Id),
                TransactionType = TransactionType
            });

            await base.OnInitializedAsync();
        }

        protected async Task AddNewTransactionHandler(TransactionVM transaction)
        {
            await transactionTable.AddTransactionToTableAsync(transaction);
        }
    }
}
