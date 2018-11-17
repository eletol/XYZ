using XYZ.DAL.Collections.Interfaces;
using XYZ.DAL.DBContext;
using XYZ.DAL.Models;

namespace XYZ.DAL.Collections.Classes
{
    public class UserGroupsCollection : BaseCollection<UserGroup, IDbContext>, IUserGroupsCollection
    {
  
    }
}