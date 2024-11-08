using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TarefasApi.Migrations
{
    /// <inheritdoc />
    public partial class TarefasExemplo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TB_TAREFAS",
                columns: new[] { "Id", "Completo", "Data", "Nome", "Prioridade" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estudar Matemática", 2 },
                    { 2, false, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Revisar Física", 1 },
                    { 3, false, new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ler sobre Química", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
