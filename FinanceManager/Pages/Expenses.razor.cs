using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Application.Common.Models;

namespace FinanceManager.Pages
{
    public partial class Expenses
    {
        protected IEnumerable<TransactionVM> Transactions { get; set; }
    }
}
