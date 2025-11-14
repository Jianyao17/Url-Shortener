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
                name: "ShortUrlClicks",
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
                    ClickedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortUrlClicks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShortUrlClicks_ShortUrls_ShortUrlId",
                        column: x => x.ShortUrlId,
                        principalTable: "ShortUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlClicks_City",
                table: "ShortUrlClicks",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlClicks_Country",
                table: "ShortUrlClicks",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlClicks_Latitude_Longitude",
                table: "ShortUrlClicks",
                columns: new[] { "Latitude", "Longitude" });

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlClicks_ShortUrlId_ClickedAt",
                table: "ShortUrlClicks",
                columns: new[] { "ShortUrlId", "ClickedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortUrlClicks");
        }
    }
}
