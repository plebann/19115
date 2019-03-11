using System.Collections.Generic;
using System.Threading.Tasks;
using _19115.Api.Models;

namespace _19115.Api.Client
{
	public interface INotificationClient
	{
		Task<List<Notification>> GetNotificationsAsync(List<Filter> filters, List<string> operators);
	}
}
