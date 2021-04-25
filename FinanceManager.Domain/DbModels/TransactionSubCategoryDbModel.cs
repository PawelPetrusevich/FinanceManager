using System;

namespace FinanceManager.Domain.DbModels
{
    public class TransactionSubCategoryDbModel :AuditDbModel
    {
        public string Name { get; set; }

        public Guid CategoryId { get; set; }
        
        public TransactionCategoryDbModel Category { get; set; }
    }
}