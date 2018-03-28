using DAL.Models;
using XYZ.DAL.DataSeed;
using System.Data.Entity.Migrations;
using XYZ.DAL.Models;

namespace XYZ.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DBContext.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DBContext.DBContext context)
        {
            context.PlayerStatuses.AddOrUpdate(
                        p => p.Id,
                        new PlayerStatus { Id = PlayerStatuses.Active.Id, Name = PlayerStatuses.Active.Name },
                        new PlayerStatus { Id = PlayerStatuses.InActive.Id, Name = PlayerStatuses.InActive.Name }
                        );

       

            context.SaveChanges();
            
            
        }
    }

}