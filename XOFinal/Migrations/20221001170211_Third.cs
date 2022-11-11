using Microsoft.EntityFrameworkCore.Migrations;

namespace XOFinal.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_Customers_CustId",
                table: "Favorite");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_Products_ProdId",
                table: "Favorite");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_Customers_CustId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_Products_ProdId",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorite",
                table: "Favorite");

            migrationBuilder.RenameTable(
                name: "Report",
                newName: "Reports");

            migrationBuilder.RenameTable(
                name: "Favorite",
                newName: "Favorites");

            migrationBuilder.RenameIndex(
                name: "IX_Report_ProdId",
                table: "Reports",
                newName: "IX_Reports_ProdId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorite_ProdId",
                table: "Favorites",
                newName: "IX_Favorites_ProdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                columns: new[] { "CustId", "ProdId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                columns: new[] { "CustId", "ProdId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Customers_CustId",
                table: "Favorites",
                column: "CustId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Products_ProdId",
                table: "Favorites",
                column: "ProdId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Customers_CustId",
                table: "Reports",
                column: "CustId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Products_ProdId",
                table: "Reports",
                column: "ProdId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Customers_CustId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Products_ProdId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Customers_CustId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Products_ProdId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "Report");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "Favorite");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ProdId",
                table: "Report",
                newName: "IX_Report_ProdId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_ProdId",
                table: "Favorite",
                newName: "IX_Favorite_ProdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                table: "Report",
                columns: new[] { "CustId", "ProdId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorite",
                table: "Favorite",
                columns: new[] { "CustId", "ProdId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Customers_CustId",
                table: "Favorite",
                column: "CustId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Products_ProdId",
                table: "Favorite",
                column: "ProdId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Customers_CustId",
                table: "Report",
                column: "CustId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Products_ProdId",
                table: "Report",
                column: "ProdId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
