using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20260203_1553 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUser",
                table: "SystemUserPlatformPermision",
                type: "Varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUser",
                table: "SystemUserPlatformPermision",
                type: "Varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUser",
                table: "PlatformPermission",
                type: "Varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUser",
                table: "PlatformPermission",
                type: "Varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUser",
                table: "Log",
                type: "Varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUser",
                table: "Log",
                type: "Varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUser",
                table: "Invitation",
                type: "Varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUser",
                table: "Invitation",
                type: "Varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUser",
                table: "GameSessionParticipant",
                type: "Varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUser",
                table: "GameSessionParticipant",
                type: "Varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(128)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
