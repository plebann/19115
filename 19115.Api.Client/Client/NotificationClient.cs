using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using _19115.Api.Models;
using System.Threading.Tasks;
using System.Configuration;

namespace _19115.Api.Client
{
	public class NotificationClient : BaseClient, INotificationClient
	{
		private static readonly string ResourceId = ConfigurationManager.AppSettings.Get("ResourceId");
		public NotificationClient(string baseUrl, string apiKey) 
			: base(new Utils.JsonSerializer(), baseUrl, apiKey)
		{ }

		public async Task<List<Notification>> GetNotificationsAsync(List<Filter> filters, List<string> operators)
		{
			var request = _getRequest("action/19115store_getNotifications", Method.GET);

			request.AddQueryParameter("filters", $"\"filters\":{JsonConvert.SerializeObject(filters)}");
			request.AddQueryParameter("operators", $"\"operators\":{JsonConvert.SerializeObject(operators)}");

			var result = await GetAsync<RootObject>(request);
			return result.result.result.Notifications;
		}
		
		private RestRequest _getRequest(string action, Method method)
		{
			var request = new RestRequest(action, method);
			request.AddQueryParameter("id", ResourceId);
			return request;
		}
	}
}
