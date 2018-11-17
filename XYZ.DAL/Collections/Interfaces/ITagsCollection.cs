using XYZ.DAL.DBContext;
using XYZ.DAL.Models;

namespace XYZ.DAL.Collections.Interfaces
{
    interface ITagsCollection : IBaseCollection<Tag, IDbContext>
    {
    }
}
