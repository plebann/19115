using System.Collections.Generic;
using Newtonsoft.Json;

namespace _19115.Api.Models
{

	public class Result2
	{
		[JsonProperty(PropertyName = "notifications")]
		public List<Notification> Notifications { get; set; }
		public string responseDesc { get; set; }
		public string responseCode { get; set; }
	}

	public class Result
	{
		public bool success { get; set; }
		public Result2 result { get; set; }
	}

	public class RootObject
	{
		public Result result { get; set; }
	}
}
