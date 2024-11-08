using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TarefasApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PROJETOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROJETOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_TAREFAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Completo = table.Column<bool>(type: "bit", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TAREFAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_TAREFAS_TB_PROJETOS_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "TB_PROJETOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_PROJETOS",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Matematica" },
                    { 2, "Fisica" }
                });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Lucas" });

            migrationBuilder.InsertData(
                table: "TB_TAREFAS",
                columns: new[] { "Id", "Completo", "Data", "Nome", "ProjetoId" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Equacoes", 1 },
                    { 2, false, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Potencia", 1 },
                    { 3, false, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Revisao", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TAREFAS_ProjetoId",
                table: "TB_TAREFAS",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TAREFAS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropTable(
                name: "TB_PROJETOS");
        }
    }
}
