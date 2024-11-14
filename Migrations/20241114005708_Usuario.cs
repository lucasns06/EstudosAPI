using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasApi.Migrations
{
    /// <inheritdoc />
    public partial class Usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TB_CATEGORIAS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TB_CATEGORIAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "UsuarioId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TB_CATEGORIAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "UsuarioId",
                value: null);

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "DataAcesso", "Email", "Foto", "Latitude", "Longitude", "Nome", "PasswordHash", "PasswordSalt", "Perfil" },
                values: new object[] { 1, null, "seuEmail@gmail.com", null, -23.520024100000001, -46.596497999999997, "UsuarioAdmin", new byte[] { 29, 98, 110, 151, 117, 3, 172, 241, 204, 175, 115, 211, 84, 242, 148, 104, 157, 116, 56, 210, 19, 85, 194, 41, 30, 243, 33, 234, 228, 28, 176, 143, 48, 217, 167, 149, 180, 238, 12, 11, 225, 152, 225, 169, 0, 188, 31, 220, 146, 7, 119, 105, 91, 86, 245, 3, 227, 199, 41, 86, 223, 149, 166, 236 }, new byte[] { 80, 24, 103, 88, 105, 154, 47, 223, 178, 134, 185, 104, 25, 252, 145, 138, 70, 100, 93, 78, 85, 126, 86, 240, 18, 36, 26, 65, 189, 237, 104, 155, 232, 65, 197, 12, 56, 126, 170, 108, 135, 226, 44, 38, 183, 95, 137, 4, 158, 208, 178, 239, 66, 108, 70, 13, 94, 156, 218, 180, 181, 196, 212, 30, 173, 59, 127, 50, 18, 193, 83, 17, 148, 12, 77, 29, 112, 23, 171, 68, 21, 2, 152, 215, 190, 15, 201, 240, 35, 108, 156, 160, 141, 29, 85, 57, 179, 224, 4, 86, 135, 67, 219, 63, 25, 226, 117, 42, 197, 135, 123, 176, 231, 142, 115, 247, 160, 66, 163, 252, 229, 87, 78, 109, 76, 59, 61, 35 }, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CATEGORIAS_UsuarioId",
                table: "TB_CATEGORIAS",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CATEGORIAS_TB_USUARIOS_UsuarioId",
                table: "TB_CATEGORIAS",
                column: "UsuarioId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CATEGORIAS_TB_USUARIOS_UsuarioId",
                table: "TB_CATEGORIAS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_CATEGORIAS_UsuarioId",
                table: "TB_CATEGORIAS");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TB_CATEGORIAS");
        }
    }
}
