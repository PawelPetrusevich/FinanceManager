using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Application.Common.Enums;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Application.Transactions.Queries;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace FinanceManager.Pages
{
    public partial class Incomes
    {
        [Inject]private IMediator _mediator { get; set; }

        [Inject]private ICurrentUserService _currentUserService { get; set; }

        protected List<TransactionVM> Transactions { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Transactions = await _mediator.Send(new GetTransactionsListQuery
            {
                UserId = Guid.Parse(_currentUserService.User.Id),
                TransactionType = TransactionType.Income
            });
        }
    }
}
