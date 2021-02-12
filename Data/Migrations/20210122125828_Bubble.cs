using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Komar.Data.Migrations
{
    public partial class Bubble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bubbles",
                table: "Bites");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Bites",
                type: "nvarchar(333)",
                maxLength: 333,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bites",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bubble",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiteId = table.Column<int>(type: "int", nullable: false),
                    BubbleDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bubble", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bubble_Bites_BiteId",
                        column: x => x.BiteId,
                        principalTable: "Bites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bites_UserId",
                table: "Bites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bubble_BiteId",
                table: "Bubble",
                column: "BiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bites_AspNetUsers_UserId",
                table: "Bites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bites_AspNetUsers_UserId",
                table: "Bites");

            migrationBuilder.DropTable(
                name: "Bubble");

            migrationBuilder.DropIndex(
                name: "IX_Bites_UserId",
                table: "Bites");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bites");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Bites",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(333)",
                oldMaxLength: 333);

            migrationBuilder.AddColumn<int>(
                name: "Bubbles",
                table: "Bites",
                type: "int",
                nullable: false,
                defaultValue: 0);

           
        }
    }
}
