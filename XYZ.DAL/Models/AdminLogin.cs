using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace XYZ.DAL.Models
{
    [Table("AdminLogin")]
    public partial class AdminLogin:IdentityUserLogin<string>
    {
   
    }
}
