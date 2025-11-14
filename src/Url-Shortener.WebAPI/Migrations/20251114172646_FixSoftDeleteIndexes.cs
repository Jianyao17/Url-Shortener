using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixSoftDeleteIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_DeletedAt",
                table: "ShortUrls");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrlClicks_DeletedAt",
                table: "ShortUrlClicks");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrlChanges_DeletedAt",
                table: "ShortUrlChanges");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_DeletedAt",
                table: "ShortUrls",
                column: "DeletedAt",
                filter: "\"DeletedAt\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlClicks_DeletedAt",
                table: "ShortUrlClicks",
                column: "DeletedAt",
                filter: "\"DeletedAt\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlChanges_DeletedAt",
                table: "ShortUrlChanges",
                column: "DeletedAt",
                filter: "\"DeletedAt\" IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_DeletedAt",
                table: "ShortUrls");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrlClicks_DeletedAt",
                table: "ShortUrlClicks");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrlChanges_DeletedAt",
                table: "ShortUrlChanges");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_DeletedAt",
                table: "ShortUrls",
                column: "DeletedAt",
                filter: "DeletedAt IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlClicks_DeletedAt",
                table: "ShortUrlClicks",
                column: "DeletedAt",
                filter: "DeletedAt IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlChanges_DeletedAt",
                table: "ShortUrlChanges",
                column: "DeletedAt",
                filter: "DeletedAt IS NULL");
        }
    }
}
