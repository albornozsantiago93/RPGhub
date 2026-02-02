using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Common
{
    public class CreateUserModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Picture { get; set; }
        public string Language { get; set; }
        public int CountryId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
