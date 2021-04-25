using System;

namespace FinanceManager.Domain.DbModels
{
    public class TransactionDbModel : AuditDbModel
    {
        public decimal Value { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        
        public virtual TransactionCategoryDbModel Category { get; set; }

        public Guid SubCategoryId { get; set; }

        public virtual TransactionSubCategoryDbModel SubCategory { get; set; }

        public string TransactionType { get; set; }

        public Guid AccountId { get; set; }

        public virtual AccountDbModel Account { get; set; }

        public Guid? UserId { get; set; }

        public DateTime Date { get; set; }
    }
}