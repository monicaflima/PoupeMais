using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoupeMais.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableGastos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gastos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUsuario = table.Column<int>(nullable: false),
                    IdRecorrencia = table.Column<int>(nullable: false),
                    IdTipoGasto = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    DtVencimento = table.Column<DateOnly>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos", x => x.Id);
                    table.ForeignKey("FK_UsuarioGastos", x => x.IdUsuario, "Usuarios", "Id");
                    table.ForeignKey("FK_RecorrenciaGastos", x => x.IdRecorrencia, "Recorrencia", "Id");
                    table.ForeignKey("FK_RecorrenciaGastos", x => x.IdTipoGasto, "TipoGasto", "Id");
                });
        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gastos");
        }
    }
}
