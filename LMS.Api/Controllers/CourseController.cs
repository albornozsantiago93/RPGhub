using Microsoft.AspNetCore.Mvc;
using System.Data;
using LMS.Application.Logic;
using LMS.Common;

namespace LMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : BaseController
    {

        private readonly ILogger<CourseController> _logger;

        public CourseController()
        {

        }

        public CourseController(ILogger<CourseController> logger):this()
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetCourse()
        {
            return Ok(new { Message = "Courses retrieved successfully" });
        }
    }
}
