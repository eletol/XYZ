using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

namespace XYZ.DAL.Models
{
    [Table("UserRole")]
    public partial class UserRole: IdentityUserRole<string>,IBaseModel
    {
        public bool? IsDeleted { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdate { get; set; }

        public UserRole()
        {
            CreationDate = DateTime.Now;
             LastUpdate = DateTime.Now;
           IsDeleted = false;
        }
    }
    [Table("RoleForClient")]
    public partial class RoleForUser : IdentityRole<string, UserRole>, IBaseModel
    {
        public bool? IsDeleted { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
