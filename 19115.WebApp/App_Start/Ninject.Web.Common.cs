﻿[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(_19115.WebApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(_19115.WebApp.App_Start.NinjectWebCommon), "Stop")]

namespace _19115.WebApp.App_Start
{
    using System;
    using System.Web;
	using MediatR;
	using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
	using Ninject.Web.Common.WebHost;
	using Ninject.Extensions.Conventions;
	using MediatR.Ninject;
	using _19115.Application;
	using System.Collections.Generic;
	using _19115.Api.Models;

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
			kernel.BindMediatR();

			kernel.Bind<IRequestHandler<GetNotificationQuery, List<Notification>>>().To<GetNotificationsQueryHandler>();

			kernel.Bind(scan => scan.FromAssembliesMatching("19115.Application.dll")
				.SelectAllClasses()
				.Where(o => o.IsAssignableFrom(typeof(IRequestHandler<,>)))
				.BindAllInterfaces());
		}        
    }
}
