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
    public partial class Expenses
    {
        [Inject] private IMediator _mediator { get; set; }

        [Inject] private ICurrentUserService _currentUserService { get; set; }

        [Inject] private ICurrencyService _currencyService { get; set; }

        protected List<TransactionVM> Transactions { get; set; } = new List<TransactionVM>();

        protected CreateExpenseCommand CreateExpenseCommand { get; set; } = new CreateExpenseCommand();

        protected IEnumerable<AccountVM> UserBudgetAccounts { get; set; } = new List<AccountVM>();

        protected IDictionary<Guid, string> CategoryList { get; set; } = new Dictionary<Guid, string>();

        protected IDictionary<Guid, string> SubCategoryList { get; set; } = new Dictionary<Guid, string>();

        protected IEnumerable<string> CurrencyList { get; set; } = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            CurrencyList = _currencyService.GetAllCurrency();

            UserBudgetAccounts = await _mediator.Send(new GetAccountListForBudgetQuery
            {
                BudgetId = Guid.Parse(_currentUserService.User.BudgetId)
            });

            Transactions = await _mediator.Send(new GetExpensesListQuery
            {
                UserId = Guid.Parse(_currentUserService.User.Id)
            });

            CategoryList = await _mediator.Send(new GetCategoriesListQuery
            {
                TransactionType = TransactionType.Cunsumption
            });
            
            await base.OnInitializedAsync();
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

            CreateExpenseCommand.SubCategoryId = "";

            StateHasChanged();
        }

        protected async Task CreateNewExpense(EditContext context)
        {
            CreateExpenseCommand.UserId = Guid.Parse(_currentUserService.User.Id);

            var createdTransaction = await _mediator.Send(CreateExpenseCommand);

            CreateExpenseCommand = new CreateExpenseCommand();

            Transactions.Add(createdTransaction);

            StateHasChanged();
        }
    }
}
