using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasApi.Migrations
{
    /// <inheritdoc />
    public partial class stringDataTermino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataTermino",
                table: "TB_TAREFAS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataTermino",
                value: "05/10");

            migrationBuilder.UpdateData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataTermino",
                value: "11/10");

            migrationBuilder.UpdateData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataTermino",
                value: "28/11");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataTermino",
                table: "TB_TAREFAS",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataTermino",
                value: new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataTermino",
                value: new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TB_TAREFAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataTermino",
                value: new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
