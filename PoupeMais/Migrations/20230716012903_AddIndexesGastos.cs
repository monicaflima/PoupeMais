using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoupeMais.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexesGastos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
            name: "FK_Gastos_Recorrencias_IdRecorrencia",
            table: "Gastos",
            column: "IdRecorrencia",
            principalTable: "Recorrencia",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_TiposGasto_IdTipoGasto",
                table: "Gastos",
                column: "IdTipoGasto",
                principalTable: "TipoGasto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_Usuarios_IdUsuario",
                table: "Gastos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
            name: "FK_Gastos_Recorrencias_IdRecorrencia",
            table: "Gastos");

            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_TiposGasto_IdTipoGasto",
                table: "Gastos");

            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_Usuarios_IdUsuario",
                table: "Gastos");
        }
    }
}
