using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20260129_9008 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(200)", nullable: false),
                    Code = table.Column<string>(type: "Varchar(10)", nullable: false),
                    FlagIcon = table.Column<string>(type: "Varchar(200)", nullable: false),
                    PhoneCode = table.Column<string>(type: "Varchar(10)", nullable: false),
                    Gmt = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "Varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "Varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                    name: "FK_State_Country_CountryId",
                    column: x => x.CountryId,
                    principalTable: "Country",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade
                    );
                });

            migrationBuilder.CreateTable(
                name: "BaseUserEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseUserEntity");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
