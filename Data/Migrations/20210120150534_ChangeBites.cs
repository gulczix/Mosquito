using Microsoft.EntityFrameworkCore.Migrations;

namespace Komar.Data.Migrations
{
    public partial class ChangeBites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Bites");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Bites",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Bites",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Bites",
                newName: "User.UserName");

            migrationBuilder.AddColumn<int>(
                name: "Bubbles",
                table: "Bites",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bubbles",
                table: "Bites");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Bites",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "User.UserName",
                table: "Bites",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Bites",
                newName: "ReleaseDate");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Bites",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
