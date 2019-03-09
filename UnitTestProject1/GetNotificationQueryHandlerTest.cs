using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using _19115.Api.Client;
using _19115.Api.Models;
using _19115.Application;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Ninject;

namespace UnitTestProject1
{
	[TestClass]
	public class GetNotificationQueryHandlerTest
	{
		public static class NinjectKernel
		{
			public static readonly IKernel Instance = NinjectWebCommon.CreateKernel();
		}
		private IMapper _mapper;

		[TestInitialize]
		public void MyTestInitialize()
		{
			_mapper = NinjectKernel.Instance.Get<IMapper>();
		}

		[TestMethod]
		public async Task GetNotificationQueryHandler_OK()
		{
			
			var getNotificationQueryHandler = new GetNotificationsQueryHandler(_mapper);

			var query = new GetNotificationQuery
			{
				District = "Wola",
				Subcategory = "Komunikacja/Transport"
			};

			var notifications = await getNotificationQueryHandler.Handle(query, CancellationToken.None);
			Assert.IsTrue(notifications.Count > 0);
		}
	}
}
