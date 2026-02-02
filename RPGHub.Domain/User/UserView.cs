using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGHub.Domain
{
    [Keyless]
    public class UserView
    {
        public UserView()
        {
            Permissions = new List<PlatformPermission>();
        }
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? CountryId { get; set; }
        public string CountryCode { get; set; }
        public int? Role { get; set; }
        public string? Picture { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? Language { get; set; }
        public string? UserName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{Firstname} {Lastname}";
            }
        }

        [NotMapped]
        public List<PlatformPermission> Permissions { get; set; }
    }
}
