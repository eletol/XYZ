using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace XYZ.DAL.Models
{
   
    public class UserGroupVM : EntityBase
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        [JsonIgnore]

        public User User { get; set; }

        [ForeignKey("Group")]
        public long GroupId { get; set; }
        [JsonIgnore]

        public Group Group { get; set; }
    }


    
}