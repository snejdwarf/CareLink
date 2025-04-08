using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace carelinkAPI.Migrations
{
    public partial class MigrationAddName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Navn",
                table: "Personer",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Navn",
                table: "Personer");
        }
    }
}
