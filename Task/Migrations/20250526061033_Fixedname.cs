using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.Migrations
{
    /// <inheritdoc />
    public partial class Fixedname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categorts_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorts",
                table: "Categorts");

            migrationBuilder.RenameTable(
                name: "Categorts",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorts",
                table: "Categorts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categorts_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categorts",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
