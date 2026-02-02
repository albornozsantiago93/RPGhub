using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class SystemUserPlatformPermision : BaseEntity
    {
        public virtual PlatformPermission PlatformPermission { get; set; }
        public virtual SystemUser Systemuser { get; set; }

    }
}
