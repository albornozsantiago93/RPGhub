using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20260129_1200 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseUserEntity");

            migrationBuilder.CreateTable(
                name: "LearningUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacebookId = table.Column<int>(type: "Int", nullable: false),
                    SignInKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Firstname = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Lastname = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(128)", nullable: false),
                    Password = table.Column<string>(type: "Varchar(256)", nullable: false),
                    ActivationCode = table.Column<string>(type: "Varchar(20)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "Varchar(128)", nullable: false),
                    ModifiedUser = table.Column<string>(type: "Varchar(128)", nullable: false),
                    Picture = table.Column<string>(type: "Varchar(256)", nullable: false),
                    HasChangesPassword = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "Varchar(128)", nullable: false),
                    Language = table.Column<string>(type: "Varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningUser_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "Varchar(128)", nullable: false),
                    ModifiedUser = table.Column<string>(type: "Varchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlatformRoleId = table.Column<int>(type: "int", nullable: false),
                    Firstname = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Lastname = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(128)", nullable: false),
                    Password = table.Column<string>(type: "Varchar(256)", nullable: false),
                    ActivationCode = table.Column<string>(type: "Varchar(20)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "Varchar(128)", nullable: false),
                    ModifiedUser = table.Column<string>(type: "Varchar(128)", nullable: false),
                    Picture = table.Column<string>(type: "Varchar(256)", nullable: false),
                    HasChangesPassword = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "Varchar(128)", nullable: false),
                    Language = table.Column<string>(type: "Varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUser_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemUserPlatformPermision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformPermissionId = table.Column<int>(type: "int", nullable: false),
                    SystemuserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "Varchar(128)", nullable: false),
                    ModifiedUser = table.Column<string>(type: "Varchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUserPlatformPermision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUserPlatformPermision_PlatformPermission_PlatformPermissionId",
                        column: x => x.PlatformPermissionId,
                        principalTable: "PlatformPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemUserPlatformPermision_SystemUser_SystemuserId",
                        column: x => x.SystemuserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearningUser_CountryId",
                table: "LearningUser",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_CountryId",
                table: "SystemUser",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPlatformPermision_PlatformPermissionId",
                table: "SystemUserPlatformPermision",
                column: "PlatformPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPlatformPermision_SystemuserId",
                table: "SystemUserPlatformPermision",
                column: "SystemuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningUser");

            migrationBuilder.DropTable(
                name: "SystemUserPlatformPermision");

            migrationBuilder.DropTable(
                name: "PlatformPermission");

            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.CreateTable(
                name: "BaseUserEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ActivationCode = table.Column<string>(type: "Varchar(20)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "Varchar(128)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(128)", nullable: false),
                    Firstname = table.Column<string>(type: "Varchar(100)", nullable: false),
                    HasChangesPassword = table.Column<bool>(type: "bit", nullable: false),
                    Language = table.Column<string>(type: "Varchar(2)", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Lastname = table.Column<string>(type: "Varchar(100)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUser = table.Column<string>(type: "Varchar(128)", nullable: false),
                    Password = table.Column<string>(type: "Varchar(256)", nullable: false),
                    Picture = table.Column<string>(type: "Varchar(256)", nullable: false),
                    UserName = table.Column<string>(type: "Varchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseUserEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseUserEntity_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseUserEntity_CountryId",
                table: "BaseUserEntity",
                column: "CountryId");
        }
    }
}
