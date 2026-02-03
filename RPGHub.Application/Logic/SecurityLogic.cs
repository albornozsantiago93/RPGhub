using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RPGHub.Common;
using RPGHub.Common.Config;
using RPGHub.Common.Logic;
using RPGHub.Domain;
using RPGHub.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace RPGHub.Application.Logic
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
            //return await _context.PlatformPermission.FromSqlRaw<PlatformPermission>("exec GetUserPermissions {0}", userId).ToListAsync();

            return await _context.PlatformPermission.ToListAsync();
        }

        #region Token Generation
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
            bool moderatorPermission,
            List<PlatformPermission> permissions,
            out int ttl)
        {
            ttl = 60 * 5;
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(ApiConfiguration.GetConfig("Tokens:Key"));
            List<Claim> claims = GetClaims(countryId, userEmail, userFullName, userIdentifier, moderatorPermission, permissions);

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
            bool moderatorPermission,
            List<PlatformPermission> permissions)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("useremail", userEmail),
                new Claim("userfullname", userFullName),
                new Claim("userguid", userIdentifier.ToString()),
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
            return GetToken(user.CountryId, user.Email, user.FullName, user.Id, true, permissions, out ttl);
        }

        /// <summary>
        /// Builds a <see cref="UserModel"/> for the specified user, including a security token and its expiration time.
        /// </summary>
        /// <remarks>The generated token is included in the returned <see cref="UserModel"/> along with
        /// its expiration time,  which is calculated based on the token's time-to-live (TTL).</remarks>
        /// <param name="user">The user for whom the <see cref="UserModel"/> is being built. Cannot be <see langword="null"/>.</param>
        /// <param name="language">The language to be used for localization purposes.</param>
        /// <param name="securityMapper">An instance of <see cref="SecurityMapper"/> used to map the user and their permissions to a <see
        /// cref="UserModel"/>.</param>
        /// <returns>A <see cref="UserModel"/> containing the user's details, roles, permissions, a generated security token, and
        /// its expiration time. Returns <see langword="null"/> if <paramref name="user"/> is <see langword="null"/>.</returns>
        public async Task<UserModel> BuildUserModelWithToken(UserView user, string language, SecurityMapper securityMapper)
        {
            if (user == null) return null;

            var permissions = await GetPermissionsByUserId(user.Id);
            var roles = new List<string> { user.Role?.ToString() ?? string.Empty };

            var ret = securityMapper.MapToUserModel(user, roles, permissions, language);

            int ttl = 0;
            ret.Token = GetToken(user, permissions, out ttl);
            ret.TokenExpiration = DateTime.UtcNow.AddMinutes(ttl);

            return ret;
        }
        #endregion

    }
}
