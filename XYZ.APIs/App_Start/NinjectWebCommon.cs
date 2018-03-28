using System;
using System.Web;
using System.Web.Http;
using DAL.Repository.Classes;
using DAL.Repository.Interfaces;
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
            kernel.Bind<IClientUsersBusinessManager>().To<ClientUsersBusinessManager<ClientUsersRepository>>().InRequestScope(); ;
            kernel.Bind<IPlayerStatusBusinessManager>().To<PlayerStatusBusinessManager<PlayerStatusRepository>>().InRequestScope(); ;


        }
    }
}
