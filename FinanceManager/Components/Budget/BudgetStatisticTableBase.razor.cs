using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Application.Budget.Queries;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace FinanceManager.Components.Budget
{
    public partial class BudgetStatisticTableBase
    {
        [Parameter] public List<BudgetStatisticItemVM> Items { get; set; } = new List<BudgetStatisticItemVM>();
    }
}
