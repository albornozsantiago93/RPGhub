using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class GameSession : BaseEntity
    {
        [Required, MaxLength(60)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public GameType GameType { get; set; }
        [Required]
        public Guid MasterId { get; set; }
        public SystemUser Master { get; set; }
        [Required]
        public GameStatus Status { get; set; } = GameStatus.Pending;
        public DateTime ScheduledDate { get; set; }
        // Navegación
        public ICollection<Character> Characters { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
        public ICollection<ChatMessage> Chat { get; set; }
        public ICollection<Log> Logs { get; set; }
        public ICollection<GameSessionParticipant> Participants { get; set; }
    }

    public enum GameStatus
    {
        Pending = 1,    // Creada pero no iniciada
        Active = 2,     // En curso
        Finished = 3    // Terminada
    }

    public enum GameType
    {
        DnD =1,
        Pathfinder=2,
        Warhammer=3,
        CallOfCthulhu=4,
        Custom=5
    }

}
