using Microsoft.EntityFrameworkCore.Migrations;

namespace Cnblogs.Fluss.Infrastructure.Migrations
{
    public partial class add_footerText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterText",
                table: "blog_site",
                type: "varchar(512) CHARACTER SET utf8mb4",
                maxLength: 512,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterText",
                table: "blog_site");
        }
    }
}
