using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cnblogs.Fluss.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blog_site",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    SubTitle = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    HomePageSize = table.Column<int>(type: "int", nullable: false),
                    IsExist = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "blog_post",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    AutoDesc = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IsPublished = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsExist = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blog_post_blog_site_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blog_site",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "blog_content_block",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    Raw = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Content = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IsExist = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_content_block", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blog_content_block_blog_post_PostId",
                        column: x => x.PostId,
                        principalTable: "blog_post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_blog_content_block_blog_site_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blog_site",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "blog_content_render_config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContentBlockId = table.Column<Guid>(type: "char(36)", nullable: false),
                    RendererId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    RendererData = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    IsExist = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    BlogPostId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_content_render_config", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blog_content_render_config_blog_content_block_ContentBlockId",
                        column: x => x.ContentBlockId,
                        principalTable: "blog_content_block",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_blog_content_render_config_blog_post_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "blog_post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blog_content_block_BlogId",
                table: "blog_content_block",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_blog_content_block_PostId",
                table: "blog_content_block",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_blog_content_render_config_BlogPostId",
                table: "blog_content_render_config",
                column: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_blog_content_render_config_ContentBlockId",
                table: "blog_content_render_config",
                column: "ContentBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_blog_post_BlogId_IsExist_IsPublished_DateCreated",
                table: "blog_post",
                columns: new[] { "BlogId", "IsExist", "IsPublished", "DateCreated" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog_content_render_config");

            migrationBuilder.DropTable(
                name: "blog_content_block");

            migrationBuilder.DropTable(
                name: "blog_post");

            migrationBuilder.DropTable(
                name: "blog_site");
        }
    }
}
