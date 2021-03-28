using FinanceManager.Common.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Data.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<TransactionDbModel>
    {
        public void Configure(EntityTypeBuilder<TransactionDbModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x=>x.CategoryId);

            builder.HasOne(x => x.SubCategory)
                .WithMany()
                .HasForeignKey(x=>x.SubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.TransactionType)
                .HasConversion<int>();

            builder.Property(x => x.Value)
                .HasColumnType("decimal(10,2)");
        }
    }
}