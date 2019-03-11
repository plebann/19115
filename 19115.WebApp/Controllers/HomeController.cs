using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _19115.Api.Models;
using _19115.Application;
using MediatR;
using Ninject;

namespace _19115.WebApp.Controllers
{
	public class HomeController : Controller
	{
		//[Inject]
		private IMediator _mediator;

		public HomeController(IMediator mediator)
		{
			_mediator = mediator;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> GetDataAjax(string district, string subcategory)
		{
			try
			{
				var query = new GetNotificationQuery
				{
					District = district,
					Subcategory = subcategory
				};
				var result = await _mediator.Send(query);
				return Json(result);
			}
			catch
			{
				return Json(new List<Notification>());
			}
		}
	}
}
