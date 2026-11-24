using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class newtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tag",
                table: "MenuItems",
                newName: "Tag");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "MenuItems",
                newName: "Category_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tag",
                table: "MenuItems",
                newName: "tag");

            migrationBuilder.RenameColumn(
                name: "Category_Id",
                table: "MenuItems",
                newName: "Category");
        }
    }
}
