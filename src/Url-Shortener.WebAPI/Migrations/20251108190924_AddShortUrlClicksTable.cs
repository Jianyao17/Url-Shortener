using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddShortUrlClicksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortUrlClick",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShortUrlId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReferenceAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IpAddress = table.Column<string>(type: "text", nullable: false),
                    UserAgent = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true),
                    ClickedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortUrlClick", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShortUrlClick_ShortUrls_ShortUrlId",
                        column: x => x.ShortUrlId,
                        principalTable: "ShortUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_DeletedAt",
                table: "ShortUrls",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_IsActive",
                table: "ShortUrls",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlClick_City",
                table: "ShortUrlClick",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlClick_Country",
                table: "ShortUrlClick",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlClick_Latitude_Longitude",
                table: "ShortUrlClick",
                columns: new[] { "Latitude", "Longitude" });

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlClick_ShortUrlId_ClickedAt",
                table: "ShortUrlClick",
                columns: new[] { "ShortUrlId", "ClickedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortUrlClick");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_DeletedAt",
                table: "ShortUrls");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_IsActive",
                table: "ShortUrls");
        }
    }
}
