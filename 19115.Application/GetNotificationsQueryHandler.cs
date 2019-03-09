using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using _19115.Api.Client;
using _19115.Api.Models;
using AutoMapper;
using MediatR;

namespace _19115.Application
{
	public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationQuery, List<Notification>>
	{
		private readonly IMapper _mapper;
		private readonly INotificationClient _notificationClient;

		public GetNotificationsQueryHandler(IMapper mapper)
		{
			_mapper = mapper;
			var apiKey = ConfigurationManager.AppSettings.Get("ApiKey");
			var url = ConfigurationManager.AppSettings.Get("Url");
			_notificationClient = new NotificationClient(url, apiKey);
		}

		public async Task<List<Notification>> Handle(GetNotificationQuery query, CancellationToken cancellationToken)
		{
			var filters = new List<Filter>();
			if (!string.IsNullOrEmpty(query.District))
			{
				filters.Add(
				new Filter
				{
					field = nameof(query.District).ToUpper(),
					@operator = "EQ",
					value = query.District
				});
			}
			if (!string.IsNullOrEmpty(query.Subcategory))
			{
				filters.Add(
				new Filter
				{
					field = nameof(query.Subcategory).ToUpper(),
					@operator = "EQ",
					value = query.Subcategory
				});
			}

			var operators = new List<string>();
			for (var i = 1; i < filters.Count; i++)
			{
				operators.Add("AND");
			}

			return await _notificationClient.GetNotificationsAsync(filters, operators);
		}
	}
}
