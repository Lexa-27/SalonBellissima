using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonBellissima.Migrations
{
    /// <inheritdoc />
    public partial class Categorie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieID",
                table: "Serviciu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_CategorieID",
                table: "Serviciu",
                column: "CategorieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Categorie_CategorieID",
                table: "Serviciu",
                column: "CategorieID",
                principalTable: "Categorie",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Categorie_CategorieID",
                table: "Serviciu");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Serviciu_CategorieID",
                table: "Serviciu");

            migrationBuilder.DropColumn(
                name: "CategorieID",
                table: "Serviciu");
        }
    }
}
