using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPGHub.Common;
using RPGHub.Domain;

namespace RPGHub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class GameSessionController : BaseController
    {

        private static readonly HttpClient Client = new HttpClient();
        private GameSessionMapper _mapper;

        public GameSessionController(ISqlContext context, ILogicProxy logicProxy, IHttpContextAccessor httpContextAccessor)
            : base(context, new GameSessionMapper(logicProxy), httpContextAccessor, logicProxy)
        {
            _mapper = new GameSessionMapper(logicProxy);
        }

        [HttpPost()]
        public async Task<ActionResult> CreateGameSession(CreateGameSessionModel model)
        {
            Guid ? userId = GetCurrentUserId();
            if ( userId ==  null) return BadRequest("User is mandatory");

            GameSession gameSession = await _mapper.MapCreateGameSessionModelToGameSession(model);

            await Logic.GameSessionLogic.CreateGameSession(gameSession, userId.Value);

            return Ok();
        }
    }
}
