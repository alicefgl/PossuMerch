using Microsoft.EntityFrameworkCore.Migrations;

namespace PossuMerch.Migrations
{
    public partial class Upd0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cart_IdProdotto",
                table: "Cart",
                column: "IdProdotto");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_IdUtente",
                table: "Cart",
                column: "IdUtente");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Prodotti_IdProdotto",
                table: "Cart",
                column: "IdProdotto",
                principalTable: "Prodotti",
                principalColumn: "idProdotto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_IdUtente",
                table: "Cart",
                column: "IdUtente",
                principalTable: "Utenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Prodotti_IdProdotto",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_IdUtente",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_IdProdotto",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_IdUtente",
                table: "Cart");
        }
    }
}
