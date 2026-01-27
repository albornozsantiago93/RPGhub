using LMS.Application.Logic;
using LMS.Common;
using LMS.Common.DTOs;
using LMS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers
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

        [HttpGet("countries")]
        public ActionResult<List<CountryModel>> GetCountries()
        {
            List<CountryModel> ret = new List<CountryModel>();
            List<Country> entity = Logic.StuffLogic.GetCountries();//_mapper.Logic.StuffLogic.GetCountries();

            ret = Mapper.Mapper(CurrentLanguage).Map<List<CountryModel>>(entity);

            return Ok(ret);
        }
    }
}
