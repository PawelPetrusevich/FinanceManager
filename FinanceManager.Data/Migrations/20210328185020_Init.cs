using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceManager.Data.Migrations
{
    public partial class Init : Migration
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
                    { new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(745), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9134), "Автомобиль", 0 },
                    { new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9669), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9674), "Регулярные платежи", 0 },
                    { new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9677), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9679), "Развлечения", 0 },
                    { new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9682), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9683), "Медицина", 0 },
                    { new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9686), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9687), "Продукты питания", 0 },
                    { new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9692), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9693), "Общественный транспорт", 0 },
                    { new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9696), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9697), "Непродуктовые покупки", 0 },
                    { new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9700), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9701), "Услуги", 0 },
                    { new Guid("9525e3cc-c1db-404b-960b-717c09297602"), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9703), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9704), "Кредиты", 0 },
                    { new Guid("c468f57a-9771-4427-97ea-d174827803c7"), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9708), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9709), "Прочие расходы", 0 },
                    { new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9712), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9713), "Зарплата", 1 },
                    { new Guid("25d1f35e-fa4c-4026-8d5f-01f85491cd59"), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9716), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9717), "Аренда", 1 },
                    { new Guid("20e41593-9451-4277-84ab-d10e8f9af04e"), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9720), new DateTime(2021, 3, 28, 21, 50, 20, 51, DateTimeKind.Local).AddTicks(9721), "Прочие даходы", 1 }
                });

            migrationBuilder.InsertData(
                table: "TransactionSubCategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("956183af-dd1d-41e0-b1b4-a93147b2753a"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3610), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3617), "Топливо" },
                    { new Guid("d5716967-653a-4c54-ae34-6bf84c3ad2b4"), new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3738), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3739), "Такси" },
                    { new Guid("6701040b-21c3-4645-a56b-186521913789"), new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3742), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3743), "Химия" },
                    { new Guid("ba9b0ef8-d22c-4aad-be66-9d9f884476b4"), new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3746), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3747), "Косметика" },
                    { new Guid("f64341ea-fbbb-4d56-8fd3-55b372df3f43"), new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3750), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3751), "Алик" },
                    { new Guid("54eb7bb3-2e38-4ba6-9282-a6fe234fa2a4"), new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3754), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3755), "Одежда" },
                    { new Guid("20918422-39b3-4802-b290-78a8d506ee29"), new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3760), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3761), "Стрижка" },
                    { new Guid("c1312c1e-2208-4b37-b702-fd5b716163c1"), new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3734), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3735), "Общественный транспорт" },
                    { new Guid("cd8f6596-fd8d-4208-b138-e9222e2a3e2f"), new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3764), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3765), "Маникюр" },
                    { new Guid("34f3bbac-4eab-4c28-9597-760a6a2aaed6"), new Guid("9525e3cc-c1db-404b-960b-717c09297602"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3772), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3773), "Кредит на авто" },
                    { new Guid("4fcb3562-16da-4d30-9fae-761280af8f5e"), new Guid("9525e3cc-c1db-404b-960b-717c09297602"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3777), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3777), "Кредит на ПК" },
                    { new Guid("32a023df-ddf1-4a07-b0b9-cdf3de9d9a16"), new Guid("c468f57a-9771-4427-97ea-d174827803c7"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3781), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3782), "Подарки" },
                    { new Guid("7f921b12-b939-470c-a1a5-f17729a1e27a"), new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3785), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3786), "Зарплата" },
                    { new Guid("fb49a92b-108b-4cca-bf7e-f84aff47c01d"), new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3789), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3790), "Аванс" },
                    { new Guid("328d3cbf-5404-4dcc-9678-da510c91702e"), new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3796), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3797), "Премия" },
                    { new Guid("a37839bb-f7ad-4020-9e53-a5189b528c99"), new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3768), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3769), "Салон красоты" },
                    { new Guid("a6da6e39-776f-4eec-ac65-247a479d10df"), new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3730), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3731), "Сладости" },
                    { new Guid("e9f5ac38-506d-4cd1-942a-1a743bb186ec"), new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3726), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3727), "Алкоголь" },
                    { new Guid("3038bbda-8731-4c8b-820d-0214cee2eedd"), new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3719), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3720), "Продукты" },
                    { new Guid("2e97f11f-731e-4678-9ab4-a2f50648aaf8"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3648), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3649), "Мойка" },
                    { new Guid("c29ec21d-09d5-4628-be42-daa2a9dd2761"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3653), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3654), "Ремонт" },
                    { new Guid("991b4e31-ccd3-44a8-a01d-fb04b4b661a1"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3657), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3658), "Обслуживание" },
                    { new Guid("c3fcade2-0375-400f-a2bc-310e13119834"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3661), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3662), "Страховка" },
                    { new Guid("3db8c703-5d30-4e38-8427-47b90ad2e6cb"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3669), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3670), "Стоянка" },
                    { new Guid("4071a2a4-cae8-4567-9bb2-d7be9c1c5756"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3673), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3674), "Штраф" },
                    { new Guid("93c048d8-a82f-4914-9bdd-3b2969063282"), new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3677), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3678), "Телефон" },
                    { new Guid("e4d59f03-d843-4f60-b32d-f109bb539053"), new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3681), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3683), "Интернет" },
                    { new Guid("565087a5-790c-47de-8f51-d90f054a9806"), new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3690), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3691), "Коммунальные услуги" },
                    { new Guid("8004dda8-04a3-45e5-9a2d-9cb7462c2f15"), new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3694), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3695), "Электроенергия" },
                    { new Guid("766a44ca-2e0f-46cd-babd-cddbd4e8ab8e"), new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3698), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3699), "Ресторан" },
                    { new Guid("5581e549-dc16-4d73-bb34-a8c88574b9fb"), new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3702), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3703), "Кинатеатр" },
                    { new Guid("13bedc8f-1ce0-41aa-9efe-b5c8b35ed98b"), new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3706), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3707), "Аттракцион" },
                    { new Guid("5660c6cf-74cf-45d0-97b4-cc2b5fa42e62"), new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3711), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3712), "Лекарство" },
                    { new Guid("015116c1-173f-435a-8dd2-e79c5fe04619"), new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3715), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3716), "Услуги медцентров" },
                    { new Guid("85a2efbe-2376-45d6-9673-aecd11be1007"), new Guid("25d1f35e-fa4c-4026-8d5f-01f85491cd59"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3800), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3801), "Аренда квартиры" },
                    { new Guid("12203339-7700-4fb2-90d0-68c0e84aa98b"), new Guid("20e41593-9451-4277-84ab-d10e8f9af04e"), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3804), new DateTime(2021, 3, 28, 21, 50, 20, 54, DateTimeKind.Local).AddTicks(3805), "Подарки" }
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
