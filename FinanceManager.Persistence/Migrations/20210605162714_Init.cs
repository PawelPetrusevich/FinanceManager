using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceManager.Persistence.Migrations
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
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    { new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 6, 5, 19, 27, 13, 999, DateTimeKind.Local).AddTicks(3918), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(3377), "Автомобиль", "Cunsumption" },
                    { new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4124), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4129), "Регулярные платежи", "Cunsumption" },
                    { new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4136), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4137), "Развлечения", "Cunsumption" },
                    { new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4141), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4142), "Медицина", "Cunsumption" },
                    { new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4145), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4146), "Продукты питания", "Cunsumption" },
                    { new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4154), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4155), "Общественный транспорт", "Cunsumption" },
                    { new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4158), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4159), "Непродуктовые покупки", "Cunsumption" },
                    { new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4163), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4164), "Услуги", "Cunsumption" },
                    { new Guid("9525e3cc-c1db-404b-960b-717c09297602"), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4167), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4168), "Кредиты", "Cunsumption" },
                    { new Guid("c468f57a-9771-4427-97ea-d174827803c7"), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4172), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4173), "Прочие расходы", "Cunsumption" },
                    { new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4177), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4178), "Зарплата", "Income" },
                    { new Guid("25d1f35e-fa4c-4026-8d5f-01f85491cd59"), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4181), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4182), "Доход от аренды", "Income" },
                    { new Guid("20e41593-9451-4277-84ab-d10e8f9af04e"), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4186), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4187), "Прочие даходы", "Income" },
                    { new Guid("80427d6d-6adb-49cc-8073-d113efaa4591"), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4190), new DateTime(2021, 6, 5, 19, 27, 14, 0, DateTimeKind.Local).AddTicks(4191), "Путешествия", "Cunsumption" }
                });

            migrationBuilder.InsertData(
                table: "TransactionSubCategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("c2d324f3-6b82-4a58-8e03-b75dc72a5a51"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9458), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9470), "Топливо" },
                    { new Guid("f99470c6-4f9a-485b-9858-0ee2732e7af7"), new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9599), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9600), "Такси" },
                    { new Guid("fc8057e7-3c62-47b5-8c03-1f84c3c1d611"), new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9603), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9604), "Химия" },
                    { new Guid("aa8b7339-1845-4e94-a51e-dfb5ff9badc2"), new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9607), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9608), "Косметика" },
                    { new Guid("89af454a-7032-4fd4-a340-9039b845fd65"), new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9611), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9612), "Алик" },
                    { new Guid("f4b8abb6-30d1-480d-a547-0cd29bced68e"), new Guid("975b99ae-3b02-4fd1-9008-f9327b0e0538"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9615), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9616), "Одежда" },
                    { new Guid("c04735c6-51be-4190-b4af-839c9e56d023"), new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9619), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9620), "Стрижка" },
                    { new Guid("ef709e74-a689-4afa-a3a5-a8c91d3d7819"), new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9623), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9624), "Маникюр" },
                    { new Guid("f6a6379d-9560-4f0c-8888-6244fe050bf9"), new Guid("55f65fdb-59eb-4033-b4aa-9f7704b709f2"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9628), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9629), "Салон красоты" },
                    { new Guid("86a2e66b-b4a2-4462-af08-ee6d54e68639"), new Guid("9525e3cc-c1db-404b-960b-717c09297602"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9632), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9633), "Кредит на авто" },
                    { new Guid("b3e8e60a-9e5f-4aeb-8a0b-3ae3debfc18e"), new Guid("9525e3cc-c1db-404b-960b-717c09297602"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9636), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9637), "Кредит на ПК" },
                    { new Guid("ee794fa1-9322-45e2-b110-7ede7abbebf1"), new Guid("c468f57a-9771-4427-97ea-d174827803c7"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9640), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9641), "Подарки" },
                    { new Guid("dc442900-cd3b-47fe-8528-3e7bb8ec8f4d"), new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9644), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9645), "Зарплата" },
                    { new Guid("bc2374e9-d51a-495a-abc2-59f778c25ec7"), new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9648), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9650), "Аванс" },
                    { new Guid("ae981c5a-b6a5-4326-8ec1-4f474691e8ee"), new Guid("181336f7-1482-4c9f-9bff-f1cd186bf097"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9654), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9655), "Премия" },
                    { new Guid("c4b5dd41-6fdb-4239-b8e5-639ac1913820"), new Guid("25d1f35e-fa4c-4026-8d5f-01f85491cd59"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9703), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9704), "Аренда квартиры" },
                    { new Guid("6df7b7df-39d6-4b2e-8c29-506cad41388a"), new Guid("bcbdc4d2-3667-4b57-b2db-86bb5777d806"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9595), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9596), "Общественный транспорт" },
                    { new Guid("d8de02c9-af8b-457f-853e-599a4be3e091"), new Guid("20e41593-9451-4277-84ab-d10e8f9af04e"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9709), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9710), "Подарки" },
                    { new Guid("5197af3c-3aba-4552-961c-d6781e08a9f3"), new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9589), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9590), "Сладости" },
                    { new Guid("0c2f4ac7-1411-492a-913a-3a5177dc5c24"), new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9580), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9581), "Продукты" },
                    { new Guid("a2a55fb6-4eff-4b71-a6d4-ccd37d029059"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9491), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9492), "Мойка" },
                    { new Guid("7be33f4e-01e4-405b-8980-7002fe413392"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9496), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9497), "Ремонт" },
                    { new Guid("9f37a9b3-c97d-4242-8f5c-81876f25ace3"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9518), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9519), "Обслуживание" },
                    { new Guid("2fe4204d-b5ba-46de-a74f-86731c95c1a3"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9522), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9523), "Страховка" },
                    { new Guid("f88125e9-72f9-4727-99e6-ebff669b6e08"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9530), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9531), "Стоянка" },
                    { new Guid("bc4803b5-63dc-4fbb-b870-512ef114ee8f"), new Guid("06bfcef7-ae70-4040-beb9-8ab96620030b"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9535), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9536), "Штраф" },
                    { new Guid("90701628-eb40-4e31-afbc-21f5e37a9cd8"), new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9539), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9540), "Телефон" },
                    { new Guid("2a71fc0c-af77-459b-b75e-d3999f3f78dd"), new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9543), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9544), "Интернет" },
                    { new Guid("c4c4a59b-c662-49a3-b8c6-2e107cf77447"), new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9548), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9549), "Коммунальные услуги" },
                    { new Guid("a3b08375-941f-43fa-90d1-1eda2be9072a"), new Guid("6169f354-c9f8-48ac-bf4e-eca2f2b2922b"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9552), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9553), "Электроенергия" },
                    { new Guid("320459c2-ccf7-4393-a3bb-3f6412e93b5f"), new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9559), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9560), "Ресторан" },
                    { new Guid("63a4deee-ff2c-4b22-81c0-e34bc7c4e88e"), new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9563), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9564), "Кинатеатр" },
                    { new Guid("1ddf27c9-171b-4fc7-82e0-78cec3138949"), new Guid("1c09b880-cc78-4a32-9c64-85010fcabf66"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9567), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9568), "Аттракцион" },
                    { new Guid("cd756a0d-e982-40c8-beb6-70d457f6fe2a"), new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9571), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9572), "Лекарство" },
                    { new Guid("d6361978-6e63-4f33-b92d-b93672c8962e"), new Guid("fbde9320-81f0-495f-a9ba-35ed8e4922ce"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9575), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9576), "Услуги медцентров" },
                    { new Guid("c1297919-73f6-448d-a128-987269b306dd"), new Guid("c1ce6959-3af6-410a-8427-9a173654da0d"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9585), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9586), "Алкоголь" },
                    { new Guid("fd8d2326-6e30-42a9-80ec-1d2f841e2026"), new Guid("80427d6d-6adb-49cc-8073-d113efaa4591"), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9713), new DateTime(2021, 6, 5, 19, 27, 14, 2, DateTimeKind.Local).AddTicks(9714), "ЕГИПЕТ(6/6/21 - 20/6/21)" }
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
