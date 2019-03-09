using RestSharp;
using RestSharp.Deserializers;
using System;
using _19115.Api.Extensions;
using System.Threading.Tasks;

namespace _19115.Api.Client
{
	public class BaseClient : RestClient
	{
		//protected ICacheService _cache;
		protected string ApiKey { get; private set; }
		public BaseClient(
			//ICacheService cache, 
			IDeserializer serializer,
			string baseUrl,
			string apiKey)
		{
			//_cache = cache;
			//_errorLogger = errorLogger;
			AddHandler("application/json", () => serializer);
			AddHandler("text/json", () => serializer);
			AddHandler("text/x-json", () => serializer);
			BaseUrl = new Uri(baseUrl);
			ApiKey = apiKey;
		}

		public override IRestResponse Execute(IRestRequest request)
		{
			request.AddQueryParameter("apikey", ApiKey);
			var response = base.Execute(request);

			return response;
		}
		public override IRestResponse<T> Execute<T>(IRestRequest request)
		{
			request.AddQueryParameter("apikey", ApiKey);
			var response = base.Execute<T>(request);
			return response;
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

		public T Get<T>(IRestRequest request) where T : new()
		{
			var response = Execute<T>(request);
			this.EnsureResponseWasSuccessful(request, response);

			return response.Data;
		}

		public T GetFromCache<T>(IRestRequest request, string cacheKey) where T : class, new()
		{
			//var item = _cache.Get<T>(cacheKey);
			//if (item == null)
			//{
			//	var response = Execute<T>(request);
			//	if (response.StatusCode == System.Net.HttpStatusCode.OK)
			//	{
			//		//_cache.Set(cacheKey, response.Data);
			//		item = response.Data;
			//	}
			//	else
			//	{
			//		LogError(BaseUrl, request, response);
			//		return default(T);
			//	}
			//}
			//return item;
			return null;

		}
	}
}
