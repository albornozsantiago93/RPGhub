using RPGHub.Common;
using RPGHub.Domain;
using Microsoft.AspNetCore.Mvc;

namespace RPGHub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StuffController : BaseController
    {

        private static readonly HttpClient Client = new HttpClient();
        private StuffMapper _mapper;

        public StuffController(ISqlContext context, ILogicProxy logicProxy, IHttpContextAccessor httpContextAccessor)
            : base(context, new StuffMapper(logicProxy), httpContextAccessor, logicProxy)
        {
            _mapper = new StuffMapper(logicProxy);
        }


        [HttpGet("countries")]
        public async Task<ActionResult<List<CountryModel>>> GetCountriesAsync()
        {
            List<Country> entity = await Logic.StuffLogic.GetCountries();
            var ret = _mapper.Mapper(CurrentLanguage).Map<List<CountryModel>>(entity);

            return Ok(ret);
        }
    }
}
