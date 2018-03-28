

using DAL.Collections.Interfaces;
using DAL.Models;
using XYZ.DAL.Collections.Classes;
using XYZ.DAL.DBContext;
using XYZ.DAL.Models;

namespace DAL.Collection.Classes
{

    public class PlayerStatusCollection : BaseCollection<PlayerStatus, IDbContext>, IPlayerStatusCollection
    {

    }
   
}