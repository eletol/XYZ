
using DAL.Collection.Classes;
using DAL.Models;
using DAL.Repository.Interfaces;
using XYZ.DAL.DBContext;
using XYZ.DAL.Models;
using XYZ.DAL.Repository.Classes;

namespace DAL.Repository.Classes
{
  
    public class PlayerStatusRepository : BaseRepository<PlayerStatusCollection, PlayerStatus>, IPlayerStatusRepository
    {
        public PlayerStatusRepository(IDbContext context) : base(context)
        {
            Context = context;

        }

        public IDbContext Context { get; set; }
    }


   
   
}