using System.ComponentModel.DataAnnotations.Schema;

namespace XYZ.DAL.Models
{
   
    public class UserFriendBlock : EntityBase
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("BlockedUser")]
        public string BlockedUserId { get; set; }
        public User BlockedUser { get; set; }
    }


    
}