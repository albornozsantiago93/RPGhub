using RPGHub.Common;
using Microsoft.AspNetCore.Mvc;
using RPGHub.Domain;
using Microsoft.AspNetCore.Authorization;

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


    }
}
