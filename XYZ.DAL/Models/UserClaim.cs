using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace XYZ.DAL.Models
{
    [Table("UserClaim")]
    public partial class UserClaim : IdentityUserClaim<string>
    {
        public bool? IsDeleted { get; set; }

        public UserClaim()
        {
            
        }
    }
}
