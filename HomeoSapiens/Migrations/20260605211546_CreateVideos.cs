using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeoSapiens.Migrations
{
    /// <inheritdoc />
    public partial class CreateVideos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "video_groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    slug = table.Column<string>(type: "citext", nullable: false),
                    title_en = table.Column<string>(type: "text", nullable: false),
                    title_pl = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_video_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "videos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    slug = table.Column<string>(type: "citext", nullable: false),
                    title_en = table.Column<string>(type: "text", nullable: false),
                    title_pl = table.Column<string>(type: "text", nullable: false),
                    duration_seconds = table.Column<int>(type: "integer", nullable: true),
                    thumbnail_pl_id = table.Column<Guid>(type: "uuid", nullable: true),
                    thumbnail_en_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_videos", x => x.id);
                    table.ForeignKey(
                        name: "fk_videos_assets_thumbnail_en_id",
                        column: x => x.thumbnail_en_id,
                        principalTable: "assets",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_videos_assets_thumbnail_pl_id",
                        column: x => x.thumbnail_pl_id,
                        principalTable: "assets",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_video_groups_slug",
                table: "video_groups",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_videos_thumbnail_en_id",
                table: "videos",
                column: "thumbnail_en_id");

            migrationBuilder.CreateIndex(
                name: "ix_videos_thumbnail_pl_id",
                table: "videos",
                column: "thumbnail_pl_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "video_groups");

            migrationBuilder.DropTable(
                name: "videos");
        }
    }
}
