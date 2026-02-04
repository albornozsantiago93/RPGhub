using Microsoft.EntityFrameworkCore;
using RPGHub.Common;
using RPGHub.Common.Logic;
using RPGHub.Domain;
using RPGHub.Infrastructure;

namespace RPGHub.Application.Logic
{
    public class InvitationLogic : IInvitationLogic
    {
        private SqlContext _context;

        public InvitationLogic(SqlContext context)
        {
            _context = context;
        }



    }
}
