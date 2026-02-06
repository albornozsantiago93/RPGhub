using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20260205_1257 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_SystemUser_SystemUserId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_SystemUserId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "Character");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Character",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId",
                table: "Character",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_SystemUser_UserId",
                table: "Character",
                column: "UserId",
                principalTable: "SystemUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_SystemUser_UserId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_UserId",
                table: "Character");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Character",
                newName: "OwnerId");

            migrationBuilder.AddColumn<Guid>(
                name: "SystemUserId",
                table: "Character",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_SystemUserId",
                table: "Character",
                column: "SystemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_SystemUser_SystemUserId",
                table: "Character",
                column: "SystemUserId",
                principalTable: "SystemUser",
                principalColumn: "Id");
        }
    }
}
