﻿// <auto-generated />
using System;
using FinanceManager.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinanceManager.Data.Migrations
{
    [DbContext(typeof(FinanceManagerContext))]
    partial class FinanceManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinanceManager.Common.DbModels.AccountDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AccauntSum")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("FinanceManager.Common.DbModels.BudgetDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("FinanceManager.Common.DbModels.TransactionCategoryDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TransactionCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(745),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9134),
                            Name = "Автомобиль",
                            TransactionType = 0
                        },
                        new
                        {
                            Id = new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9669),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9674),
                            Name = "Регулярные платежи",
                            TransactionType = 0
                        },
                        new
                        {
                            Id = new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9677),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9679),
                            Name = "Развлечения",
                            TransactionType = 0
                        },
                        new
                        {
                            Id = new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9682),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9683),
                            Name = "Медицина",
                            TransactionType = 0
                        },
                        new
                        {
                            Id = new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9686),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9687),
                            Name = "Продукты питания",
                            TransactionType = 0
                        },
                        new
                        {
                            Id = new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9692),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9693),
                            Name = "Общественный транспорт",
                            TransactionType = 0
                        },
                        new
                        {
                            Id = new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9696),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9697),
                            Name = "Непродуктовые покупки",
                            TransactionType = 0
                        },
                        new
                        {
                            Id = new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9700),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9701),
                            Name = "Услуги",
                            TransactionType = 0
                        },
                        new
                        {
                            Id = new Guid("9525e3cc-c1db-404b-960b-717c09297602"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9703),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9704),
                            Name = "Кредиты",
                            TransactionType = 0
                        },
                        new
                        {
                            Id = new Guid("c468f57a-9771-4427-97ea-d174827803c7"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9708),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9709),
                            Name = "Прочие расходы",
                            TransactionType = 0
                        },
                        new
                        {
                            Id = new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9712),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9713),
                            Name = "Зарплата",
                            TransactionType = 1
                        },
                        new
                        {
                            Id = new Guid("25d1f35e-fa4c-4026-8d5f-01f85491cd59"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9716),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9717),
                            Name = "Аренда",
                            TransactionType = 1
                        },
                        new
                        {
                            Id = new Guid("20e41593-9451-4277-84ab-d10e8f9af04e"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9720),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9721),
                            Name = "Прочие даходы",
                            TransactionType = 1
                        });
                });

            modelBuilder.Entity("FinanceManager.Common.DbModels.TransactionDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SubCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("FinanceManager.Common.DbModels.TransactionSubCategoryDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("TransactionSubCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("956183af-dd1d-41e0-b1b4-a93147b2753a"),
                            CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3610),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3617),
                            Name = "Топливо"
                        },
                        new
                        {
                            Id = new Guid("2e97f11f-731e-4678-9ab4-a2f50648aaf8"),
                            CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3648),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3649),
                            Name = "Мойка"
                        },
                        new
                        {
                            Id = new Guid("c29ec21d-09d5-4628-be42-daa2a9dd2761"),
                            CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3653),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3654),
                            Name = "Ремонт"
                        },
                        new
                        {
                            Id = new Guid("991b4e31-ccd3-44a8-a01d-fb04b4b661a1"),
                            CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3657),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3658),
                            Name = "Обслуживание"
                        },
                        new
                        {
                            Id = new Guid("c3fcade2-0375-400f-a2bc-310e13119834"),
                            CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3661),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3662),
                            Name = "Страховка"
                        },
                        new
                        {
                            Id = new Guid("3db8c703-5d30-4e38-8427-47b90ad2e6cb"),
                            CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3669),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3670),
                            Name = "Стоянка"
                        },
                        new
                        {
                            Id = new Guid("4071a2a4-cae8-4567-9bb2-d7be9c1c5756"),
                            CategoryId = new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3673),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3674),
                            Name = "Штраф"
                        },
                        new
                        {
                            Id = new Guid("93c048d8-a82f-4914-9bdd-3b2969063282"),
                            CategoryId = new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3677),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3678),
                            Name = "Телефон"
                        },
                        new
                        {
                            Id = new Guid("e4d59f03-d843-4f60-b32d-f109bb539053"),
                            CategoryId = new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3681),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3683),
                            Name = "Интернет"
                        },
                        new
                        {
                            Id = new Guid("565087a5-790c-47de-8f51-d90f054a9806"),
                            CategoryId = new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3690),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3691),
                            Name = "Коммунальные услуги"
                        },
                        new
                        {
                            Id = new Guid("8004dda8-04a3-45e5-9a2d-9cb7462c2f15"),
                            CategoryId = new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3694),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3695),
                            Name = "Электроенергия"
                        },
                        new
                        {
                            Id = new Guid("766a44ca-2e0f-46cd-babd-cddbd4e8ab8e"),
                            CategoryId = new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3698),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3699),
                            Name = "Ресторан"
                        },
                        new
                        {
                            Id = new Guid("5581e549-dc16-4d73-bb34-a8c88574b9fb"),
                            CategoryId = new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3702),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3703),
                            Name = "Кинатеатр"
                        },
                        new
                        {
                            Id = new Guid("13bedc8f-1ce0-41aa-9efe-b5c8b35ed98b"),
                            CategoryId = new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3706),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3707),
                            Name = "Аттракцион"
                        },
                        new
                        {
                            Id = new Guid("5660c6cf-74cf-45d0-97b4-cc2b5fa42e62"),
                            CategoryId = new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3711),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3712),
                            Name = "Лекарство"
                        },
                        new
                        {
                            Id = new Guid("015116c1-173f-435a-8dd2-e79c5fe04619"),
                            CategoryId = new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3715),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3716),
                            Name = "Услуги медцентров"
                        },
                        new
                        {
                            Id = new Guid("3038bbda-8731-4c8b-820d-0214cee2eedd"),
                            CategoryId = new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3719),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3720),
                            Name = "Продукты"
                        },
                        new
                        {
                            Id = new Guid("e9f5ac38-506d-4cd1-942a-1a743bb186ec"),
                            CategoryId = new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3726),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3727),
                            Name = "Алкоголь"
                        },
                        new
                        {
                            Id = new Guid("a6da6e39-776f-4eec-ac65-247a479d10df"),
                            CategoryId = new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3730),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3731),
                            Name = "Сладости"
                        },
                        new
                        {
                            Id = new Guid("c1312c1e-2208-4b37-b702-fd5b716163c1"),
                            CategoryId = new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3734),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3735),
                            Name = "Общественный транспорт"
                        },
                        new
                        {
                            Id = new Guid("d5716967-653a-4c54-ae34-6bf84c3ad2b4"),
                            CategoryId = new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3738),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3739),
                            Name = "Такси"
                        },
                        new
                        {
                            Id = new Guid("6701040b-21c3-4645-a56b-186521913789"),
                            CategoryId = new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3742),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3743),
                            Name = "Химия"
                        },
                        new
                        {
                            Id = new Guid("ba9b0ef8-d22c-4aad-be66-9d9f884476b4"),
                            CategoryId = new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3746),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3747),
                            Name = "Косметика"
                        },
                        new
                        {
                            Id = new Guid("f64341ea-fbbb-4d56-8fd3-55b372df3f43"),
                            CategoryId = new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3750),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3751),
                            Name = "Алик"
                        },
                        new
                        {
                            Id = new Guid("54eb7bb3-2e38-4ba6-9282-a6fe234fa2a4"),
                            CategoryId = new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3754),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3755),
                            Name = "Одежда"
                        },
                        new
                        {
                            Id = new Guid("20918422-39b3-4802-b290-78a8d506ee29"),
                            CategoryId = new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3760),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3761),
                            Name = "Стрижка"
                        },
                        new
                        {
                            Id = new Guid("cd8f6596-fd8d-4208-b138-e9222e2a3e2f"),
                            CategoryId = new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3764),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3765),
                            Name = "Маникюр"
                        },
                        new
                        {
                            Id = new Guid("a37839bb-f7ad-4020-9e53-a5189b528c99"),
                            CategoryId = new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3768),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3769),
                            Name = "Салон красоты"
                        },
                        new
                        {
                            Id = new Guid("34f3bbac-4eab-4c28-9597-760a6a2aaed6"),
                            CategoryId = new Guid("9525e3cc-c1db-404b-960b-717c09297602"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3772),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3773),
                            Name = "Кредит на авто"
                        },
                        new
                        {
                            Id = new Guid("4fcb3562-16da-4d30-9fae-761280af8f5e"),
                            CategoryId = new Guid("9525e3cc-c1db-404b-960b-717c09297602"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3777),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3777),
                            Name = "Кредит на ПК"
                        },
                        new
                        {
                            Id = new Guid("32a023df-ddf1-4a07-b0b9-cdf3de9d9a16"),
                            CategoryId = new Guid("c468f57a-9771-4427-97ea-d174827803c7"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3781),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3782),
                            Name = "Подарки"
                        },
                        new
                        {
                            Id = new Guid("7f921b12-b939-470c-a1a5-f17729a1e27a"),
                            CategoryId = new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3785),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3786),
                            Name = "Зарплата"
                        },
                        new
                        {
                            Id = new Guid("fb49a92b-108b-4cca-bf7e-f84aff47c01d"),
                            CategoryId = new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3789),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3790),
                            Name = "Аванс"
                        },
                        new
                        {
                            Id = new Guid("328d3cbf-5404-4dcc-9678-da510c91702e"),
                            CategoryId = new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3796),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3797),
                            Name = "Премия"
                        },
                        new
                        {
                            Id = new Guid("85a2efbe-2376-45d6-9673-aecd11be1007"),
                            CategoryId = new Guid("25d1f35e-fa4c-4026-8d5f-01f85491cd59"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3800),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3801),
                            Name = "Аренда квартиры"
                        },
                        new
                        {
                            Id = new Guid("12203339-7700-4fb2-90d0-68c0e84aa98b"),
                            CategoryId = new Guid("20e41593-9451-4277-84ab-d10e8f9af04e"),
                            CreatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3804),
                            LastUpdatedDate = new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3805),
                            Name = "Подарки"
                        });
                });

            modelBuilder.Entity("FinanceManager.Common.DbModels.AccountDbModel", b =>
                {
                    b.HasOne("FinanceManager.Common.DbModels.BudgetDbModel", "Budget")
                        .WithMany("Accounts")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");
                });

            modelBuilder.Entity("FinanceManager.Common.DbModels.TransactionDbModel", b =>
                {
                    b.HasOne("FinanceManager.Common.DbModels.AccountDbModel", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceManager.Common.DbModels.TransactionCategoryDbModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceManager.Common.DbModels.TransactionSubCategoryDbModel", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Category");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("FinanceManager.Common.DbModels.TransactionSubCategoryDbModel", b =>
                {
                    b.HasOne("FinanceManager.Common.DbModels.TransactionCategoryDbModel", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FinanceManager.Common.DbModels.AccountDbModel", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("FinanceManager.Common.DbModels.BudgetDbModel", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("FinanceManager.Common.DbModels.TransactionCategoryDbModel", b =>
                {
                    b.Navigation("SubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
