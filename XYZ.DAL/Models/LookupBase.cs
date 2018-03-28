using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DAL.Models
{
    public abstract class LookupBase: EntityBase
    {
        public string Name { get; set; }
    }
}