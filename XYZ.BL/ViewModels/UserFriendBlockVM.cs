using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace XYZ.DAL.Models
{
   
    public class UserFriendBlockVM : EntityBase
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        [JsonIgnore]

        public User User { get; set; }

        [ForeignKey("BlockedUser")]
        public string BlockedUserId { get; set; }
        [JsonIgnore]

        public User BlockedUser { get; set; }
    }


    
}