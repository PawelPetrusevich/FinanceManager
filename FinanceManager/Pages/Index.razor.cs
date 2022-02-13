using FinanceManager.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace FinanceManager.Pages
{
    public partial class Index
    {
        [Inject] public IMediator _mediator { get; set; }

        [Inject] public ICurrentUserService _userService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var date = DateTime.UtcNow;

            await base.OnInitializedAsync();
        }
    }
}
