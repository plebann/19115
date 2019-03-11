using Newtonsoft.Json;

namespace _19115.Api.Models
{
	public class Filter
	{
		[JsonProperty(PropertyName = "field")]
		public string Field { get; set; }

		[JsonProperty(PropertyName = "operator")]
		public string Operator { get; set; }

		[JsonProperty(PropertyName = "value")]
		public string Value { get; set; }
	}
}
