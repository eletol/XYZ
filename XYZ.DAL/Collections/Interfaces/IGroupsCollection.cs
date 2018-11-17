using XYZ.DAL.DBContext;
using XYZ.DAL.Models;

namespace XYZ.DAL.Collections.Interfaces
{
    interface IGroupsCollection : IBaseCollection<Group, IDbContext>
    {
    }
}
