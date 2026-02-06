using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class GameSessionParticipant : BaseEntity
    {
        public GameSessionParticipant()
        {
            
        }
        public GameSessionParticipant(GameSession gameSession, Character character, RoleType role)
        {
            GameSession = gameSession;
            Character = character;
            Role = role;
            GameSessionId = gameSession.Id;
            UserId = character.SystemUser.Id;
            CharacterId = character.Id;
        }
        [Required]
        public Guid GameSessionId { get; set; }
        [ForeignKey(nameof(GameSessionId))]
        public virtual GameSession GameSession { get; set; }
        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
        [Required]
        public Guid CharacterId { get; set; }
        [ForeignKey(nameof(CharacterId))]
        public virtual Character Character { get; set; }
        public RoleType Role { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    }
}
