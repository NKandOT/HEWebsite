using Microsoft.EntityFrameworkCore.Migrations;

namespace HEWebsite.Data.Migrations
{
    public partial class User_added_posts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatePosted",
                table: "PostReplies",
                newName: "Created");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "PostReplies",
                newName: "DatePosted");
        }
    }
}
