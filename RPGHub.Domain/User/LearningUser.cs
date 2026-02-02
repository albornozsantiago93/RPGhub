using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class LearningUser : BaseUserEntity
    {
        [Column(TypeName = "Int")]
        public virtual long FacebookId { get; set; }
        public Guid? SignInKey { get; set; }
    }
}
