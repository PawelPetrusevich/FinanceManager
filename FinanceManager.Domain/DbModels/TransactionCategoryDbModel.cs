using System.Collections.Generic;

namespace FinanceManager.Domain.DbModels
{
    public class TransactionCategoryDbModel : AuditDbModel
    {
        public string Name { get; set; }

        public string TransactionType { get; set; }

        public ICollection<TransactionSubCategoryDbModel> SubCategories { get; set; }

    }
}