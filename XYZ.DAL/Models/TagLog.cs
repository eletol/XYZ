using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZ.DAL.Models
{
   
    public class TagLog : EntityBase
    {
        [ForeignKey("Tag")]
        public long TagId { get; set; }
        public Tag Tag { get; set; }

        [ForeignKey("UserTo")]
        public string UserToId { get; set; }
        public User UserTo { get; set; }

        [ForeignKey("UserFrom")]
        public string UserFromId { get; set; }
        public User UserFrom { get; set; }


    }



}