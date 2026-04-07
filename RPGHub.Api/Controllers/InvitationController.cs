using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPGHub.Common;
using RPGHub.Common.DTOs;
using RPGHub.Domain;

namespace RPGHub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvitationController : BaseController
    {

        private readonly ILogger<InvitationController> _logger;
        private InvitationMapper _mapper;

        public InvitationController(ILogger<InvitationController> logger, ISqlContext context, ILogicProxy logicProxy, IHttpContextAccessor httpContextAccessor)
            : base(context, new InvitationMapper(logicProxy), httpContextAccessor, logicProxy)
        {
            _logger = logger;
            _mapper = new InvitationMapper(logicProxy);
        }

        [HttpPost()]
        public async Task<ActionResult<int>> InviteUser(InviteUserModel model)
        {
            Guid? user = GetCurrentUserId();
            if (user == null) return BadRequest("Usuario no autorizado");

            var invitation = await Logic.InvitationLogic.InviteUserAsync(user, model.GameSessionId, model.InviteUserId);

            return Ok();
        }
    }
}
