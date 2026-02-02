using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class ChatMessage
    {
        [Key]
        public Guid Id { get; set; }
        public Guid GameSessionId { get; set; }
        public virtual GameSession Session { get; set; }
        public Guid SenderId { get; set; }
        public virtual SystemUser Sender { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime SentDate { get; set; } = DateTime.UtcNow;
    }
}
