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
    [Table("User")]
    public partial class User : IdentityUser<string, UserLogin, UserRole, UserClaim>, IBaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            CreationDate = DateTime.Now;
            LastUpdate = DateTime.Now;
            IsDeleted = false;

        }
        public bool? IsDeleted { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string CountryCode { get; set; }

        public string Name { get; set; }
        public string Photo { get; set; }

        [Required(ErrorMessage = "Kindly, enter the mobile number.")]
        [Display(Name = "Mobile Number")]
        [Phone]
        public string MobileNumber { get; set; }
        public bool? Active { get; set; }
        public virtual ICollection<UserFriend> UserFriends { get; set; }
        public virtual ICollection<UserDevice> UserDevices { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, string> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
