using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PossuMerch.Migrations
{
    /// <inheritdoc />
    public partial class AddCarrello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrello",
                columns: table => new
                {
                    IdRigaCarrello = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idProdotto = table.Column<int>(type: "INTEGER", nullable: true),
                    idUser = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantita = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrello", x => x.IdRigaCarrello);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrello");
        }
    }
}
