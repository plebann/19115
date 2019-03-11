using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using _19115.Api.Client;
using _19115.Api.Models;
using MediatR;

namespace _19115.Application
{
	public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationQuery, List<Notification>>
	{
		private readonly INotificationClient _notificationClient;

		public GetNotificationsQueryHandler()
		{
			var apiKey = ConfigurationManager.AppSettings.Get("ApiKey");
			var url = ConfigurationManager.AppSettings.Get("WarsawApiUrl");
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
					Field = nameof(query.District).ToUpper(),
					Operator = "EQ",
					Value = query.District
				});
			}
			if (!string.IsNullOrEmpty(query.Subcategory))
			{
				filters.Add(
				new Filter
				{
					Field = nameof(query.Subcategory).ToUpper(),
					Operator = "EQ",
					Value = query.Subcategory
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
