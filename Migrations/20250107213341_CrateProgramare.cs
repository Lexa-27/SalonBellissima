using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonBellissima.Migrations
{
    /// <inheritdoc />
    public partial class CrateProgramare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    ServiciuID = table.Column<int>(type: "int", nullable: true),
                    DataProgramare = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Programare_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Programare_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_ClientID",
                table: "Programare",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_ServiciuID",
                table: "Programare",
                column: "ServiciuID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programare");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
