using _19115.Api.Models;
using _19115.Application;
using AutoMapper;
using Ninject.Modules;

namespace UnitTestProject1
{
	public class AutoMapperModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
		}

		private IMapper AutoMapper(Ninject.Activation.IContext context)
		{
			Mapper.Initialize(config =>
			{
				//config.ConstructServicesUsing(type => context.Kernel.Get(type));

				//config.CreateMap<MySource, MyDest>();
				// .... other mappings, Profiles, etc.          
				//config.CreateMap<NotificationQueryParameter, Filter>()
				//	.ForMember(dest => dest.field, opt => opt.MapFrom(src => src.Field));

			});

			Mapper.AssertConfigurationIsValid(); // optional
			return Mapper.Instance;
		}
	}
}
