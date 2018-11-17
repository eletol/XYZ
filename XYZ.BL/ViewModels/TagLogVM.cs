using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using XYZ.DAL.Models;

namespace XYZ.BL.ViewModels
{
    public  class TagLogVM:EntityBase
    {

        public long TagId { get; set; }
        [JsonIgnore]
        public Tag Tag { get; set; }

        public string UserToId { get; set; }
        [JsonIgnore]

        public User UserTo { get; set; }

        public string UserFromId { get; set; }
        [JsonIgnore]

        public User UserFrom { get; set; }

    }
}
