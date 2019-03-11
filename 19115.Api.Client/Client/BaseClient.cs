using RestSharp;
using RestSharp.Deserializers;
using System;
using _19115.Api.Extensions;
using System.Threading.Tasks;

namespace _19115.Api.Client
{
	public class BaseClient : RestClient
	{
		protected string ApiKey { get; private set; }
		public BaseClient(
			IDeserializer serializer,
			string baseUrl,
			string apiKey)
		{
			AddHandler("application/json", () => serializer);
			AddHandler("text/json", () => serializer);
			AddHandler("text/x-json", () => serializer);
			BaseUrl = new Uri(baseUrl);
			ApiKey = apiKey;
		}

		public override RestRequestAsyncHandle ExecuteAsync<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
		{
			request.AddQueryParameter("apikey", ApiKey);
			return base.ExecuteAsync(request, callback);
		}

		public async Task<T> GetAsync<T>(IRestRequest request) where T : new()
		{
			var taskCompletionSource = new TaskCompletionSource<T>();
			this.ExecuteAsync<T>(request, response =>
			{
				this.EnsureResponseWasSuccessful(request, response);
				taskCompletionSource.SetResult(response.Data);
			});

			return await taskCompletionSource.Task;
		}
	}
}
