using System;
using System.Web;
using System.Web.Http;
using CSharpTest.ApplicationServices;
using CSharpTest.Data;
using CSharpTest.Data.Context;
using CSharpTestAPI;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Web.Common;
using Ninject.Web.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace CSharpTestAPI
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
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

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IContextFactory<ICSharpTestContext>>().ToFactory();
            kernel.Bind<ICSharpTestContext>().To<CSharpTestContext>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<ITyreService>().To<TyreService>();
            kernel.Bind<ITyreRepository>().To<TyreRepository>();
            kernel.Bind<IOrderItemsService>().To<OrderItemsService>();
            kernel.Bind<IOrderItemsRepository>().To<OrderItemsRepository>();
        }        
    }
}
