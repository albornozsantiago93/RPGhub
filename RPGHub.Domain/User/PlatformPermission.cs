using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Domain
{
    public class PlatformPermission : BaseEntity
    {
        [Column(TypeName = "Varchar(100)")]
        public string Description { get; set; }
        public PlatformPermissionName PermissionName { get; set; }
    }

    public enum PlatformPermissionName
    {
        ManageUsers = 1,
        ManageCourses = 2,
        ViewReports = 3,
        ConfigureSettings = 4
    }
}
