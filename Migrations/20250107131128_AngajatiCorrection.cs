using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonBellissima.Migrations
{
    /// <inheritdoc />
    public partial class AngajatiCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
       name: "Categorie",
       newName: "Angajat");

            // Add new columns to match the Angajat class
            migrationBuilder.AddColumn<string>(
                name: "Prenume",
                table: "Angajat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nume",
                table: "Angajat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            // Remove the column no longer in use
            migrationBuilder.DropColumn(
                name: "NumeAngajat",
                table: "Angajat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
      name: "Angajat",
      newName: "Categorie");

            migrationBuilder.DropColumn(
                name: "Prenume",
                table: "Categorie");

            migrationBuilder.DropColumn(
                name: "Nume",
                table: "Categorie");

            migrationBuilder.AddColumn<string>(
                name: "NumeAngajat",
                table: "Categorie",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
