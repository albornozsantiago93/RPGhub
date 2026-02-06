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
        public SystemUser()
        {
            Characters = new List<Character>();
            GameSessions = new List<GameSession>();
        }

        public SystemUser(string firstname, string lastname, string email, DateTime? birthDate, string username, Country country, string language, string picture, string password) :this()
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            BirthDate = birthDate;
            Username = username;
            Country = country;
            Language = language;
            Picture = picture;
            Password = password;
            IsActive = true;
        }

        [InverseProperty("SystemUser")]
        public virtual List<SystemUserPlatformPermision> Permissions { get; set; }
        [Column(TypeName = "Int")]
        public virtual long FacebookId { get; set; }
        public Guid? SignInKey { get; set; }
        public string Picture { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public RoleType Role { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<GameSession> GameSessions { get; set; }

    }

    public enum RoleType
    {
        Admin = 1, 
        Moderator = 2,
        Master = 3,
        Player = 4
    }
}
