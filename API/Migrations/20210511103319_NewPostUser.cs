using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class NewPostUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AppUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AppUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Posts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AppUserId",
                table: "Posts",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AppUserId",
                table: "Posts",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
