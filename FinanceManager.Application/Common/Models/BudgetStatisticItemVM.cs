using System.Collections.Generic;
using FinanceManager.Application.Common.Enums;

namespace FinanceManager.Application.Common.Models
{
    public class BudgetStatisticItemVM
    {
        public decimal Sum { get; set; }

        public decimal SumPrevious { get; set; }

        public string Name { get; set; }

        public string TransactionType { get; set; }

        public IEnumerable<BudgetStatisticItemVM> ChildItems { get; set; }
    }
}