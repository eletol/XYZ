using System;
using Newtonsoft.Json;

namespace XYZ.DAL.Models
{
    public abstract class EntityBase: IBaseModel
    {
        [JsonIgnore]
        public long Id { get; set; }
        [JsonIgnore]

        public DateTime? CreationDate { get; set; }
        [JsonIgnore]

        public DateTime? LastUpdate { get; set; }
        [JsonIgnore]

        public bool? IsDeleted { get; set; } 


    }
}