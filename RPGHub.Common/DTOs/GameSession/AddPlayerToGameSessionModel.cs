using RPGHub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Common
{
    public class AddPlayerToGameSessionModel
    {
        public Guid CharacterId { get; set; }
        public RoleType Role { get; set; }
    }
}
