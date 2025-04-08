using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace carelinkAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opholdssteder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opholdssteder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OpholdsstedId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personer_Opholdssteder_OpholdsstedId",
                        column: x => x.OpholdsstedId,
                        principalTable: "Opholdssteder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonRelationer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonAId = table.Column<int>(type: "integer", nullable: false),
                    PersonBId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRelationer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRelationer_Personer_PersonAId",
                        column: x => x.PersonAId,
                        principalTable: "Personer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonRelationer_Personer_PersonBId",
                        column: x => x.PersonBId,
                        principalTable: "Personer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personer_OpholdsstedId",
                table: "Personer",
                column: "OpholdsstedId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRelationer_PersonAId",
                table: "PersonRelationer",
                column: "PersonAId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRelationer_PersonBId",
                table: "PersonRelationer",
                column: "PersonBId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonRelationer");

            migrationBuilder.DropTable(
                name: "Personer");

            migrationBuilder.DropTable(
                name: "Opholdssteder");
        }
    }
}
