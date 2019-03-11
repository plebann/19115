using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace _19115.Api.Models
{
	public class Notification
	{
		[JsonProperty(PropertyName = "category")]
		public string Category { get; set; }

		[JsonProperty(PropertyName = "subcategory")]
		public string Subcategory { get; set; }

		[JsonProperty(PropertyName = "city")]
		public string City { get; set; }

		[JsonProperty(PropertyName = "district")]
		public string District { get; set; }

		[JsonProperty(PropertyName = "street")]
		public string Street { get; set; }

		[JsonProperty(PropertyName = "street2")]
		public string Street2 { get; set; }

		[JsonProperty(PropertyName = "aparmentNumber")]
		public object AparmentNumber { get; set; }

		[JsonProperty(PropertyName = "notificationType")]
		public string NotificationType { get; set; }

		[JsonProperty(PropertyName = "createDate")]
		public long CreateDate { get; set; }

		[JsonProperty(PropertyName = "siebelEventId")]
		public string SiebelEventId { get; set; }

		[JsonProperty(PropertyName = "source")]
		public string Source { get; set; }

		[JsonProperty(PropertyName = "deviceType")]
		public string DeviceType { get; set; }

		[JsonProperty(PropertyName = "statuses")]
		public List<Status> Statuses { get; set; }

		[JsonProperty(PropertyName = "notificationNumber")]
		public string NotificationNumber { get; set; }

		[JsonProperty(PropertyName = "event")]
		public string Event { get; set; }

		[JsonProperty(PropertyName = "yCoordOracle")]
		public double YCoordOracle { get; set; }

		[JsonProperty(PropertyName = "xCoordOracle")]
		public double XCoordOracle { get; set; }

		[JsonProperty(PropertyName = "xCoordWGS84")]
		public double XCoordWGS84 { get; set; }

		[JsonProperty(PropertyName = "yCoordWGS84")]
		public double YCoordWGS84 { get; set; }
	}
}
