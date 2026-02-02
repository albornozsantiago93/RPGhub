using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20260202_1454 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "ActivationCode",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "ActivationCode",
                table: "LearningUser");

            migrationBuilder.DropColumn(
                name: "HasChangesPassword",
                table: "LearningUser");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "LearningUser");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "LearningUser");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "SystemUser",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "PlatformRoleId",
                table: "SystemUser",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "HasChangesPassword",
                table: "SystemUser",
                newName: "IsActive");           

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "SystemUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "SystemUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(256)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoined",
                table: "SystemUser",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacebookId",
                table: "SystemUser",
                type: "Int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SignInKey",
                table: "SystemUser",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SystemUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSession_SystemUser_MasterId",
                        column: x => x.MasterId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameSession_SystemUser_SystemUserId",
                        column: x => x.SystemUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Race = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Stats = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inventory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_GameSession_GameSessionId",
                        column: x => x.GameSessionId,
                        principalTable: "GameSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_SystemUser_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessage_GameSession_GameSessionId",
                        column: x => x.GameSessionId,
                        principalTable: "GameSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatMessage_SystemUser_SenderId",
                        column: x => x.SenderId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GameSessionParticipant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "Varchar(128)", nullable: false),
                    ModifiedUser = table.Column<string>(type: "Varchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSessionParticipant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSessionParticipant_GameSession_GameSessionId",
                        column: x => x.GameSessionId,
                        principalTable: "GameSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameSessionParticipant_SystemUser_SystemUserId",
                        column: x => x.SystemUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Invitation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvitedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "Varchar(128)", nullable: false),
                    ModifiedUser = table.Column<string>(type: "Varchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invitation_GameSession_GameSessionId",
                        column: x => x.GameSessionId,
                        principalTable: "GameSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invitation_SystemUser_InvitedUserId",
                        column: x => x.InvitedUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "Varchar(128)", nullable: false),
                    ModifiedUser = table.Column<string>(type: "Varchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_GameSession_GameSessionId",
                        column: x => x.GameSessionId,
                        principalTable: "GameSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Log_SystemUser_ActorId",
                        column: x => x.ActorId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_GameSessionId",
                table: "Character",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_OwnerId",
                table: "Character",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_GameSessionId",
                table: "ChatMessage",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_SenderId",
                table: "ChatMessage",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_MasterId",
                table: "GameSession",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_SystemUserId",
                table: "GameSession",
                column: "SystemUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessionParticipant_GameSessionId",
                table: "GameSessionParticipant",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessionParticipant_SystemUserId",
                table: "GameSessionParticipant",
                column: "SystemUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitation_GameSessionId",
                table: "Invitation",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitation_InvitedUserId",
                table: "Invitation",
                column: "InvitedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_ActorId",
                table: "Log",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_GameSessionId",
                table: "Log",
                column: "GameSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "ChatMessage");

            migrationBuilder.DropTable(
                name: "GameSessionParticipant");

            migrationBuilder.DropTable(
                name: "Invitation");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "GameSession");

            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "FacebookId",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "SignInKey",
                table: "SystemUser");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "SystemUser",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "SystemUser",
                newName: "PlatformRoleId");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "SystemUser",
                newName: "HasChangesPassword");

            

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "SystemUser",
                type: "Varchar(128)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "SystemUser",
                type: "Varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ActivationCode",
                table: "SystemUser",
                type: "Varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ActivationCode",
                table: "LearningUser",
                type: "Varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasChangesPassword",
                table: "LearningUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "LearningUser",
                type: "Varchar(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "LearningUser",
                type: "Varchar(128)",
                nullable: false,
                defaultValue: "");
        }
    }
}
