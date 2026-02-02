using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20260202_2032 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR ALTER VIEW UserView AS
                SELECT  
                    u.Id,
                    u.Firstname,
                    u.Lastname,
                    u.Email,
                    u.Password,
                    u.CountryId,
                    c.Code AS CountryCode,
                    u.Role,
                    u.Picture,
                    u.LastLogin,
                    u.Language,
                    u.UserName
                FROM SystemUser u
                    LEFT JOIN Country c ON c.Id = u.CountryId;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
