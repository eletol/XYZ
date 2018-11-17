using System;

namespace XYZ.DAL.Models
{
    public abstract class LookupBase: EntityBase
    {
        public string Name { get; set; }
        public LookupBase()
        {
            IsDeleted = false;
            CreationDate = DateTime.Now;
            LastUpdate= DateTime.Now;
        }
    }
}