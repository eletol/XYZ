using XYZ.DAL.DBContext;
using XYZ.DAL.Models;

namespace XYZ.DAL.Collections.Interfaces
{
    interface IClientUsersCollection : IBaseCollection<ClientUser, IDbContext>
    {
    }
}
