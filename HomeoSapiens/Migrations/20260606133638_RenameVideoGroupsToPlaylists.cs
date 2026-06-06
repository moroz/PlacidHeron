using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeoSapiens.Migrations
{
    /// <inheritdoc />
    public partial class RenameVideoGroupsToPlaylists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "video_groups",
                newName: "playlists");

            migrationBuilder.RenameTable(
                name: "video_groups_videos",
                newName: "playlist_videos");

            migrationBuilder.RenameColumn(
                name: "video_group_id",
                table: "playlist_videos",
                newName: "playlist_id");

            migrationBuilder.Sql(
                "ALTER TABLE playlists RENAME CONSTRAINT pk_video_groups TO pk_playlists;");

            migrationBuilder.Sql(
                "ALTER TABLE playlist_videos RENAME CONSTRAINT pk_video_groups_videos TO pk_playlist_videos;");

            migrationBuilder.Sql(
                "ALTER TABLE playlist_videos RENAME CONSTRAINT fk_video_groups_videos_video_groups_video_group_id TO fk_playlist_videos_playlists_playlist_id;");

            migrationBuilder.Sql(
                "ALTER TABLE playlist_videos RENAME CONSTRAINT fk_video_groups_videos_videos_video_id TO fk_playlist_videos_videos_video_id;");

            migrationBuilder.Sql(
                "ALTER TABLE playlist_videos RENAME CONSTRAINT video_group_video_position_must_be_non_neg TO playlist_video_position_must_be_non_neg;");

            migrationBuilder.RenameIndex(
                name: "ix_video_groups_slug",
                table: "playlists",
                newName: "ix_playlists_slug");

            migrationBuilder.RenameIndex(
                name: "ix_video_groups_videos_video_group_id_position",
                table: "playlist_videos",
                newName: "ix_playlist_videos_playlist_id_position");

            migrationBuilder.RenameIndex(
                name: "ix_video_groups_videos_video_group_id_video_id",
                table: "playlist_videos",
                newName: "ix_playlist_videos_playlist_id_video_id");

            migrationBuilder.RenameIndex(
                name: "ix_video_groups_videos_video_id",
                table: "playlist_videos",
                newName: "ix_playlist_videos_video_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "ix_playlist_videos_video_id",
                table: "playlist_videos",
                newName: "ix_video_groups_videos_video_id");

            migrationBuilder.RenameIndex(
                name: "ix_playlist_videos_playlist_id_video_id",
                table: "playlist_videos",
                newName: "ix_video_groups_videos_video_group_id_video_id");

            migrationBuilder.RenameIndex(
                name: "ix_playlist_videos_playlist_id_position",
                table: "playlist_videos",
                newName: "ix_video_groups_videos_video_group_id_position");

            migrationBuilder.RenameIndex(
                name: "ix_playlists_slug",
                table: "playlists",
                newName: "ix_video_groups_slug");

            migrationBuilder.Sql(
                "ALTER TABLE playlist_videos RENAME CONSTRAINT playlist_video_position_must_be_non_neg TO video_group_video_position_must_be_non_neg;");

            migrationBuilder.Sql(
                "ALTER TABLE playlist_videos RENAME CONSTRAINT fk_playlist_videos_videos_video_id TO fk_video_groups_videos_videos_video_id;");

            migrationBuilder.Sql(
                "ALTER TABLE playlist_videos RENAME CONSTRAINT fk_playlist_videos_playlists_playlist_id TO fk_video_groups_videos_video_groups_video_group_id;");

            migrationBuilder.Sql(
                "ALTER TABLE playlist_videos RENAME CONSTRAINT pk_playlist_videos TO pk_video_groups_videos;");

            migrationBuilder.Sql(
                "ALTER TABLE playlists RENAME CONSTRAINT pk_playlists TO pk_video_groups;");

            migrationBuilder.RenameColumn(
                name: "playlist_id",
                table: "playlist_videos",
                newName: "video_group_id");

            migrationBuilder.RenameTable(
                name: "playlist_videos",
                newName: "video_groups_videos");

            migrationBuilder.RenameTable(
                name: "playlists",
                newName: "video_groups");
        }
    }
}