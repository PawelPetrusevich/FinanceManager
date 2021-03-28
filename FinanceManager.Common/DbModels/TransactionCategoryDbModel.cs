using System;
using System.Collections.Generic;
using FinanceManager.Common.Enums;

namespace FinanceManager.Common.DbModels
{
    public class TransactionCategoryDbModel : AuditDbModel
    {
        public string Name { get; set; }

        public TransactionType TransactionType { get; set; }

        public ICollection<TransactionSubCategoryDbModel> SubCategories { get; set; }

    }
}