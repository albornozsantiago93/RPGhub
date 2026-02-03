using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20260203_1037 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_GameSession_GameSessionId",
                table: "Character");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameSessionId",
                table: "Character",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_GameSession_GameSessionId",
                table: "Character",
                column: "GameSessionId",
                principalTable: "GameSession",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_GameSession_GameSessionId",
                table: "Character");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameSessionId",
                table: "Character",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_GameSession_GameSessionId",
                table: "Character",
                column: "GameSessionId",
                principalTable: "GameSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
