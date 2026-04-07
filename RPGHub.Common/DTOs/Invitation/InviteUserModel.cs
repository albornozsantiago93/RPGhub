using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Common.DTOs
{
    public class InviteUserModel
    {
        public Guid GameSessionId { get; set; }
        public Guid InviteUserId { get; set; }

    }
}
