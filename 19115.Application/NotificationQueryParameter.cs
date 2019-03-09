namespace _19115.Application
{
	public class NotificationQueryParameter
	{
		public string Value { get; set; }
		public string Field { get; set; }
		public string Operator { get; private set; } = "EQ";
		private NotificationQueryParameter(string value)
		{
			Value = value;
		}

		public static implicit operator NotificationQueryParameter(string input)
		{
			return new NotificationQueryParameter(input);
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}
