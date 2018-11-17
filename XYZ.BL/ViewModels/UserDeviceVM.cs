using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace XYZ.DAL.Models
{
   
    public class UserDeviceVM : EntityBase
    {
       


        [MaxLength]
        public string DeviceToken { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        public string OSType { get; set; }
        [JsonIgnore]

        public User User { get; set; }
    }


    
}