using XYZ.BL.BussinessMangers.Classes;
using XYZ.BL.BussinessMangers.Interfaces;
using XYZ.DAL.DBContext;
using XYZ.DAL.Repository.Classes;
using XYZ.DAL.UnitOfWork;
using Ninject.Modules;
using Ninject.Web.Common;

namespace XYZ.BL.NinjectModules
{
    public class HelperModule : NinjectModule
    {
        public override void Load()
        {
            //TODO: Divid them to multiapule modules
            Bind<IDbContext>().To<DBContext>().InRequestScope();
            Bind<IUnitOfWork>().To<UnitOfWork<DBContext>>().InRequestScope();
            Bind<IAdminsBusinessManager>().To<AdminsBusinessManager<AdminsRepository>>().InRequestScope();
            Bind<IUsersBusinessManager>().To<UsersBusinessManager<UsersRepository>>().InRequestScope(); ;
            Bind<ITagStatusBusinessManager>().To<TagStatusBusinessManager<TagStatusRepository>>().InRequestScope(); ;

        }
    }
}