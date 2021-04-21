using System;

namespace FinanceManager.Common.DbModels
{
    public class AuditDbModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}