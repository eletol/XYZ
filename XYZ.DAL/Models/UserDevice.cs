using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZ.DAL.Models
{
   
    public class UserDevice : EntityBase
    {
       


        [MaxLength]
        public string DeviceToken { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        public string OSType { get; set; }
        public User User { get; set; }
    }


    
}