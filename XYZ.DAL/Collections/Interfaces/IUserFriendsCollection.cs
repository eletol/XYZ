using XYZ.DAL.DBContext;
using XYZ.DAL.Models;

namespace XYZ.DAL.Collections.Interfaces
{
    interface IUserFriendsCollection : IBaseCollection<UserFriend, IDbContext>
    {
    }
}
