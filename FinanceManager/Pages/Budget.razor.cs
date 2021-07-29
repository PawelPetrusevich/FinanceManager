using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Application.Budget.Queries;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace FinanceManager.Pages
{
    public partial class Budget
    {
        [Inject] public IMediator _mediator { get; set; }

        [Inject] public ICurrentUserService _userService { get; set; }

        public BudgetStatisticVM BudgetStatisticVm { get; set; } = new BudgetStatisticVM();

        

        protected override async Task OnInitializedAsync()
        {
            Guid.TryParse(_userService.User.BudgetId, out var budgetId);

            BudgetStatisticVm = await _mediator.Send(new GetBudgetStatisticQuery
            {
                BudgetId = budgetId
            });

            await base.OnInitializedAsync();
        }
    }
}
