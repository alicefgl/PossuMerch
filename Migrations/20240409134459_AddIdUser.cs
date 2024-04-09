using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PossuMerch.Migrations
{
    /// <inheritdoc />
    public partial class AddIdUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idUser",
                table: "Prodotti",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idUser",
                table: "Prodotti");
        }
    }
}
