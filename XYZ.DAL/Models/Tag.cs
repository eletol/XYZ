using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZ.DAL.Models
{
   
    public class Tag : EntityBase
    {
        public string Name { get; set; }

        public string Body { get; set; }
        public DateTime? ExpiryDate { get; set; }

        [ForeignKey("Group")]
        public long GroupId { get; set; }
        public Group Group { get; set; }

        [ForeignKey("TagStatus")]
        public long TagStatusId { get; set; }
        public TagStatus TagStatus { get; set; }

    }



}