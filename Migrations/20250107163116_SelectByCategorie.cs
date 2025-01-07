using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonBellissima.Migrations
{
    /// <inheritdoc />
    public partial class SelectByCategorie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Denumire",
                table: "Categorie",
                newName: "DenumireCategorie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DenumireCategorie",
                table: "Categorie",
                newName: "Denumire");
        }
    }
}
