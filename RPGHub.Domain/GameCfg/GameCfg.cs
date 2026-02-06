
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGHub.Domain
{ 
    public class GameCfg(string name, string instructions, string image, int playerLimit)
    {
        public GameCfg() : this(string.Empty, string.Empty, string.Empty, 0)
        {
            IsActive = true;
        }

        [Key]
        public int Id { get; init; }
        [Required, MaxLength(126)]
        public string Name { get; set; } = name;
        public int PlayerLimit { get; set; } = playerLimit;
        [Column(TypeName = "nvarchar(MAX)")]
        public string Instructions { get; set; } = instructions;
        public string Image { get; set; } = image;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
        public virtual ICollection<GameSession> Sessions { get; set; } = new List<GameSession>();

    }
}

