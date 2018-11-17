using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace XYZ.DAL.Models
{
    [Table("AdminLogin")]
    public partial class AdminLogin:IdentityUserLogin<string>, IBaseModel
    {
        public bool? IsDeleted { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdate { get; set; }

        public AdminLogin()
        {
            CreationDate = DateTime.Now;
            LastUpdate = DateTime.Now;
            IsDeleted = false;
        }
    }
}
