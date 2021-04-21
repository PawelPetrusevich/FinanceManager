using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Application.Transactions.Commands;
using FinanceManager.Application.Transactions.Queries;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace FinanceManager.Pages
{
    public partial class Expenses
    {
        [Inject] private IMediator _mediator { get; set; }

        [Inject] private ICurrentUserService _currentUserService { get; set; }

        [Inject] private ICurrencyService _currencyService { get; set; }

        protected IEnumerable<TransactionVM> Transactions { get; set; }

        protected CreateExpenseCommand CreateExpenseCommand { get; set; } = new CreateExpenseCommand();

        protected IEnumerable<CurrencyVM> CurrencyList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CurrencyList = _currencyService.GetAllCurrency();

            Transactions = await _mediator.Send(new GetExpensesListQuery
            {
                UserId = Guid.Parse(_currentUserService.User.Id)
            });

            await base.OnInitializedAsync();
        }
    }
}
