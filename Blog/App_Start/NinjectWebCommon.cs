using Blog.Interfaces.Repositories;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Blog.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Blog.App_Start.NinjectWebCommon), "Stop")]

namespace Blog.App_Start
{
	using Blog.Data;
	using Blog.Data.Dao.Mock;
	using Blog.Interfaces;
	using Blog.Interfaces.Models;
	using Microsoft.Web.Infrastructure.DynamicModuleHelper;
	using Ninject;
	using Ninject.Web.Common;
	using System;
	using System.Web;

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
			kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
			kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

			RegisterServices(kernel);
			return kernel;
		}

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
#if DEBUG
			kernel.Bind<IDao<IBlogEntryModel>>().To<MockBlogEntryDao>();
			kernel.Bind<IDao<ITagModel>>().To<MockTagDao>();
			kernel.Bind<IDao<IBlogEntryTagModel>>().To<MockBlogEntryTagDao>();
#else
            kernel.Bind<IDao<IBlogEntryModel>>().To<BlogEntryDao>();
            kernel.Bind<IDao<ITagModel>>().To<TagDao>();
            kernel.Bind<IDao<IBlogEntryTagModel>>().To<BlogEntryTagDao>();
#endif
			kernel.Bind<IBlogEntryRepository>().To<BlogEntryRepository>();
			kernel.Bind<ITagRepository>().To<TagRepository>();
		}
	}
}
