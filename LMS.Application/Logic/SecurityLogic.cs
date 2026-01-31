using LMS.Common.Config;
using LMS.Common.Logic;
using LMS.Domain;
using LMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace LMS.Application.Logic
{
    public class SecurityLogic : ISecurityLogic
    {
        private SqlContext _context;

        public SecurityLogic(SqlContext context)
        {
            _context = context;
        }

        public async Task<UserView> UserViewsGetByEmail(string email)
        {
            return await _context.UserView.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<List<PlatformPermission>> GetPermissionsByUserId(Guid userId)
        {
            return await _context.PlatformPermission.FromSqlRaw<PlatformPermission>("exec GetUserPermissions {0}", userId).ToListAsync();
        }

        /// <summary>
        /// Genera un token JWT para el usuario especificado con los claims proporcionados.
        /// </summary>
        /// <param name="countryId">ID del país del usuario (opcional).</param>
        /// <param name="userEmail">Correo electrónico del usuario.</param>
        /// <param name="userFullName">Nombre completo del usuario.</param>
        /// <param name="userIdentifier">Identificador único del usuario (GUID).</param>
        /// <param name="sourceRef">Referencia de origen.</param>
        /// <param name="role">Rol del usuario.</param>
        /// <param name="moderatorPermission">Indica si el usuario tiene permisos de moderador.</param>
        /// <param name="permissions">Lista de permisos de plataforma asignados al usuario.</param>
        /// <param name="ttl">Tiempo de vida del token en minutos (salida).</param>
        /// <returns>Token JWT generado como cadena.</returns>
        public string GetToken(
            int? countryId,
            string userEmail,
            string userFullName,
            Guid userIdentifier,
            string sourceRef,
            string role,
            bool moderatorPermission,
            List<PlatformPermission> permissions,
            out int ttl)
        {
            ttl = 60 * 5;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(ApiConfiguration.GetConfig("Tokens:Key"));
            List<Claim> claims = GetClaims(countryId, userEmail, userFullName, userIdentifier, sourceRef, role, moderatorPermission, permissions);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(ttl),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            string tokenStr = tokenHandler.WriteToken(token);

            return tokenStr;
        }

        /// <summary>
        /// Construye la lista de claims que se incluirán en el token JWT.
        /// </summary>
        /// <param name="countryId">ID del país del usuario (opcional).</param>
        /// <param name="userEmail">Correo electrónico del usuario.</param>
        /// <param name="userFullName">Nombre completo del usuario.</param>
        /// <param name="userIdentifier">Identificador único del usuario (GUID).</param>
        /// <param name="sourceRef">Referencia de origen.</param>
        /// <param name="role">Rol del usuario.</param>
        /// <param name="moderatorPermission">Indica si el usuario tiene permisos de moderador.</param>
        /// <param name="permissions">Lista de permisos de plataforma asignados al usuario.</param>
        /// <returns>Lista de claims para el token JWT.</returns>
        private List<Claim> GetClaims(
            int? countryId,
            string userEmail,
            string userFullName,
            Guid userIdentifier,
            string sourceRef,
            string role,
            bool moderatorPermission,
            List<PlatformPermission> permissions)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("useremail", userEmail),
                new Claim("userfullname", userFullName),
                new Claim("userguid", userIdentifier.ToString()),
                new Claim("sourceref", sourceRef),
                new Claim("lmsrole", role),
                new Claim("moderatorpermission", moderatorPermission.ToString())
            };

            if (countryId != null)
            {
                claims.Add(new Claim("countryid", countryId.ToString()));
            }

            foreach (PlatformPermission permission in permissions)
            {
                claims.Add(new Claim("permissions", permission.PermissionName.ToString()));
            }

            return claims;
        }

        /// <summary>
        /// Genera un token JWT para el usuario especificado utilizando un objeto UserView y una lista de permisos.
        /// </summary>
        /// <param name="user">Objeto UserView que representa al usuario.</param>
        /// <param name="permissions">Lista de permisos de plataforma asignados al usuario.</param>
        /// <param name="ttl">Tiempo de vida del token en minutos (salida).</param>
        /// <returns>Token JWT generado como cadena.</returns>
        public string GetToken(UserView user, List<PlatformPermission> permissions, out int ttl)
        {
            return GetToken(user.CountryId, user.Email, user.FullName, user.Id, user.SourceRef, user.Role, bool.Parse(user.IsModerator.ToString()), permissions, out ttl);
        }

    }
}
