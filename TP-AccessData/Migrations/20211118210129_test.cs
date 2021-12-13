using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_AccessData.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Practica",
                table: "Turnos");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Horario",
                table: "Turnos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadId",
                table: "Turnos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EspecialidadId",
                table: "Turnos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Horario",
                table: "Turnos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AddColumn<string>(
                name: "Practica",
                table: "Turnos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
