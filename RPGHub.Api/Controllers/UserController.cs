using RPGHub.Common;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult GetCourse()
        {
            return Ok(new { Message = "Courses retrieved successfully" });
        }

    }
}
