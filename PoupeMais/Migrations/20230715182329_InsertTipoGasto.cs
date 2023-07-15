using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoupeMais.Migrations
{
    /// <inheritdoc />
    public partial class InsertTipoGasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

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
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "delete FROM TipoGasto;");




        }
    }
}
