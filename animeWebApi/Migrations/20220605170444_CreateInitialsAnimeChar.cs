using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace animeWebApi.Migrations
{
    public partial class CreateInitialsAnimeChar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    level = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    primaryAttack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secundaryAttack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    specialAttack = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
