using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20260203_0049 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Character",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Character");
        }
    }
}
