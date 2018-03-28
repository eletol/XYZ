using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace XYZ.DAL.Models
{
    [Table("ClientClaim")]
    public partial class ClientClaim : IdentityUserClaim<string>
    {
     
    }
}
