using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PF2022_03_BlazorApp.Migrations
{
    public partial class Sistemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SistemaID",
                table: "Sistemas",
                newName: "SistemaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SistemaId",
                table: "Sistemas",
                newName: "SistemaID");
        }
    }
}
