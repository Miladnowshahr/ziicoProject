using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.DataAccess.Migrations
{
    public partial class addStateInTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "State",
                table: "Tags",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Tags");
        }
    }
}
