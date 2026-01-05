using LMS.Application.Logic;
using LMS.Common;
using LMS.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StuffController : BaseController
    {

        private static readonly HttpClient Client = new HttpClient();
        private StuffMapper _mapper;

        public StuffController(SqlContext context, IHttpContextAccessor httpContextAccesor) : base(context, new StuffMapper(), httpContextAccesor)
        {
            _mapper = new StuffMapper(Logic);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Courses retrieved successfully" });
        }
    }
}
