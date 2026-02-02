using RPGHub.Common;
using Microsoft.AspNetCore.Mvc;
using RPGHub.Domain;
using Microsoft.AspNetCore.Authorization;

namespace RPGHub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {

        private readonly ILogger<UserController> _logger;
        private UserMapper _mapper;

        public UserController(ILogger<UserController> logger, ISqlContext context, ILogicProxy logicProxy, IHttpContextAccessor httpContextAccessor)
            : base(context, new UserMapper(logicProxy), httpContextAccessor, logicProxy)
        {
            _logger = logger;
            _mapper = new UserMapper(logicProxy);
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<ActionResult> CreateUser(CreateUserModel model)
        {
            if (await Logic.UserLogic.UserExist(model.Email)) return BadRequest("El usuario ya existe");

            SystemUser systemUser = await _mapper.MapUserModelToEntity(model, CurrentLanguage);

            Logic.UserLogic.UserCreate(systemUser);

            return Ok();
        }

    }
}
