using Microsoft.EntityFrameworkCore.Migrations;

namespace Komar.Data.Migrations
{
    public partial class FinalizeBubbles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bubbles_Bites_BiteId",
                table: "Bubbles");

            migrationBuilder.AlterColumn<int>(
                name: "BiteId",
                table: "Bubbles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BubblerId",
                table: "Bubbles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bubbles_BubblerId",
                table: "Bubbles",
                column: "BubblerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bubbles_AspNetUsers_BubblerId",
                table: "Bubbles",
                column: "BubblerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bubbles_Bites_BiteId",
                table: "Bubbles",
                column: "BiteId",
                principalTable: "Bites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bubbles_AspNetUsers_BubblerId",
                table: "Bubbles");

            migrationBuilder.DropForeignKey(
                name: "FK_Bubbles_Bites_BiteId",
                table: "Bubbles");

            migrationBuilder.DropIndex(
                name: "IX_Bubbles_BubblerId",
                table: "Bubbles");

            migrationBuilder.DropColumn(
                name: "BubblerId",
                table: "Bubbles");

            migrationBuilder.AlterColumn<int>(
                name: "BiteId",
                table: "Bubbles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bubbles_Bites_BiteId",
                table: "Bubbles",
                column: "BiteId",
                principalTable: "Bites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
