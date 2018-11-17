using XYZ.DAL.Collections.Classes;
using XYZ.DAL.DBContext;
using XYZ.DAL.Models;
using XYZ.DAL.Repository.Interfaces;

namespace XYZ.DAL.Repository.Classes
{
    public class UserGroupsRepository : BaseRepository<UserGroupsCollection, UserGroup>, IUserGroupsRepository
    {
        public UserGroupsRepository(IDbContext context) : base(context)
        {
            Context = context;

        }

        public IDbContext Context { get; set; }
    }
}