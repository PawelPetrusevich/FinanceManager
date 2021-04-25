using System;
using System.Collections.Generic;
using FinanceManager.Application.Common.Enums;
using FinanceManager.Domain.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Persistence.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<TransactionCategoryDbModel>
    {
        public void Configure(EntityTypeBuilder<TransactionCategoryDbModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.SubCategories)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            SeedCategoryDbModels(builder);
        }

        public void SeedCategoryDbModels(EntityTypeBuilder<TransactionCategoryDbModel> builder)
        {
            var data = new List<TransactionCategoryDbModel>
            {
                new()
                {
                    Id = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                    Name = "Автомобиль",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Cunsumption.ToString()
                },
                new()
                {
                    Id = new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"),
                    Name = "Регулярные платежи",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Cunsumption.ToString()
                },
                new()
                {
                    Id = new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"),
                    Name = "Развлечения",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Cunsumption.ToString()
                },
                new()
                {
                    Id = new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"),
                    Name = "Медицина",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Cunsumption.ToString()
                },
                new()
                {
                    Id = new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"),
                    Name = "Продукты питания",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Cunsumption.ToString()
                },
                new()
                {
                    Id = new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"),
                    Name = "Общественный транспорт",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Cunsumption.ToString()
                },
                new()
                {
                    Id = new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"),
                    Name = "Непродуктовые покупки",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Cunsumption.ToString()
                },
                new()
                {
                    Id = new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"),
                    Name = "Услуги",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Cunsumption.ToString()
                },
                new()
                {
                    Id = new Guid("9525e3cc-c1db-404b-960b-717c09297602"),
                    Name = "Кредиты",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Cunsumption.ToString()
                },
                new()
                {
                    Id = new Guid("c468f57a-9771-4427-97ea-d174827803c7"),
                    Name = "Прочие расходы",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Cunsumption.ToString()
                },
                new()
                {
                    Id = new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"),
                    Name = "Зарплата",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Income.ToString()
                },
                new()
                {
                    Id = new Guid("25d1f35e-fa4c-4026-8d5f-01f85491cd59"),
                    Name = "Доход от аренды",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Income.ToString()
                },
                new()
                {
                    Id = new Guid("20e41593-9451-4277-84ab-d10e8f9af04e"),
                    Name = "Прочие даходы",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Income.ToString()
                }
            };

            builder.HasData(data);
        }
    }
}