using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class Invitation : BaseEntity
    {
        public Guid GameSessionId { get; set; }
        public virtual GameSession Session { get; set; }
        public Guid InvitedUserId { get; set; }
        public virtual SystemUser InvitedUser { get; set; }
        public InvitationStatus Status { get; set; } = InvitationStatus.Pending;
        public DateTime SentDate { get; set; } = DateTime.UtcNow;
    }

    public enum InvitationStatus
    {
        Pending = 1,
        Accepted = 2,
        Rejected = 3,
        Expired = 4
    }

}
