using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20260205_1245 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameSessionParticipant_SystemUser_UserId",
                table: "GameSessionParticipant");

            migrationBuilder.DropIndex(
                name: "IX_GameSessionParticipant_UserId",
                table: "GameSessionParticipant");

            migrationBuilder.DropColumn(
                name: "CurrentChapterOrder",
                table: "GameSession");

            migrationBuilder.RenameColumn(
                name: "GameType",
                table: "GameSession",
                newName: "GameCfgId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "GameSession",
                type: "nvarchar(126)",
                maxLength: 126,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "GameSession",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "MasterId",
                table: "GameSession",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "GameCfg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(126)", maxLength: 126, nullable: false),
                    PlayerLimit = table.Column<int>(type: "int", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCfg", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_GameCfgId",
                table: "GameSession",
                column: "GameCfgId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_MasterId",
                table: "GameSession",
                column: "MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSession_GameCfg_GameCfgId",
                table: "GameSession",
                column: "GameCfgId",
                principalTable: "GameCfg",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSession_SystemUser_MasterId",
                table: "GameSession",
                column: "MasterId",
                principalTable: "SystemUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameSession_GameCfg_GameCfgId",
                table: "GameSession");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSession_SystemUser_MasterId",
                table: "GameSession");

            migrationBuilder.DropTable(
                name: "GameCfg");

            migrationBuilder.DropIndex(
                name: "IX_GameSession_GameCfgId",
                table: "GameSession");

            migrationBuilder.DropIndex(
                name: "IX_GameSession_MasterId",
                table: "GameSession");

            migrationBuilder.DropColumn(
                name: "MasterId",
                table: "GameSession");

            migrationBuilder.RenameColumn(
                name: "GameCfgId",
                table: "GameSession",
                newName: "GameType");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "GameSession",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(126)",
                oldMaxLength: 126);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "GameSession",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

            migrationBuilder.AddColumn<int>(
                name: "CurrentChapterOrder",
                table: "GameSession",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameSessionParticipant_UserId",
                table: "GameSessionParticipant",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSessionParticipant_SystemUser_UserId",
                table: "GameSessionParticipant",
                column: "UserId",
                principalTable: "SystemUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
