using System;
using FinanceManager.Common.Enums;

namespace FinanceManager.Common.DbModels
{
    public class TransactionDbModel : AuditDbModel
    {
        public decimal Value { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        
        public virtual TransactionCategoryDbModel Category { get; set; }

        public Guid SubCategoryId { get; set; }

        public virtual TransactionSubCategoryDbModel SubCategory { get; set; }

        public TransactionType TransactionType { get; set; }

        public Guid AccountId { get; set; }

        public virtual AccountDbModel Account { get; set; }
    }
}