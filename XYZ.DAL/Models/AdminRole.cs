using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace XYZ.DAL.Models
{
    [Table("AdminRole")]
    public partial class AdminRole : IdentityUserRole<string>
    {
     
    }
    [Table("RoleForAdmin")]
    public partial class RoleForAdmin : IdentityRole<string, AdminRole>
    {
    }
}
