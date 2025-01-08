using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonBellissima.Migrations
{
    /// <inheritdoc />
    public partial class OcupatieAngajat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ocupatie",
                table: "Angajat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ocupatie",
                table: "Angajat");
        }
    }
}
