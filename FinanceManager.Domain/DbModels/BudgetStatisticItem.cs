using System;

namespace FinanceManager.Domain.DbModels
{
    public class BudgetStatisticItem : AuditDbModel
    {
        public Guid ParentId { get; set; }

        public decimal CurrentSum { get; set; }

        public decimal PastSum { get; set; }
    }
}