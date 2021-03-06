using FinanceManager.Domain.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Persistence.Configuration
{
    public class BudgetDbModelConfiguration : IEntityTypeConfiguration<BudgetDbModel>
    {
        public void Configure(EntityTypeBuilder<BudgetDbModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Accounts)
                .WithOne(x=>x.Budget)
                .HasForeignKey(x=>x.BudgetId);
        }
    }
}