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
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual SystemUser User { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
        public RoleType Role { get; set; }
        public Guid CharacterId { get; set; }
        public virtual Character Character { get; set; }
        public int? ChurrentChapterOrder { get; set; }

    }
}
