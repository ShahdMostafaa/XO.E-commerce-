using Microsoft.EntityFrameworkCore.Migrations;

namespace XOFinal.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Accounts_CardNumberNavigationAccountId",
                table: "Bills");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Bills_CardNumberNavigationAccountId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CardNumberNavigationAccountId",
                table: "Bills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardNumberNavigationAccountId",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<int>(type: "int", nullable: false),
                    CustName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Invoice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CardNumberNavigationAccountId",
                table: "Bills",
                column: "CardNumberNavigationAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Accounts_CardNumberNavigationAccountId",
                table: "Bills",
                column: "CardNumberNavigationAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
