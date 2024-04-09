using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PossuMerch.Migrations
{
    /// <inheritdoc />
    public partial class Upd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdProdotto",
                table: "Cart",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdUtente",
                table: "Cart",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Prodotti_IdProdotto",
                table: "Cart",
                column: "IdProdotto",
                principalTable: "Prodotti",
                principalColumn: "idProdotto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Utenti_IdUtente",
                table: "Cart",
                column: "IdUtente",
                principalTable: "Utenti",
                principalColumn: "idUtente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Prodotti_IdProdotto",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Utenti_IdUtente",
                table: "Cart");

            migrationBuilder.AlterColumn<int>(
                name: "IdProdotto",
                table: "Cart",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IdUtente",
                table: "Cart",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
