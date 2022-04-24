using Microsoft.EntityFrameworkCore.Migrations;

namespace HEWebsite.Data.Migrations
{
    public partial class Changes_to_ApplicationUsers_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "ApplicationUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "ApplicationUsers",
                type: "nvarchar(100)",
                nullable: true);
        }
    }
}
