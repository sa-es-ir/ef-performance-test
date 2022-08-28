using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFTest.Migrations
{
    /// <inheritdoc />
    public partial class updateBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Blogs_Title",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Title_Url",
                table: "Blogs",
                columns: new[] { "Title", "Url" },
                descending: new[] { true, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Blogs_Title_Url",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Blogs");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Title",
                table: "Blogs",
                column: "Title",
                descending: new[] { true });
        }
    }
}
