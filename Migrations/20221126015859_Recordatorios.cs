using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PF2022_03_BlazorApp.Migrations
{
    public partial class Recordatorios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tikets");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Recordatorios");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Recordatorios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descripción",
                table: "Recordatorios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    SistemaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrioridadId = table.Column<int>(type: "INTEGER", nullable: false),
                    Asunto = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    técnicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.TicketId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "Descripción",
                table: "Recordatorios");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Recordatorios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tikets",
                columns: table => new
                {
                    TiketId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Asunto = table.Column<string>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PrioridadId = table.Column<int>(type: "INTEGER", nullable: false),
                    SistemaId = table.Column<int>(type: "INTEGER", nullable: false),
                    técnicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tikets", x => x.TiketId);
                });
        }
    }
}
