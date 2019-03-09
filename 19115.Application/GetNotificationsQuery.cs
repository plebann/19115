using System.Collections.Generic;
using _19115.Api.Models;
using MediatR;

namespace _19115.Application
{
	public class GetNotificationQuery: IRequest<List<Notification>>
    {
		public string District { get; set; }
		public string Subcategory { get; set; }
	}
}
