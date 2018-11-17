using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace XYZ.DAL.Models
{
    [Table("UserLogin")]
    public partial class UserLogin : IdentityUserLogin<string>, IBaseModel
    {
        public bool? IsDeleted { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdate { get; set; }

        public UserLogin()
        {
            CreationDate = DateTime.Now;
            LastUpdate = DateTime.Now;
            IsDeleted = false;
        }
    }
}
