using Microsoft.AspNetCore.Mvc;
using Web_Practice_Controller.Models;

namespace Web_Practice_Controller.Controllers
{
	[Controller]
	public class HomeController : Controller
	{
		[Route("/")]
		[Route("/home")]
		public ContentResult Index()
		{
			return Content("<h1>Hello from DUCNHU</h1>", "text/html");
		}

		[Route("/person")]
		public JsonResult showPerson()
		{
			Person duc = new Person(Guid.NewGuid(), "Nhu", "Duc", 21);

			return Json(duc);
		}
	}
}