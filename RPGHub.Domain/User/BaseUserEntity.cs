using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class BaseUserEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "Varchar(100)")]
        public string Firstname { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string Lastname { get; set; }

        [Column(TypeName = "Varchar(128)")]
        public string Email { get; set; }

        [Column(TypeName = "Varchar(256)")]
        public string Password { get; set; }
        public virtual Country Country { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? LastLogin { get; set; }

        [Column(TypeName = "Varchar(128)")]
        public string CreatedUser { get; set; }

        [Column(TypeName = "Varchar(128)")]
        public string ModifiedUser { get; set; }

        [Column(TypeName = "Varchar(2)")]
        public string Language { get; set; }


        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{Firstname} {Lastname}";
            }
        }

    }
}
