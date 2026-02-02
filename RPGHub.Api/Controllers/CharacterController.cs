using RPGHub.Common;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult GetCourse()
        {
            return Ok(new { Message = "Courses retrieved successfully" });
        }

    }
}
