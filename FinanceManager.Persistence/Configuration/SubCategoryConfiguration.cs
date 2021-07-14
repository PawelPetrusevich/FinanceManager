using System;
using System.Collections.Generic;
using FinanceManager.Domain.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Persistence.Configuration
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<TransactionSubCategoryDbModel>
    {
        public void Configure(EntityTypeBuilder<TransactionSubCategoryDbModel> builder)
        {
            builder.HasKey(x => x.Id);

            SeedSubCategory(builder);
        }

        public void SeedSubCategory(EntityTypeBuilder<TransactionSubCategoryDbModel> builder)
        {
            var data = new List<TransactionSubCategoryDbModel>
            {
                // Категория авто
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Топливо",
                    CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Мойка",
                    CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ремонт",
                    CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Обслуживание",
                    CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Страховка",
                    CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Стоянка",
                    CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Штраф",
                    CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },

                //категория регулярные платежи
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Телефон",
                    CategoryId = new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Интернет",
                    CategoryId = new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Коммунальные услуги",
                    CategoryId = new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Электроенергия",
                    CategoryId = new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },

                // Категория развлечение
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ресторан",
                    CategoryId = new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Кинатеатр",
                    CategoryId = new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Аттракцион",
                    CategoryId = new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },

                // Категория Медицина
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Лекарство",
                    CategoryId = new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Услуги медцентров",
                    CategoryId = new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },

                // Категория продукты питания
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Продукты",
                    CategoryId = new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Алкоголь",
                    CategoryId = new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Сладости",
                    CategoryId = new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },

                // Категория общественный транспорт
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Общественный транспорт",
                    CategoryId = new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Такси",
                    CategoryId = new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },

                // Категория непродуктовые покупки
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Химия",
                    CategoryId = new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Косметика",
                    CategoryId = new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Алик",
                    CategoryId = new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Одежда",
                    CategoryId = new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },

                // Категоря услуги
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Стрижка",
                    CategoryId = new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Маникюр",
                    CategoryId = new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Салон красоты",
                    CategoryId = new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                
                // Категоря кредиты
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Кредит на авто",
                    CategoryId = new Guid("9525e3cc-c1db-404b-960b-717c09297602"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Кредит на ПК",
                    CategoryId = new Guid("9525e3cc-c1db-404b-960b-717c09297602"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                
                // Категоря прочие расходы
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Подарки",
                    CategoryId = new Guid("c468f57a-9771-4427-97ea-d174827803c7"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                
                // Категоря зарплата
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Зарплата",
                    CategoryId = new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Аванс",
                    CategoryId = new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Премия",
                    CategoryId = new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                
                // Категоря Доход от аренды
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Аренда квартиры",
                    CategoryId = new Guid("25d1f35e-fa4c-4026-8d5f-01f85491cd59"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },
                
                // Категоря прочие даходы
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Подарки",
                    CategoryId = new Guid("20e41593-9451-4277-84ab-d10e8f9af04e"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                },

                //
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "ЕГИПЕТ(6/6/21 - 20/6/21)",
                    CategoryId = new Guid("80427d6d-6adb-49cc-8073-d113efaa4591"),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                }
            };

            builder.HasData(data);
        }
    }
}