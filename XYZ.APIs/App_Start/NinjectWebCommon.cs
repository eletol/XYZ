using System;
using System.Web;
using System.Web.Http;
using XYZ.APIs;
using XYZ.BL.BussinessMangers.Classes;
using XYZ.BL.BussinessMangers.Interfaces;
using XYZ.DAL.DBContext;
using XYZ.DAL.Repository.Classes;
using XYZ.DAL.UnitOfWork;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Ninject.Web.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace XYZ.APIs
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDbContext>().To<DBContext>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork<DBContext>>().InRequestScope();
            kernel.Bind<IAdminsBusinessManager>().To<AdminsBusinessManager<AdminsRepository>>().InRequestScope(); ;
            kernel.Bind<IUsersBusinessManager>().To<UsersBusinessManager<UsersRepository>>().InRequestScope(); ;
            kernel.Bind<ITagStatusBusinessManager>().To<TagStatusBusinessManager<TagStatusRepository>>().InRequestScope(); ;
            kernel.Bind<ITagsBusinessManager>().To<TagsBusinessManager<TagsRepository>>().InRequestScope(); ;
            kernel.Bind<ITagLogsBusinessManager>().To<TagLogsBusinessManager<TagLogsRepository>>().InRequestScope(); ;
            kernel.Bind<IGroupsBusinessManager>().To<GroupsBusinessManager<GroupsRepository>>().InRequestScope(); ;
            kernel.Bind<IUserDevicesBusinessManager>().To<UserDevicesBusinessManager<UserDevicesRepository>>().InRequestScope(); ;
            kernel.Bind<IUserFriendsBusinessManager>().To<UserFriendsBusinessManager<UserFriendsRepository>>().InRequestScope(); ;
            kernel.Bind<IUserGroupsBusinessManager>().To<UserGroupsBusinessManager<UserGroupsRepository>>().InRequestScope(); ;
            kernel.Bind<IUserFriendBlocksBusinessManager>().To<UserFriendBlocksBusinessManager<UserFriendBlocksRepository>>().InRequestScope(); ;


        }
    }
}
