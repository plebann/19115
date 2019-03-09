using System;
using System.Net;
using System.Text;
using RestSharp;
using _19115.Api.Extensions;

namespace _19115.Api.Utils
{
	public class RestException : Exception
	{
		public RestException(HttpStatusCode httpStatusCode, Uri requestUri, string content, string message, Exception innerException)
		  : base(message, innerException)
		{
			HttpStatusCode = httpStatusCode;
			RequestUri = requestUri;
			Content = content;
		}

		public HttpStatusCode HttpStatusCode { get; private set; }

		public Uri RequestUri { get; private set; }

		public string Content { get; private set; }

		public static RestException CreateException(Uri requestUri, IRestResponse response)
		{
			Exception innerException = null;

			var messageBuilder = new StringBuilder();

			messageBuilder.AppendLine(string.Format("Processing request [{0}] resulted with following errors:", requestUri));

			if (!response.StatusCode.IsScuccessStatusCode())
			{
				messageBuilder.AppendLine("- Server responded with status code: " + response.StatusDescription);
			}

			if (response.ErrorException != null)
			{
				messageBuilder.AppendLine("- An exception occurred while processing request: " + response.ErrorMessage);

				innerException = response.ErrorException;
			}

			return new RestException(response.StatusCode, requestUri, response.Content, messageBuilder.ToString(), innerException);
		}
	}
}
