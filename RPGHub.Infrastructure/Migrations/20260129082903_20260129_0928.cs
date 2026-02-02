using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20260129_0928 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"INSERT INTO Country (name, code, flagIcon, phoneCode, gmt, language) VALUES
                ('Argentina', 'AR', '🇦🇷', '+54', '-3', 'es'),
                ('Brasil', 'BR', '🇧🇷', '+55', '-3', 'pt'),
                ('Chile', 'CL', '🇨🇱', '+56', '-4', 'es'),
                ('España', 'ES', '🇪🇸', '+34', '1', 'es'),
                ('Alemania', 'DE', '🇩🇪', '+49', '1', 'de'),
                ('Francia', 'FR', '🇫🇷', '+33', '1', 'fr');"
            );

            migrationBuilder.Sql(
                @"INSERT INTO state (CountryId, name) VALUES
                -- Argentina
                ((Select Id from Country where Name = 'Argentina'), 'Buenos Aires'),
                ((Select Id from Country where Name = 'Argentina'), 'Córdoba'),
                ((Select Id from Country where Name = 'Argentina'), 'Santa Fe'),

                -- Brasil
                ((Select Id from Country where Name = 'Brasil'), 'São Paulo'),
                ((Select Id from Country where Name = 'Brasil'), 'Rio de Janeiro'),
                ((Select Id from Country where Name = 'Brasil'), 'Minas Gerais'),

                -- Chile
                ((Select Id from Country where Name = 'Chile'), 'Región Metropolitana'),
                ((Select Id from Country where Name = 'Chile'), 'Valparaíso'),
                ((Select Id from Country where Name = 'Chile'), 'Biobío'),

                -- España
                ((Select Id from Country where Name = 'España'), 'Madrid'),
                ((Select Id from Country where Name = 'España'), 'Cataluña'),
                ((Select Id from Country where Name = 'España'), 'Andalucía'),

                -- Alemania
                ((Select Id from Country where Name = 'Alemania'), 'Baviera'),
                ((Select Id from Country where Name = 'Alemania'), 'Berlín'),
                ((Select Id from Country where Name = 'Alemania'), 'Hamburgo'),

                -- Francia
                ((Select Id from Country where Name = 'Francia'), 'Île-de-France'),
                ((Select Id from Country where Name = 'Francia'), 'Provence-Alpes-Côte d’Azur'),
                ((Select Id from Country where Name = 'Francia'), 'Occitania');"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
