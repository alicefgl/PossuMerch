using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PossuMerch.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCarrello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idUser",
                table: "Carrello");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Carrello",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Carrello");

            migrationBuilder.AddColumn<int>(
                name: "idUser",
                table: "Carrello",
                type: "INTEGER",
                nullable: true);
        }
    }
}
