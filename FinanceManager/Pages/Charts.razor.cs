using FinanceManager.Application.Charts.Queries;
using FinanceManager.Application.Common.Models.Charts;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceManager.Pages
{
    public partial class Charts
    {
        [Inject] public IMediator _mediator { get; set; }

        [Inject] public IJSRuntime JS { get; set; }

        private IJSObjectReference? module;

        protected override async Task OnInitializedAsync()
        {
            var date = DateTime.UtcNow;

            var transactionChartItems = await _mediator.Send(new GetTransactionPieChartQuery { Month = date.Month, Year = date.Year });

            await CreateChart(transactionChartItems);

            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                module = await JS.InvokeAsync<IJSObjectReference>("import", "./Pages/Charts.js");
            }
        }

        private async Task CreateChart(IEnumerable<TransactionChartItem> transactionChartItems)
        {
            if (module is null)
            {
                await JS.InvokeVoidAsync("draw", transactionChartItems);
            }
            else
            {
                await module.InvokeVoidAsync("draw", transactionChartItems);
            }
            
        }

        //async ValueTask IAsyncDisposable.DisposeAsync()
        //{
        //    if (module is not null)
        //    {
        //        await module.DisposeAsync();
        //    }
        //}
    }
}
