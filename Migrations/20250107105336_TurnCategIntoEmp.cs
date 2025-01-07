using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonBellissima.Migrations
{
    /// <inheritdoc />
    public partial class TurnCategIntoEmp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieServiciu");

            migrationBuilder.RenameColumn(
                name: "DenumireCategorie",
                table: "Categorie",
                newName: "NumeAngajat");

            migrationBuilder.CreateTable(
                name: "AngajatAsociat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiciuID = table.Column<int>(type: "int", nullable: false),
                    AngajatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AngajatAsociat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AngajatAsociat_Categorie_AngajatID",
                        column: x => x.AngajatID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AngajatAsociat_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AngajatAsociat_AngajatID",
                table: "AngajatAsociat",
                column: "AngajatID");

            migrationBuilder.CreateIndex(
                name: "IX_AngajatAsociat_ServiciuID",
                table: "AngajatAsociat",
                column: "ServiciuID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AngajatAsociat");

            migrationBuilder.RenameColumn(
                name: "NumeAngajat",
                table: "Categorie",
                newName: "DenumireCategorie");

            migrationBuilder.CreateTable(
                name: "CategorieServiciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieID = table.Column<int>(type: "int", nullable: false),
                    ServiciuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieServiciu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieServiciu_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieServiciu_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieServiciu_CategorieID",
                table: "CategorieServiciu",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieServiciu_ServiciuID",
                table: "CategorieServiciu",
                column: "ServiciuID");
        }
    }
}
