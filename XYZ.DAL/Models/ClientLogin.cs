using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace XYZ.DAL.Models
{
    [Table("ClientLogin")]
    public partial class ClientLogin : IdentityUserLogin<string>
    {
       
    }
}
