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
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace FinanceManager.Pages
{
    public partial class Incomes
    {
        [Inject]private IMediator _mediator { get; set; }

        [Inject]private ICurrentUserService _currentUserService { get; set; }

        [Inject] private ICurrencyService _currencyService { get; set; }

        protected CreateTransactionCommand CreateTransactionCommand { get; set; } = new CreateTransactionCommand();

        protected List<TransactionVM> Transactions { get; set; }

        protected IEnumerable<AccountVM> UserBudgetAccounts { get; set; } = new List<AccountVM>();

        protected IDictionary<Guid, string> CategoryList { get; set; } = new Dictionary<Guid, string>();

        protected IDictionary<Guid, string> SubCategoryList { get; set; } = new Dictionary<Guid, string>();

        protected IEnumerable<string> CurrencyList { get; set; } = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            Transactions = await _mediator.Send(new GetTransactionsListQuery
            {
                UserId = Guid.Parse(_currentUserService.User.Id),
                TransactionType = TransactionType.Income
            });

            CurrencyList = _currencyService.GetAllCurrency();

            UserBudgetAccounts = await _mediator.Send(new GetAccountListForBudgetQuery
            {
                BudgetId = Guid.Parse(_currentUserService.User.BudgetId)
            });

            Transactions = await _mediator.Send(new GetTransactionsListQuery
            {
                UserId = Guid.Parse(_currentUserService.User.Id),
                TransactionType = TransactionType.Income
            });

            CategoryList = await _mediator.Send(new GetCategoriesListQuery
            {
                TransactionType = TransactionType.Income
            });
        }

        protected async Task ChangeCategoryEvent(ChangeEventArgs eventArgs)
        {
            var categoryId = eventArgs.Value?.ToString();

            if (!string.IsNullOrWhiteSpace(categoryId))
            {
                SubCategoryList = await _mediator.Send(new GetSubCategoriesListQuery
                {
                    CategoryId = Guid.Parse(categoryId)
                });
            }

            CreateTransactionCommand.SubCategoryId = "";

            StateHasChanged();
        }

        protected async Task CreateNewIncome(EditContext context)
        {
            CreateTransactionCommand.UserId = Guid.Parse(_currentUserService.User.Id);
            CreateTransactionCommand.TransactionType = TransactionType.Income;

            var createdTransaction = await _mediator.Send(CreateTransactionCommand);

            CreateTransactionCommand = new CreateTransactionCommand();

            Transactions.Add(createdTransaction);

            StateHasChanged();
        }
    }
}
