using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class GameSession 
    {
        public GameSession()
        {
            Characters = new List<Character>();
            Invitations = new List<Invitation>();
            Chat = new List<ChatMessage>();
            Logs = new List<Log>();
            Participants = new List<GameSessionParticipant>();
            CreatedDate = DateTime.UtcNow;
        }

        public GameSession(string title, string description, DateTime scheduleDate, GameStatus status):this()
        {
            Title = title;
            Description = description;
            ScheduledDate = scheduleDate;
            Status = status;
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid MasterId { get; set; }

        [ForeignKey(nameof(MasterId))]
        public virtual SystemUser Master { get; set; }

        [Required, MaxLength(60)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public GameType GameType { get; set; }
        [Required]
        public GameStatus Status { get; set; } = GameStatus.Pending;
        public DateTime? ScheduledDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
        public virtual ICollection<ChatMessage> Chat { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<GameSessionParticipant> Participants { get; set; }
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
