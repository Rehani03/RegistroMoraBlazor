using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroMoraBlazor.Migrations
{
    public partial class CreateMoraDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moras",
                columns: table => new
                {
                    moraId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(nullable: false),
                    total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moras", x => x.moraId);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    personaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(maxLength: 50, nullable: false),
                    telefono = table.Column<string>(maxLength: 10, nullable: false),
                    cedula = table.Column<string>(nullable: false),
                    direccion = table.Column<string>(maxLength: 40, nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.personaId);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    prestamoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    concepto = table.Column<string>(maxLength: 40, nullable: false),
                    monto = table.Column<decimal>(nullable: false),
                    balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.prestamoId);
                });

            migrationBuilder.CreateTable(
                name: "MoraDetalle",
                columns: table => new
                {
                    moraDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    moraId = table.Column<int>(nullable: false),
                    prestamoId = table.Column<int>(nullable: false),
                    valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoraDetalle", x => x.moraDetalleId);
                    table.ForeignKey(
                        name: "FK_MoraDetalle_Moras_moraId",
                        column: x => x.moraId,
                        principalTable: "Moras",
                        principalColumn: "moraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoraDetalle_moraId",
                table: "MoraDetalle",
                column: "moraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoraDetalle");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Moras");
        }
    }
}
