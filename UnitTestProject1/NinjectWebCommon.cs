using _19115.Api.Client;
using MediatR;
using Ninject;

namespace UnitTestProject1
{
	public static class NinjectWebCommon
	{
		public static IKernel CreateKernel()
		{
			var kernel = new StandardKernel(new AutoMapperModule());

			RegisterServices(kernel);

			return kernel;
		}
		public static void RegisterServices(IKernel kernel)
		{
			kernel.Bind<IMediator>().To<Mediator>();
			kernel.Bind<INotificationClient>().To<NotificationClient>();
		}
	}
}
