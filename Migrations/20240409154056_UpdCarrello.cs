using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PossuMerch.Migrations
{
    /// <inheritdoc />
    public partial class UpdCarrello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idProdotto",
                table: "Carrello");

            migrationBuilder.AddColumn<float>(
                name: "Prezzo",
                table: "Carrello",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoP",
                table: "Carrello",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_NomeP",
                table: "Carrello",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prezzo",
                table: "Carrello");

            migrationBuilder.DropColumn(
                name: "TipoP",
                table: "Carrello");

            migrationBuilder.DropColumn(
                name: "_NomeP",
                table: "Carrello");

            migrationBuilder.AddColumn<int>(
                name: "idProdotto",
                table: "Carrello",
                type: "INTEGER",
                nullable: true);
        }
    }
}
