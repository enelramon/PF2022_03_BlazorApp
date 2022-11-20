using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PF202203BlazorApp.Migrations
{
    public partial class Recordatorios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tiketId",
                table: "tikets",
                newName: "TiketId");

            migrationBuilder.AddColumn<string>(
                name: "Asunto",
                table: "tikets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "tikets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "tikets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "tikets",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PrioridadId",
                table: "tikets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SistemaId",
                table: "tikets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TecnicoId",
                table: "tikets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "tikets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Recordatorios",
                columns: table => new
                {
                    RecordatorioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Dia = table.Column<int>(type: "INTEGER", nullable: false),
                    FroximaFecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recordatorios", x => x.RecordatorioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "Asunto",
                table: "tikets");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "tikets");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "tikets");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "tikets");

            migrationBuilder.DropColumn(
                name: "PrioridadId",
                table: "tikets");

            migrationBuilder.DropColumn(
                name: "SistemaId",
                table: "tikets");

            migrationBuilder.DropColumn(
                name: "TecnicoId",
                table: "tikets");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "tikets");

            migrationBuilder.RenameColumn(
                name: "TiketId",
                table: "tikets",
                newName: "tiketId");
        }
    }
}
