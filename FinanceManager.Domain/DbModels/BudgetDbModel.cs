using System;
using System.Collections.Generic;

namespace FinanceManager.Domain.DbModels
{
    public class BudgetDbModel : AuditDbModel
    {
        public Guid AdminId { get; set; }

        public virtual ICollection<AccountDbModel> Accounts { get; set; }
    }
}