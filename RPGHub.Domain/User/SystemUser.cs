using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class SystemUser : BaseUserEntity
    {
        [InverseProperty("SystemUser")]
        public virtual List<SystemUserPlatformPermision> Permissions { get; set; }
        [Column(TypeName = "Int")]
        public virtual long FacebookId { get; set; }
        public Guid? SignInKey { get; set; }
        public string Picture { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public RoleType Role { get; set; }
        public DateTime? DateJoined { get; set; }
        public virtual List<Character> Characters { get; set; }
        [InverseProperty("Master")]
        public virtual ICollection<GameSession> SessionsOwned { get; set; }
        public virtual List<GameSession> SessionJoined { get; set; }

        [InverseProperty("SystemUser")]
        public virtual ICollection<GameSessionParticipant> GameSessions { get; set; }

    }

    public enum RoleType
    {
        Player = 1, //Jugador nomal
        Master = 2, //Creador y moderador de contenido
        Admin = 3 //Permisos especiales en la plataforma
    }
}
