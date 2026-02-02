using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPGHub.Common;
using RPGHub.Domain;

namespace RPGHub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : BaseController
    {

        private readonly ILogger<CharacterController> _logger;
        private CharacterMapper _mapper;

        public CharacterController(ILogger<CharacterController> logger, ISqlContext context, ILogicProxy logicProxy, IHttpContextAccessor httpContextAccessor)
            : base(context, new CharacterMapper(logicProxy), httpContextAccessor, logicProxy)
        {
            _logger = logger;
            _mapper = new CharacterMapper(logicProxy);
        }

        [HttpPost()]
        public async Task<ActionResult> CreateCharacter(CreateCharacterModel model)
        {
            Character character = await _mapper.MapCharacterModelToEntity(model, CurrentLanguage);

            //Logic.CharacterLogic.CharacterCreate(character);

            return Ok();
        }

        //[HttpGet("{userId}")]
        //public async Task<ActionResult<GetUserModel>> GetUserById(Guid userId)
        //{
        //    SystemUser user = await Logic.UserLogic.GetUserById(userId);

        //    GetUserModel model = _mapper.MapTo<GetUserModel>(user, CurrentLanguage);

        //    return Ok(model);
        //}
    }
}
