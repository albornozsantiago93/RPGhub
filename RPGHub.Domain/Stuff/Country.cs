using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class Country
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar(200)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(10)")]
        public string Code { get; set; }

        [Column(TypeName = "Varchar(200)")]
        public string FlagIcon { get; set; }
        [Column(TypeName = "Varchar(10)")]
        public string PhoneCode { get; set; }
        public int Gmt { get; set; }

        [Column(TypeName = "Varchar(10)")]
        public string Language { get; set; }
    }
}
