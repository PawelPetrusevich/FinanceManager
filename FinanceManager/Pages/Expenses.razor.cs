using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Application.Accounts.Queries;
using FinanceManager.Application.Categories.Queries;
using FinanceManager.Application.Common.Enums;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Application.Transactions.Commands;
using FinanceManager.Application.Transactions.Queries;
using FinanceManager.Components.Transactions;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace FinanceManager.Pages
{
    public partial class Expenses
    {
        [Inject] private IMediator _mediator { get; set; }

        [Inject] private ICurrentUserService _currentUserService { get; set; }

        [Inject] private ICurrencyService _currencyService { get; set; }

        protected TransactionType TransactionType = TransactionType.Cunsumption;

        public TransactionsTableBase transactionTable;

        protected List<TransactionVM> Transactions { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            Transactions = await _mediator.Send(new GetTransactionsListQuery
            {
                UserId = Guid.Parse(_currentUserService.User.Id),
                TransactionType = TransactionType.Cunsumption
            });
            
            await base.OnInitializedAsync();
        }

        protected async Task AddNewTransactionHandler(TransactionVM transaction)
        {
            await transactionTable.AddTransactionToTableAsync(transaction);
        }
    }
}
