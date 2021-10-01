using FinanceManager.Application.Accounts.Queries;
using FinanceManager.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceManager.Areas.Budget
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get all Account for user.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAccountVMs(string userId)
        {
            var accaunts = await _mediator.Send(new GetAccountsListQuery
            {
                UserId = Guid.Parse(userId)
            });

            return Ok(accaunts);
        }
    }
}
