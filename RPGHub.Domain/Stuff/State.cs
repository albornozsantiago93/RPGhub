using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain.Stuff
{
    public class State
    {
        public int Id { get; set; }
        public int CountryId { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string Name { get; set; }
    }
}
