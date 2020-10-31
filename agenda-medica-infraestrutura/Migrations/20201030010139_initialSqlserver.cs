using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace agenda_medica_infraestrutura.Migrations
{
    public partial class initialSqlserver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePaciente = table.Column<string>(nullable: true),
                    DataNascimentoPaciente = table.Column<DateTime>(nullable: false),
                    DataInicialConsulta = table.Column<DateTime>(nullable: false),
                    DataFimConsulta = table.Column<DateTime>(nullable: false),
                    Observacoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");
        }
    }
}
