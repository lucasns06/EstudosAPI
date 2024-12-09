using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuarioChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "TB_USUARIOS",
                newName: "Username");

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "TB_USUARIOS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Jogador",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 229, 221, 115, 220, 15, 192, 49, 66, 4, 65, 16, 186, 252, 205, 44, 144, 25, 158, 176, 141, 31, 140, 190, 177, 117, 65, 188, 95, 78, 13, 10, 123, 177, 141, 92, 184, 86, 146, 222, 229, 1, 214, 25, 27, 205, 94, 195, 89, 230, 139, 181, 83, 254, 12, 249, 64, 222, 168, 115, 156, 191, 65, 184, 108 }, new byte[] { 233, 83, 210, 194, 8, 157, 52, 130, 28, 103, 60, 228, 178, 115, 184, 190, 254, 18, 107, 253, 116, 53, 229, 114, 180, 0, 28, 218, 122, 160, 31, 182, 137, 146, 176, 100, 82, 210, 86, 102, 124, 15, 102, 87, 119, 164, 20, 158, 150, 208, 165, 93, 253, 250, 187, 209, 183, 134, 63, 137, 145, 23, 98, 110, 219, 174, 20, 149, 234, 171, 188, 132, 26, 207, 93, 111, 172, 233, 148, 79, 98, 212, 63, 90, 111, 163, 168, 161, 204, 16, 68, 3, 83, 232, 120, 218, 179, 131, 128, 99, 31, 127, 90, 42, 232, 234, 95, 224, 125, 43, 205, 83, 4, 135, 228, 162, 103, 150, 30, 224, 81, 168, 10, 208, 124, 181, 28, 6 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "TB_USUARIOS",
                newName: "Nome");

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "TB_USUARIOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Jogador");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 29, 98, 110, 151, 117, 3, 172, 241, 204, 175, 115, 211, 84, 242, 148, 104, 157, 116, 56, 210, 19, 85, 194, 41, 30, 243, 33, 234, 228, 28, 176, 143, 48, 217, 167, 149, 180, 238, 12, 11, 225, 152, 225, 169, 0, 188, 31, 220, 146, 7, 119, 105, 91, 86, 245, 3, 227, 199, 41, 86, 223, 149, 166, 236 }, new byte[] { 80, 24, 103, 88, 105, 154, 47, 223, 178, 134, 185, 104, 25, 252, 145, 138, 70, 100, 93, 78, 85, 126, 86, 240, 18, 36, 26, 65, 189, 237, 104, 155, 232, 65, 197, 12, 56, 126, 170, 108, 135, 226, 44, 38, 183, 95, 137, 4, 158, 208, 178, 239, 66, 108, 70, 13, 94, 156, 218, 180, 181, 196, 212, 30, 173, 59, 127, 50, 18, 193, 83, 17, 148, 12, 77, 29, 112, 23, 171, 68, 21, 2, 152, 215, 190, 15, 201, 240, 35, 108, 156, 160, 141, 29, 85, 57, 179, 224, 4, 86, 135, 67, 219, 63, 25, 226, 117, 42, 197, 135, 123, 176, 231, 142, 115, 247, 160, 66, 163, 252, 229, 87, 78, 109, 76, 59, 61, 35 } });
        }
    }
}
