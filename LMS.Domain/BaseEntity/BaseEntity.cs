using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Column(TypeName = "Varchar(128)")]
        public string CreatedUser { get; set; }

        [Column(TypeName = "Varchar(128)")]
        public string ModifiedUser { get; set; }
    }
}
