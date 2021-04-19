using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceManager.Persistence.Migrations
{
    public partial class DomainInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccauntSum = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionSubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionSubCategories_TransactionCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TransactionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TransactionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionSubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "TransactionSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TransactionCategories",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "TransactionType" },
                values: new object[,]
                {
                    { new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 4, 1, 17, 43, 42, 538, DateTimeKind.Local).AddTicks(370), new DateTime(2021, 4, 1, 17, 43, 42, 538, DateTimeKind.Local).AddTicks(9665), "Автомобиль", 0 },
                    { new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(205), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(210), "Регулярные платежи", 0 },
                    { new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(214), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(215), "Развлечения", 0 },
                    { new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(218), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(219), "Медицина", 0 },
                    { new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(222), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(223), "Продукты питания", 0 },
                    { new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(229), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(230), "Общественный транспорт", 0 },
                    { new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(233), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(234), "Непродуктовые покупки", 0 },
                    { new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(237), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(238), "Услуги", 0 },
                    { new Guid("9525e3cc-c1db-404b-960b-717c09297602"), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(241), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(242), "Кредиты", 0 },
                    { new Guid("c468f57a-9771-4427-97ea-d174827803c7"), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(245), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(246), "Прочие расходы", 0 },
                    { new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(249), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(250), "Зарплата", 1 },
                    { new Guid("25d1f35e-fa4c-4026-8d5f-01f85491cd59"), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(253), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(254), "Доход от аренды", 1 },
                    { new Guid("20e41593-9451-4277-84ab-d10e8f9af04e"), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(257), new DateTime(2021, 4, 1, 17, 43, 42, 539, DateTimeKind.Local).AddTicks(258), "Прочие даходы", 1 }
                });

            migrationBuilder.InsertData(
                table: "TransactionSubCategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("c042f085-0144-4eed-8897-90cce7e452b8"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3915), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3925), "Топливо" },
                    { new Guid("ba12c310-6f45-47ed-a02e-b9c3d8aefffd"), new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4054), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4055), "Такси" },
                    { new Guid("f34fc0fc-56f4-4f5c-bc9c-40a847d0f700"), new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4059), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4060), "Химия" },
                    { new Guid("a0f2927b-c0c2-4040-8615-c95a204637d5"), new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4063), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4064), "Косметика" },
                    { new Guid("74790522-d12e-4557-929f-e68edb507ffa"), new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4067), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4068), "Алик" },
                    { new Guid("de94bd9f-0a37-47d4-a74c-fab623371e07"), new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4071), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4072), "Одежда" },
                    { new Guid("05cc5aa4-fb5b-4644-b31b-034e620f69f3"), new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4075), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4076), "Стрижка" },
                    { new Guid("f62459bd-04eb-4ad4-a709-fd70847c77fe"), new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4050), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4051), "Общественный транспорт" },
                    { new Guid("c07bd8b5-de84-48f0-88b5-cc2174471416"), new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4079), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4080), "Маникюр" },
                    { new Guid("441ae8ef-7173-4524-97f3-0b741eada82e"), new Guid("9525e3cc-c1db-404b-960b-717c09297602"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4089), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4090), "Кредит на авто" },
                    { new Guid("a81d13b8-79d5-47f0-9fb6-0a1f46cb8038"), new Guid("9525e3cc-c1db-404b-960b-717c09297602"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4093), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4094), "Кредит на ПК" },
                    { new Guid("97967a6c-d1b4-4ef9-8a76-030abe9b8836"), new Guid("c468f57a-9771-4427-97ea-d174827803c7"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4097), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4098), "Подарки" },
                    { new Guid("47cf5a14-7ff4-4bf6-a7f0-df1b04683b57"), new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4101), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4102), "Зарплата" },
                    { new Guid("0a5574f0-1f2c-49b6-945f-6cf173dd68c8"), new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4106), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4107), "Аванс" },
                    { new Guid("ef216a2f-6aed-4e66-a6d3-da979697e6ad"), new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4111), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4112), "Премия" },
                    { new Guid("a0e479c3-10bb-497f-bccb-a556d611840d"), new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4085), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4086), "Салон красоты" },
                    { new Guid("15d9a392-4b70-4461-9319-7b598b00573e"), new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4044), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4045), "Сладости" },
                    { new Guid("471fe170-2494-4627-b4bd-1cac0133f03f"), new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4040), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4041), "Алкоголь" },
                    { new Guid("7d23b5c1-cf60-4326-9a3b-d6f0a6ee0064"), new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4035), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4036), "Продукты" },
                    { new Guid("5570b7c1-025a-41d2-af45-8f05d74c9937"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3947), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3948), "Мойка" },
                    { new Guid("3cb89582-c39b-408c-92c0-be1777ce6d00"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3952), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3953), "Ремонт" },
                    { new Guid("d75b8dc4-49c0-4044-af37-ff39e0f1a873"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3973), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3974), "Обслуживание" },
                    { new Guid("329d71de-cb1a-4891-8171-054facfad305"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3978), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3979), "Страховка" },
                    { new Guid("2762fb88-5750-4dc6-afea-4e4933d188e4"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3985), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3986), "Стоянка" },
                    { new Guid("5ddfed7c-9fe8-44cb-a6f5-d8a040095fe6"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3989), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3990), "Штраф" },
                    { new Guid("147486db-2158-4bee-99da-c78be4a7fd3d"), new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3993), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3994), "Телефон" },
                    { new Guid("33d2262c-ba49-454d-8998-108a59f6f7b7"), new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3997), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(3998), "Интернет" },
                    { new Guid("102b9b4a-484c-46d9-aa56-588f98beaf34"), new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4002), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4003), "Коммунальные услуги" },
                    { new Guid("3cae7563-c709-46f4-874e-0256cdf4c048"), new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4007), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4008), "Электроенергия" },
                    { new Guid("736ff34c-b5ba-450c-8045-e5613c2c44a3"), new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4014), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4015), "Ресторан" },
                    { new Guid("1731eaea-e46c-4bcb-aee7-1331117b6719"), new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4018), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4019), "Кинатеатр" },
                    { new Guid("bebfebdb-d305-4352-a0d2-2aecb7cdd7a8"), new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4022), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4023), "Аттракцион" },
                    { new Guid("751c0e0d-1e88-403e-a5cb-66d119514407"), new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4026), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4027), "Лекарство" },
                    { new Guid("649a30d9-c548-46cf-9fff-30ee8dfb3e8a"), new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4030), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4031), "Услуги медцентров" },
                    { new Guid("c5abb7d9-5481-4be0-9c3d-051e6d909b4c"), new Guid("25d1f35e-fa4c-4026-8d5f-01f85491cd59"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4115), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4116), "Аренда квартиры" },
                    { new Guid("1a803e96-3797-4802-a884-94f938f1cf2e"), new Guid("20e41593-9451-4277-84ab-d10e8f9af04e"), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4121), new DateTime(2021, 4, 1, 17, 43, 42, 541, DateTimeKind.Local).AddTicks(4122), "Подарки" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BudgetId",
                table: "Accounts",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SubCategoryId",
                table: "Transactions",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSubCategories_CategoryId",
                table: "TransactionSubCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "TransactionSubCategories");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "TransactionCategories");
        }
    }
}
