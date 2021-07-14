using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceManager.Identity.Migrations
{
    public partial class addBudgetField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BudgetId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "AspNetUsers");
        }
    }
}
