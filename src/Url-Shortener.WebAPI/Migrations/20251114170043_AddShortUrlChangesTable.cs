using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddShortUrlChangesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortUrlChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShortUrlId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShortCodeBefore = table.Column<string>(type: "text", nullable: true),
                    ShortCodeAfter = table.Column<string>(type: "text", nullable: true),
                    OriginalUrlBefore = table.Column<string>(type: "text", nullable: true),
                    OriginalUrlAfter = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortUrlChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShortUrlChanges_ShortUrls_ShortUrlId",
                        column: x => x.ShortUrlId,
                        principalTable: "ShortUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShortUrlChanges_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlChanges_ShortUrlId",
                table: "ShortUrlChanges",
                column: "ShortUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlChanges_UserId",
                table: "ShortUrlChanges",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortUrlChanges");
        }
    }
}
