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
        private SecurityMapper _securityMapper;

        public UserController(ILogger<UserController> logger, ISqlContext context, ILogicProxy logicProxy, IHttpContextAccessor httpContextAccessor)
            : base(context, new UserMapper(logicProxy), httpContextAccessor, logicProxy)
        {
            _logger = logger;
            _mapper = new UserMapper(logicProxy);
            _securityMapper = new SecurityMapper(logicProxy);
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<ActionResult<UserModel>> CreateUser(CreateUserModel model)
        {
            if (await Logic.UserLogic.UserExist(model.Email)) return BadRequest("El usuario ya existe");

            SystemUser systemUser = await _mapper.MapUserModelToEntity(model, CurrentLanguage);

            Logic.UserLogic.UserCreate(systemUser);

            var user = await Logic.SecurityLogic.UserViewsGetByEmail(model.Email);
            var ret = await Logic.SecurityLogic.BuildUserModelWithToken(user, CurrentLanguage, _securityMapper);

            return Ok(ret);
        }

        [AllowAnonymous]
        [HttpGet("{userId}")]
        public async Task<ActionResult<GetUserModel>> GetUserById(Guid userId)
        {
            SystemUser user = await Logic.UserLogic.GetUserById(userId);

            GetUserModel model = _mapper.MapTo<GetUserModel>(user, CurrentLanguage);

            return Ok(model);
        }

    }
}
