using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace XYZ.DAL.Models
{
    [Table("ClientUser")]
    public partial class ClientUser : IdentityUser<string, ClientLogin, ClientRole, ClientClaim>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientUser()
        {
     
       
        }
        

        [Required(ErrorMessage = "Kindly, enter the mobile number.")]
        [Display(Name = "Mobile Number")]
        [Phone]
        public string MobileNumber { get; set; }
        public bool? Active { get; set; }
    


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ClientUser, string> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
