using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeoSapiens.Migrations
{
    /// <inheritdoc />
    public partial class CreateVideoSources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "video_groups_videos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    video_id = table.Column<Guid>(type: "uuid", nullable: false),
                    video_group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_video_groups_videos", x => x.id);
                    table.CheckConstraint("video_group_video_position_must_be_non_neg", "position >= 0");
                    table.ForeignKey(
                        name: "fk_video_groups_videos_video_groups_video_group_id",
                        column: x => x.video_group_id,
                        principalTable: "video_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_video_groups_videos_videos_video_id",
                        column: x => x.video_id,
                        principalTable: "videos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "video_sources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    video_id = table.Column<Guid>(type: "uuid", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false),
                    content_type = table.Column<string>(type: "text", nullable: false),
                    codec = table.Column<string>(type: "text", nullable: true),
                    object_key = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_video_sources", x => x.id);
                    table.CheckConstraint("video_source_position_must_be_non_neg", "position >= 0");
                    table.ForeignKey(
                        name: "fk_video_sources_videos_video_id",
                        column: x => x.video_id,
                        principalTable: "videos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_video_groups_videos_video_group_id_position",
                table: "video_groups_videos",
                columns: new[] { "video_group_id", "position" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_video_groups_videos_video_group_id_video_id",
                table: "video_groups_videos",
                columns: new[] { "video_group_id", "video_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_video_groups_videos_video_id",
                table: "video_groups_videos",
                column: "video_id");

            migrationBuilder.CreateIndex(
                name: "ix_video_sources_video_id_position",
                table: "video_sources",
                columns: new[] { "video_id", "position" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "video_groups_videos");

            migrationBuilder.DropTable(
                name: "video_sources");
        }
    }
}
