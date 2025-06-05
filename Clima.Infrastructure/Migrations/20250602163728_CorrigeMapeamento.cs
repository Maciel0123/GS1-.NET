using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clima.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrigeMapeamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_DISPOSITIVO",
                columns: table => new
                {
                    ID_DISPOSITIVO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IDENTIFICADOR = table.Column<string>(type: "VARCHAR2(100)", maxLength: 100, nullable: false),
                    LOCALIZACAO = table.Column<string>(type: "VARCHAR2(200)", maxLength: 200, nullable: false),
                    LATITUDE = table.Column<decimal>(type: "NUMBER(9,6)", nullable: true),
                    LONGITUDE = table.Column<decimal>(type: "NUMBER(9,6)", nullable: true),
                    STATUS = table.Column<string>(type: "VARCHAR2(20)", maxLength: 20, nullable: false),
                    ULTIMA_CONEXAO = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DISPOSITIVO", x => x.ID_DISPOSITIVO);
                });

            migrationBuilder.CreateTable(
                name: "TB_DADOS_CLIMATICOS",
                columns: table => new
                {
                    ID_DADO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_DISPOSITIVO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DATA_COLETA = table.Column<DateTime>(type: "DATE", nullable: false),
                    TEMPERATURA = table.Column<decimal>(type: "NUMBER(5,2)", nullable: true),
                    UMIDADE = table.Column<decimal>(type: "NUMBER(5,2)", nullable: true),
                    CHUVA_MM_1H = table.Column<decimal>(type: "NUMBER(5,2)", nullable: true),
                    CHUVA_MM_3H = table.Column<decimal>(type: "NUMBER(5,2)", nullable: true),
                    VENTO_VEL_KMH = table.Column<decimal>(type: "NUMBER(5,2)", nullable: true),
                    DESCRICAO_CLIMA = table.Column<string>(type: "VARCHAR2(100)", nullable: true),
                    CIDADE = table.Column<string>(type: "VARCHAR2(100)", nullable: true),
                    LAT_API = table.Column<decimal>(type: "NUMBER(9,6)", nullable: true),
                    LON_API = table.Column<decimal>(type: "NUMBER(9,6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DADOS_CLIMATICOS", x => x.ID_DADO);
                    table.ForeignKey(
                        name: "FK_DADOS_DISPOSITIVO",
                        column: x => x.ID_DISPOSITIVO,
                        principalTable: "TB_DISPOSITIVO",
                        principalColumn: "ID_DISPOSITIVO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_DADOS_CLIMATICOS_ID_DISPOSITIVO",
                table: "TB_DADOS_CLIMATICOS",
                column: "ID_DISPOSITIVO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_DADOS_CLIMATICOS");

            migrationBuilder.DropTable(
                name: "TB_DISPOSITIVO");
        }
    }
}
