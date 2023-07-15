using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoupeMais.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableTipoGasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "TipoGasto",
               columns: table => new
               {
                   Id = table.Column<int>(type: "INTEGER", nullable: false)
                       .Annotation("Sqlite:Autoincrement", true),
                   Descricao = table.Column<string>(type: "TEXT", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Recorrencia", x => x.Id);
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoGasto");
        }
    }
}
