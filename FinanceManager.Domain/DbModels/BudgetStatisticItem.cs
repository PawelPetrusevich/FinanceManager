using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceManager.Domain.DbModels
{
    public class BudgetStatisticItem
    {
        public decimal Sum { get; set; }

        public string CategoryName { get; set; }

        public string SubCategoryName { get; set; }

        public string Currency { get; set; }

        public DateTime Date { get; set; }

        public string TransactionType { get; set; }
    }
}