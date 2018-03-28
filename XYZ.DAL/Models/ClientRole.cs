using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

namespace XYZ.DAL.Models
{
    [Table("ClientRole")]
    public partial class ClientRole: IdentityUserRole<string>
    {
  
    }
    [Table("RoleForClient")]
    public partial class RoleForClient : IdentityRole<string, ClientRole>
    {
    }
}
