using System.Web.Mvc;

namespace ZooWebApp.Controllers
{
	public class AnimalController : Controller
	{
		//
		// GET: /Animal/

		public ActionResult Index()
		{
			return View("Index");
		}
		public ActionResult List()
		{
			return View("List");
		}

		public ActionResult _Animal()
		{
			return View("_Animal");
		}

	  
	}
}