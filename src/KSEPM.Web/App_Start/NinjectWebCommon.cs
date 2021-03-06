
using System.Web.Mvc;
using KSEPM.Web.Database;
using KSEPM.Web.DataProcessing;
using KSEPM.Web.DataProcessing.Interfaces;
using KSEPM.Web.Infrastructure.AutoMappingConfigurations;
using KSEPM.Web.Infrastructure.TypeMapping;
using Ninject.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(KSEPM.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(KSEPM.Web.App_Start.NinjectWebCommon), "Stop")]

namespace KSEPM.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

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

                DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

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
            kernel.Bind<IKSEPMRepository>().To<KSEPMRepository>();
            ConfigureAutoMapper(kernel);
        }

        private static void ConfigureAutoMapper(IKernel kernel)
        {
            kernel.Bind<IAutoMapper>().To<AutoMapperAdapter>().InSingletonScope();

            kernel.Bind<IAutoMapperTypeConfigurator>().To<ChairsToChairViewModel>().InSingletonScope();
            kernel.Bind<IDateProcessor>().To<DateProcessor>();
        } 
    }
}
