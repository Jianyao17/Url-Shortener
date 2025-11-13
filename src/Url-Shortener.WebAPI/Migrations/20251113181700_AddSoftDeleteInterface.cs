using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteInterface : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_DeletedAt",
                table: "ShortUrls",
                column: "DeletedAt",
                filter: "DeletedAt IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlClick_DeletedAt",
                table: "ShortUrlClick",
                column: "DeletedAt",
                filter: "DeletedAt IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlChange_DeletedAt",
                table: "ShortUrlChange",
                column: "DeletedAt",
                filter: "DeletedAt IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_DeletedAt",
                table: "ShortUrls");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrlClick_DeletedAt",
                table: "ShortUrlClick");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrlChange_DeletedAt",
                table: "ShortUrlChange");
        }
    }
}
