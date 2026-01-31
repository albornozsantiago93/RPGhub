using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Common
{
    public class UserModel
    {   public UserModel()
        {
            Profiles = new List<ProfileModel>();
            Permissions = new List<string>();
        }

        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
        public string Role { get; set; }
        public bool IsModerator { get; set; }
        public string Picture { get; set; }
        public bool IsFirstLogin { get; set; }
        public List<ProfileModel> Profiles { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string UserName { get; set; }
        public bool Active { get; internal set; }
        public List<string> Permissions { get; set; }
    }

    public class ProfileModel
    {
        public ProfileModel(string role)
        {
            Role = role;
        }
        public string Role { get; set; }
    }
}
