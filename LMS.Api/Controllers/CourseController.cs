using Microsoft.AspNetCore.Mvc;
using System.Data;
using LMS.Application.Logic;

namespace LMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {

        private readonly ILogger<CourseController> _logger;

        public CourseController()
        {

        }

        public CourseController(ILogger<CourseController> logger)
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
