using Microsoft.EntityFrameworkCore.Migrations;

namespace Komar.Data.Migrations
{
    public partial class AddValidators : Migration
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Bubbles_Bites_BiteId",
                table: "Bubbles",
                column: "BiteId",
                principalTable: "Bites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
