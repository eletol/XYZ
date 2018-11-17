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
            context.TagStatuses.AddOrUpdate(
                        p => p.Id,
                        new TagStatus { Id = TagStatuses.Active.Id, Name = TagStatuses.Active.Name },
                        new TagStatus { Id = TagStatuses.InActive.Id, Name = TagStatuses.InActive.Name }
                        );

       

            context.SaveChanges();
            
            
        }
    }

}