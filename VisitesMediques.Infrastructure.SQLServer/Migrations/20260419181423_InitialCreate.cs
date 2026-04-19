using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitesMediques.Infrastructure.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitesMediques",
                columns: table => new
                {
                    IdVisita = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Pacient = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Nom_Metge = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnostic = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitesMediques", x => x.IdVisita);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitesMediques");
        }
    }
}
