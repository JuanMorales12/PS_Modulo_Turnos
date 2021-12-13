using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_AccessData.Migrations
{
    public partial class agregarDiagnostico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Diagnostico",
                table: "Turnos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diagnostico",
                table: "Turnos");
        }
    }
}
