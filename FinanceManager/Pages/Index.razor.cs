using FinanceManager.Application.Charts.Queries;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models.Charts;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceManager.Pages
{
    public partial class Index
    {
        [Inject] public IMediator _mediator { get; set; }

        //[Inject] public ICurrentUserService _userService { get; set; }

        public IEnumerable<TransactionChartItem> TransactionChartItems { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var date = DateTime.UtcNow;

            TransactionChartItems = await _mediator.Send(new GetTransactionPieChartQuery { Month = date.Month-1, Year = date.Year }); 

            await base.OnInitializedAsync();
        }
    }
}
