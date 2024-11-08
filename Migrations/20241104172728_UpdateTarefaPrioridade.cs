using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTarefaPrioridade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prioridade",
                table: "TB_TAREFAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "Prioridade",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "Prioridade",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "Prioridade",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prioridade",
                table: "TB_TAREFAS");
        }
    }
}
