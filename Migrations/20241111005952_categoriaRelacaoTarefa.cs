using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasApi.Migrations
{
    /// <inheritdoc />
    public partial class categoriaRelacaoTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "TB_TAREFAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "TB_CATEGORIAS",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Fisica" });

            migrationBuilder.UpdateData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoriaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoriaId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoriaId", "Nome" },
                values: new object[] { 1, "Regra de três" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TAREFAS_CategoriaId",
                table: "TB_TAREFAS",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TAREFAS_TB_CATEGORIAS_CategoriaId",
                table: "TB_TAREFAS",
                column: "CategoriaId",
                principalTable: "TB_CATEGORIAS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TAREFAS_TB_CATEGORIAS_CategoriaId",
                table: "TB_TAREFAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_TAREFAS_CategoriaId",
                table: "TB_TAREFAS");

            migrationBuilder.DeleteData(
                table: "TB_CATEGORIAS",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "TB_TAREFAS");

            migrationBuilder.UpdateData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Ler sobre Química");
        }
    }
}
