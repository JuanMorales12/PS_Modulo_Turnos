using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_AccessData.Migrations
{
    public partial class prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Practica = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Horario = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    MedicoId = table.Column<int>(nullable: false),
                    ClinicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalendarioTurnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaId = table.Column<int>(nullable: false),
                    Horario = table.Column<DateTime>(nullable: false),
                    MedicoId = table.Column<int>(nullable: false),
                    Practica = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarioTurnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarioTurnos_Dias_DiaId",
                        column: x => x.DiaId,
                        principalTable: "Dias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Lunes" },
                    { 2, "Martes" },
                    { 3, "Miercoles" },
                    { 4, "Jueves" },
                    { 5, "Viernes" },
                    { 6, "Sabado" },
                    { 7, "Domingo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarioTurnos_DiaId",
                table: "CalendarioTurnos",
                column: "DiaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarioTurnos");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Dias");
        }
    }
}
