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
                name: "ShortUrlChange",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShortUrlId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShortCodeBefore = table.Column<string>(type: "text", nullable: true),
                    ShortCodeAfter = table.Column<string>(type: "text", nullable: true),
                    OriginalUrlBefore = table.Column<string>(type: "text", nullable: true),
                    OriginalUrlAfter = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortUrlChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShortUrlChange_ShortUrls_ShortUrlId",
                        column: x => x.ShortUrlId,
                        principalTable: "ShortUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShortUrlChange_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlChange_ShortUrlId",
                table: "ShortUrlChange",
                column: "ShortUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlChange_UserId",
                table: "ShortUrlChange",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortUrlChange");
        }
    }
}
