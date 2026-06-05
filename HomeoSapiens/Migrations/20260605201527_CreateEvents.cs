using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeoSapiens.Migrations
{
    /// <inheritdoc />
    public partial class CreateEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    slug = table.Column<string>(type: "citext", nullable: false),
                    title_pl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    title_en = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description_en = table.Column<string>(type: "text", nullable: false),
                    description_pl = table.Column<string>(type: "text", nullable: false),
                    starts_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ends_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_events", x => x.id);
                    table.CheckConstraint("end_time_must_be_after_start_time", "(ends_at > starts_at)");
                });

            migrationBuilder.CreateIndex(
                name: "ix_events_slug",
                table: "events",
                column: "slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "events");
        }
    }
}
