using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using _19115.Api.Client;
using _19115.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
	[TestClass]
	public class NotificationClientTest
	{
		private string apiKey;
		private string url;
		[TestInitialize]
		public void Init()
		{
			apiKey = ConfigurationManager.AppSettings.Get("ApiKey");
			url = ConfigurationManager.AppSettings.Get("WarsawApiUrl");
		}

		[TestMethod]
		public async Task GetNotifications_OK()
		{
			var notificationClient = new NotificationClient(url, apiKey);
			var filters = new List<Filter>()
			{
				new Filter{
					Field = "DISTRICT",
					Operator = "EQ",
					Value = "Żoliborz"
				},
				new Filter
				{
					Field = "SUBCATEGORY",
					Operator = "EQ",
					Value = "Komunikacja/Transport"
				}
			};
			var operators = new List<string>();
			for (var i = 1; i < filters.Count; i++)
			{
				operators.Add("AND");
			}
			var notifications = await notificationClient.GetNotificationsAsync(filters, operators);
			Assert.IsTrue(notifications.Count > 0);
		}
	}
}
