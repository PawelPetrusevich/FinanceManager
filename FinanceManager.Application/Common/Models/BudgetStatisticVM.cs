using System.Collections.Generic;

namespace FinanceManager.Application.Common.Models
{
    public class BudgetStatisticVM
    {
        public List<BudgetStatisticItemVM> StatisticItems { get; set; } = new List<BudgetStatisticItemVM>();
    }
}