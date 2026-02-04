using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20260204_2345 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChurrentChapterOrder",
                table: "GameSessionParticipant");

            migrationBuilder.AddColumn<int>(
                name: "CurrentChapterOrder",
                table: "GameSession",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
