using Microsoft.EntityFrameworkCore.Migrations;

namespace Worktastic.Data.Migrations
{
    public partial class addedOwnerUsernameToJobPostingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ownerusername",
                table: "JobPostings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ownerusername",
                table: "JobPostings");
        }
    }
}
