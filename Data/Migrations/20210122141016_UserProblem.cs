using Microsoft.EntityFrameworkCore.Migrations;

namespace Komar.Data.Migrations
{
    public partial class UserProblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nazwisko",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nazwisko",
                table: "AspNetUsers");
        }
    }
}
