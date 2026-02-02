using RPGHub.Common;
using Microsoft.AspNetCore.Mvc;

namespace RPGHub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : BaseController
    {

        private readonly ILogger<CourseController> _logger;
        private StuffMapper _mapper;

        public CourseController(ILogger<CourseController> logger, ISqlContext context, ILogicProxy logicProxy, IHttpContextAccessor httpContextAccessor)
            : base(context, new StuffMapper(logicProxy), httpContextAccessor, logicProxy)
        {
            _logger = logger;
            _mapper = new StuffMapper(logicProxy);
        }


        [HttpGet]
        public IActionResult GetCourse()
        {
            return Ok(new { Message = "Courses retrieved successfully" });
        }

    }
}
