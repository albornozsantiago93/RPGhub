using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class GameSessionParticipant : BaseEntity
    {
        public Guid GameSessionId { get; set; }
        [ForeignKey(nameof(GameSessionId))]
        public virtual GameSession GameSession { get; set; }
        public Guid SystemUserId { get; set; }
        [ForeignKey(nameof(SystemUserId))]
        public virtual SystemUser SystemUser { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}
