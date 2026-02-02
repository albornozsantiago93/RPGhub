using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20260129_1938 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PlatformPermission",
                newName: "PermissionName");

            migrationBuilder.Sql(
                @"
                CREATE VIEW UserView AS
                -- LearningUser
                SELECT
                    u.Id,
                    u.Firstname,
                    u.Lastname,
                    u.Email,
                    u.Password,
                    u.ActivationCode,
                    u.CountryId,
                    c.Code AS CountryCode,
                    NULL AS SourceRef,
                    0 AS IsModerator,
                    1 AS Active,
                    'Student' AS Role, -- o el rol que corresponda
                    u.Picture,
                    u.LastLogin,
                    u.HasChangesPassword,
                    1 AS Type, -- 1 para LearningUser, 2 para SystemUser, etc.
                    u.Language,
                    u.UserName,
                    NULL AS Permissions -- No hay permisos para LearningUser
                FROM LearningUser u
                LEFT JOIN Country c ON u.CountryId = c.Id

                UNION ALL

                -- SystemUser
                SELECT
                    u.Id,
                    u.Firstname,
                    u.Lastname,
                    u.Email,
                    u.Password,
                    u.ActivationCode,
                    u.CountryId,
                    c.Code AS CountryCode,
                    NULL AS SourceRef,
                    0 AS IsModerator,
                    1 AS Active,
                    CAST(u.PlatformRoleId AS VARCHAR(50)) AS Role, -- o join a tabla de roles si existe
                    u.Picture,
                    u.LastLogin,
                    u.HasChangesPassword,
                    2 AS Type,
                    u.Language,
                    u.UserName,
                    STRING_AGG(pp.PermissionName, ',') AS Permissions
                FROM SystemUser u
                LEFT JOIN Country c ON u.CountryId = c.Id
                LEFT JOIN SystemUserPlatformPermision sup ON sup.SystemuserId = u.Id
                LEFT JOIN PlatformPermission pp ON pp.Id = sup.PlatformPermissionId
                GROUP BY
                    u.Id, u.Firstname, u.Lastname, u.Email, u.Password, u.ActivationCode, u.CountryId, c.Code,
                    u.Picture, u.LastLogin, u.HasChangesPassword, u.PlatformRoleId, u.Language, u.UserName
                "
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserView");

            migrationBuilder.RenameColumn(
                name: "PermissionName",
                table: "PlatformPermission",
                newName: "Name");
        }
    }
}
