using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoupeMais.Migrations
{
    /// <inheritdoc />
    public partial class InsertTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recorrencia",
                column: "Descricao",
                value: "Mensal");
            migrationBuilder.InsertData(
                table: "Recorrencia",
                column: "Descricao",
                value: "Semanal");
            migrationBuilder.InsertData(
                table: "Recorrencia",
                column: "Descricao",
                value: "Única");
            migrationBuilder.InsertData(
                table: "Recorrencia",
                column: "Descricao",
                value: "Outros");
            migrationBuilder.InsertData(
                table: "TipoGasto",
                column: "Descricao",
                value: "Fixo");
            migrationBuilder.InsertData(
                table: "TipoGasto",
                column: "Descricao",
                value: "Lazer");
            migrationBuilder.InsertData(
                table: "TipoGasto",
                column: "Descricao",
                value: "Poupança");
            migrationBuilder.InsertData(
                table: "TipoGasto",
                column: "Descricao",
                value: "Outros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "delete FROM TipoGasto;");
            migrationBuilder.Sql(
                "delete FROM Recorrencia;");
        }
    }
}
