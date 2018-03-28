
using DAL.Models;
using XYZ.DAL.Collections.Interfaces;
using XYZ.DAL.DBContext;
using XYZ.DAL.Models;

namespace DAL.Collections.Interfaces
{
 
    interface IPlayerStatusCollection : IBaseCollection<PlayerStatus, IDbContext>
    {
    }

}
