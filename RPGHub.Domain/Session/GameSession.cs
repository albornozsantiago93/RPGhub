using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGHub.Domain
{
    public class GameSession
    {
        public GameSession()
        {
            Participants = new List<GameSessionParticipant>();
            CreatedDate = DateTime.UtcNow;
            //Invitations = new List<Invitation>();
            //Chat = new List<ChatMessage>();
            //Logs = new List<LogHistory>();
        }

        public GameSession(string title, string description, DateTime scheduleDate, GameSessionStatus status, int gameId) : this()
        {
            Title = title;
            Description = description;
            ScheduledDate = scheduleDate;
            Status = status;
            GameCfgId = gameId;
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public int GameCfgId { get; set; }
        [ForeignKey(nameof(GameCfgId))]
        public virtual GameCfg GameCfg { get; set; }
        [Required, MaxLength(126)]
        public string Title { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }
        [Required]
        public GameSessionStatus Status { get; set; } = GameSessionStatus.Pending;
        public DateTime? ScheduledDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public Guid MasterId { get; set; }
        [ForeignKey(nameof(MasterId))]
        public virtual SystemUser Master { get; set; }
        public virtual ICollection<GameSessionParticipant> Participants { get; set; }
        //public virtual ICollection<Invitation> Invitations { get; set; }
        //public virtual ICollection<ChatMessage> Chat { get; set; }
        //public virtual ICollection<LogHistory> Logs { get; set; }
    }

    public enum GameSessionStatus
    {
        Pending = 1,    // Creada pero no iniciada
        Active = 2,     // En curso
        Finished = 3    // Terminada
    }

    public enum GameType
    {
        DnD = 1,
        Pathfinder = 2,
        Warhammer = 3,
        CallOfCthulhu = 4,
        Custom = 5
    }

}
