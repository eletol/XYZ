using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace XYZ.DAL.Models
{
    [Table("AdminClaim")]
    public partial class AdminClaim : IdentityUserClaim<string>, IBaseModel
    {
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
