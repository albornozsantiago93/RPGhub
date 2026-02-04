using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class LogHistory : BaseEntity
    {
        public Guid GameSessionId { get; set; }
        public virtual GameSession Session { get; set; }
        public LogEventType EventType { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public Guid ActorId { get; set; }
        public virtual SystemUser Actor { get; set; }
    }

    public enum LogEventType
    {
        PlayerJoined = 1,
        PlayerLeft = 2,
        CharacterCreated = 3,
        CharacterUpdated = 4,
        GameStarted = 5,
        GameEnded = 6,
        ChatMessageSent = 7,
        InvitationAccepted = 8,
        InvitationRejected = 9
    }

}
