using FinanceManager.Application.Accounts.Commands;
using FinanceManager.Application.Accounts.Queries;
using FinanceManager.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AccountVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccountVMs(Guid? userId)
        {
            try
            {
                if (!userId.HasValue)
                {
                    return BadRequest();
                }

                var accaunts = await _mediator.Send(new GetAccountsListQuery
                {
                    UserId = userId.Value
                });

                if (accaunts != null && accaunts.Any())
                {
                    return Ok(accaunts);
                }

                return NotFound();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error.");
            }


        }

        public async Task<IActionResult> CreateAccount([FromBody]CreateAccountCommand command)
        {
            throw new Exception();
        }
    }
}
