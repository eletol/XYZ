using System.ComponentModel.DataAnnotations.Schema;

namespace XYZ.DAL.Models
{
   
    public class UserGroup : EntityBase
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Group")]
        public long GroupId { get; set; }
        public Group Group { get; set; }
    }


    
}