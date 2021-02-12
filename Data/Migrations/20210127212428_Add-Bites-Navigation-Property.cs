using Microsoft.EntityFrameworkCore.Migrations;

namespace Komar.Data.Migrations
{
    public partial class AddBitesNavigationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bites_AspNetUsers_UserId",
                table: "Bites");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bites",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bites_AspNetUsers_UserId",
                table: "Bites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bites_AspNetUsers_UserId",
                table: "Bites");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bites",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Bites_AspNetUsers_UserId",
                table: "Bites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
