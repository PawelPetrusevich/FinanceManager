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
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace FinanceManager.Components.Transactions
{
    public partial class TransactionEditForm : ComponentBase
    {
        [Parameter]
        public TransactionType TransactionType { get; set; }

        [Parameter] 
        public EventCallback<TransactionVM> AddNewTransactionCallback { get; set; }

        [Inject] private IMediator _mediator { get; set; }

        [Inject] private ICurrentUserService _currentUserService { get; set; }

        [Inject] private ICurrencyService _currencyService { get; set; }

        protected IEnumerable<AccountVM> UserBudgetAccounts { get; set; } = new List<AccountVM>();

        protected IDictionary<Guid, string> CategoryList { get; set; } = new Dictionary<Guid, string>();

        protected IDictionary<Guid, string> SubCategoryList { get; set; } = new Dictionary<Guid, string>();

        protected CreateTransactionCommand CreateTransactionCommand { get; set; } = new();

        protected IEnumerable<string> CurrencyList { get; set; } = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            CurrencyList = _currencyService.GetAllCurrency();

            UserBudgetAccounts = await _mediator.Send(new GetAccountListForBudgetQuery
            {
                BudgetId = Guid.Parse(_currentUserService.User.BudgetId)
            });

            CategoryList = await _mediator.Send(new GetCategoriesListQuery
            {
                TransactionType = TransactionType
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

            CreateTransactionCommand.SubCategoryId = "";

            StateHasChanged();
        }

        protected async Task CreateNewExpense(EditContext context)
        {
            CreateTransactionCommand.UserId = Guid.Parse(_currentUserService.User.Id);
            CreateTransactionCommand.TransactionType = TransactionType;

            var createdTransaction = await _mediator.Send(CreateTransactionCommand);

            CreateTransactionCommand = new CreateTransactionCommand();

            await AddNewTransactionCallback.InvokeAsync(createdTransaction);

            StateHasChanged();
        }
    }
}
