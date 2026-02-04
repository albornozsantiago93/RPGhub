using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20260204_1303 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_GameSession_GameSessionId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_SystemUser_OwnerId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSession_SystemUser_MasterId",
                table: "GameSession");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSession_SystemUser_SystemUserId",
                table: "GameSession");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSessionParticipant_SystemUser_SystemUserId",
                table: "GameSessionParticipant");

            migrationBuilder.DropIndex(
                name: "IX_GameSession_MasterId",
                table: "GameSession");

            migrationBuilder.DropIndex(
                name: "IX_GameSession_SystemUserId",
                table: "GameSession");

            migrationBuilder.DropIndex(
                name: "IX_Character_OwnerId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "MasterId",
                table: "GameSession");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "GameSession");

            migrationBuilder.RenameColumn(
                name: "SystemUserId",
                table: "GameSessionParticipant",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GameSessionParticipant_SystemUserId",
                table: "GameSessionParticipant",
                newName: "IX_GameSessionParticipant_UserId");

            migrationBuilder.RenameColumn(
                name: "GameSessionId",
                table: "Character",
                newName: "SystemUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Character_GameSessionId",
                table: "Character",
                newName: "IX_Character_SystemUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                table: "GameSessionParticipant",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChurrentChapterOrder",
                table: "GameSessionParticipant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "GameSessionParticipant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GameSessionParticipant_CharacterId",
                table: "GameSessionParticipant",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_SystemUser_SystemUserId",
                table: "Character",
                column: "SystemUserId",
                principalTable: "SystemUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSessionParticipant_Character_CharacterId",
                table: "GameSessionParticipant",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSessionParticipant_SystemUser_UserId",
                table: "GameSessionParticipant",
                column: "UserId",
                principalTable: "SystemUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
