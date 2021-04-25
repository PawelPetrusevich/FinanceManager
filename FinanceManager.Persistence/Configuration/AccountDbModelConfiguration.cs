using FinanceManager.Domain.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Persistence.Configuration
{
    public class AccountDbModelConfiguration : IEntityTypeConfiguration<AccountDbModel>
    {
        public void Configure(EntityTypeBuilder<AccountDbModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany<TransactionDbModel>(x=>x.Transactions)
                .WithOne(x => x.Account)
                .HasForeignKey(x=>x.AccountId);

            builder.Property(x => x.AccauntSum)
                .HasColumnType("decimal(10,2)");
        }
    }
}