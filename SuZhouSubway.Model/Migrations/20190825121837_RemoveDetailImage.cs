using Microsoft.EntityFrameworkCore.Migrations;

namespace SuZhouSubway.Model.Migrations
{
    public partial class RemoveDetailImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Details");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "Details",
                nullable: true);
        }
    }
}
