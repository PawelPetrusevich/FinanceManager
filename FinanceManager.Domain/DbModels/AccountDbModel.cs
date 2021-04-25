using System;
using System.Collections.Generic;

namespace FinanceManager.Domain.DbModels
{
    public class AccountDbModel : AuditDbModel
    {
        public decimal AccauntSum { get; set; }

        public string AccountName { get; set; }

        public Guid UserId { get; set; }

        public string Currency { get; set; }

        public Guid BudgetId { get; set; }

        public virtual BudgetDbModel Budget { get; set; }

        public virtual ICollection<TransactionDbModel> Transactions { get; set; }
    }
}