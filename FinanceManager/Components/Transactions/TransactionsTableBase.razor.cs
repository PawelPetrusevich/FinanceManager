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

namespace FinanceManager.Components.Transactions
{
    public partial class TransactionsTableBase : ComponentBase
    {
        [Parameter]
        public List<TransactionVM> Transactions { get; set; } = new List<TransactionVM>();
    }
}
