using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace XYZ.DAL.Models
{
    [Table("AdminRole")]
    public partial class AdminRole : IdentityUserRole<string>, IBaseModel
    {
        public bool? IsDeleted { get; set; }
        public DateTime? CreationDate { get; set; } 
        public DateTime? LastUpdate { get; set; }

        public AdminRole()
        {
            CreationDate = DateTime.Now;
            LastUpdate = DateTime.Now;
            IsDeleted = false;
        }
    }
    [Table("RoleForAdmin")]
    public partial class RoleForAdmin : IdentityRole<string, AdminRole>, IBaseModel
    {
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
