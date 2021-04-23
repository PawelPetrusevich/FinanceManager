using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinanceManager.Application.Accounts.Commands;
using FinanceManager.Application.Accounts.Queries;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Pages
{
    public partial class Accounts
    {
        [Inject] protected ICurrencyService _currencyService { get; set; }

        [Inject] private IMediator _mediator { get; set; }

        [Inject] public ICurrentUserService _currentUserService { get; set; }

        private IEnumerable<string> CurrencyList { get; set; }

        public IEnumerable<AccountVM> AccountList { get; set; } = new List<AccountVM>();

        public CreateAccountCommand CreateAccountCommand { get; set; } = new CreateAccountCommand();


        protected override async Task OnInitializedAsync()
        {
            CurrencyList = _currencyService.GetAllCurrency();
            AccountList = await _mediator.Send(new GetAccountsListQuery
            {
                UserId = Guid.Parse(_currentUserService.User.Id)
            });

            await base.OnInitializedAsync();
        }

        private async Task CreateNewAccount(EditContext obj)
        {
            CreateAccountCommand.UserId = Guid.Parse(_currentUserService.User.Id);
            CreateAccountCommand.BudgetId = Guid.Parse(_currentUserService.User.BudgetId);

            await _mediator.Send(CreateAccountCommand);
        }

    }
}
