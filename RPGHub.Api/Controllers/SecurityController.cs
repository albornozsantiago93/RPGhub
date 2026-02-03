using RPGHub.Common;
using RPGHub.Domain;
using RPGHub.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RPGHub.Api.Controllers
{
    [ApiController]
    [EnableCors] 
    [Route("[controller]")]
    public class SecurityController : BaseController
    {
        private readonly IConfiguration _configuration;
        private SecurityMapper _mapper;

        public SecurityController(ISqlContext context,ILogicProxy logicProxy,IHttpContextAccessor httpContextAccessor, IConfiguration configuration) 
            : base(context, new SecurityMapper(logicProxy), httpContextAccessor, logicProxy)
        {
            _mapper = new SecurityMapper(logicProxy);
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult<UserModel>> Authenticate(LoginModel credentials)
        {
            var user = await Logic.SecurityLogic.UserViewsGetByEmail(credentials.Username);

            if (user == null || user.Password != credentials.Password)
                return Unauthorized("Usuario o contraseña inválidos");

            string passwordHased = Encrypt.GetSHA256(credentials.Password);//Falta encriptar la contraseña recibida y compararla con la de la BD

            //Falta SP para obtener roles y permisos
            var userModel = await Logic.SecurityLogic.BuildUserModelWithToken(user, CurrentLanguage, _mapper);

            return Ok(userModel);
        }

        [HttpGet("hashFactory")]
        [EnableCors]
        [AllowAnonymous]
        public async Task<ActionResult> HashFactory(string passToHash)
        {
            return Ok(Encrypt.GetSHA256(passToHash));
        }



    }
}
