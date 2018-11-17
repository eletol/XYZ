using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace XYZ.DAL.Models
{
   
    public class UserFriendVM : EntityBase
    {
        [ForeignKey("User1")]
        public string UserId1 { get; set; }
        [JsonIgnore]

        public User User1 { get; set; }

        [ForeignKey("User2")]
        public string UserId2 { get; set; }
        [JsonIgnore]

        public User User2 { get; set; }
    }


    
}