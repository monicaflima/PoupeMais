using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoupeMais.Migrations
{
    /// <inheritdoc />
    public partial class InsertRecorrencia : Migration
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
        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "delete FROM Recorrencia;");
        }
    }
}
