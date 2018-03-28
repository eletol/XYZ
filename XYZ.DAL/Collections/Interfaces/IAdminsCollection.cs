using XYZ.DAL.DBContext;
using XYZ.DAL.Models;

namespace XYZ.DAL.Collections.Interfaces
{
    interface IAdminsCollection : IBaseCollection<Admin, IDbContext>
    {
    }
}
