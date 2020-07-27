using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.DataAccess.Migrations
{
    public partial class addProductIdInKeypoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "KeyPoints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "State",
                table: "KeyPoints",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_KeyPoints_ProductId",
                table: "KeyPoints",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_KeyPoints_Products_ProductId",
                table: "KeyPoints",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyPoints_Products_ProductId",
                table: "KeyPoints");

            migrationBuilder.DropIndex(
                name: "IX_KeyPoints_ProductId",
                table: "KeyPoints");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "KeyPoints");

            migrationBuilder.DropColumn(
                name: "State",
                table: "KeyPoints");
        }
    }
}
