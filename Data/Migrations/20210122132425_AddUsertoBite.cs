using Microsoft.EntityFrameworkCore.Migrations;

namespace Komar.Data.Migrations
{
    public partial class AddUsertoBite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bubble_Bites_BiteId",
                table: "Bubble");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bubble",
                table: "Bubble");

            migrationBuilder.RenameTable(
                name: "Bubble",
                newName: "Bubbles");

            migrationBuilder.RenameIndex(
                name: "IX_Bubble_BiteId",
                table: "Bubbles",
                newName: "IX_Bubbles_BiteId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bubbles",
                table: "Bubbles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bubbles_Bites_BiteId",
                table: "Bubbles",
                column: "BiteId",
                principalTable: "Bites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bubbles_Bites_BiteId",
                table: "Bubbles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bubbles",
                table: "Bubbles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Bubbles",
                newName: "Bubble");

            migrationBuilder.RenameIndex(
                name: "IX_Bubbles_BiteId",
                table: "Bubble",
                newName: "IX_Bubble_BiteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bubble",
                table: "Bubble",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bubble_Bites_BiteId",
                table: "Bubble",
                column: "BiteId",
                principalTable: "Bites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
