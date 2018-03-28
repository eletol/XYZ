using XYZ.DAL.DBContext;
using XYZ.DAL.UnitOfWork;
using Ninject.Modules;

namespace XYZ.DAL.NinjectModules
{
    public class HelperModule : NinjectModule
    {
        public override void Load()
        {
            //TODO: Divid them to multiapule modules
            Bind<IUnitOfWork>().To<UnitOfWork<DBContext.DBContext>>();
            Bind<IDbContext>().To<DBContext.DBContext>();
            Bind<UnitOfWork<DBContext.DBContext>>().ToSelf().InSingletonScope();
            Bind<DBContext.DBContext>().ToSelf().InSingletonScope();

        }
    }
}