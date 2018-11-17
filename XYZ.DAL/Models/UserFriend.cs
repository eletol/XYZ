using System.ComponentModel.DataAnnotations.Schema;

namespace XYZ.DAL.Models
{
   
    public class UserFriend : EntityBase
    {
        [ForeignKey("User1")]
        public string UserId1 { get; set; }
        public User User1 { get; set; }

        [ForeignKey("User2")]
        public string UserId2 { get; set; }
        public User User2 { get; set; }
    }


    
}