using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clima.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RM556480");

            migrationBuilder.RenameTable(
                name: "TB_DISPOSITIVO",
                newName: "TB_DISPOSITIVO",
                newSchema: "RM556480");

            migrationBuilder.RenameTable(
                name: "TB_DADOS_CLIMATICOS",
                newName: "TB_DADOS_CLIMATICOS",
                newSchema: "RM556480");

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                schema: "RM556480",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EMAIL = table.Column<string>(type: "VARCHAR2(100)", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR2(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID_USUARIO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USUARIO",
                schema: "RM556480");

            migrationBuilder.RenameTable(
                name: "TB_DISPOSITIVO",
                schema: "RM556480",
                newName: "TB_DISPOSITIVO");

            migrationBuilder.RenameTable(
                name: "TB_DADOS_CLIMATICOS",
                schema: "RM556480",
                newName: "TB_DADOS_CLIMATICOS");
        }
    }
}
