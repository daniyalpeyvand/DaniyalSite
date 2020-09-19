using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
namespace DaniyalSite.Controllers
{								
	public class HomeController : Controller
	{
		DataBaseContext dataBaseContext = new DataBaseContext();
		private IPageGroupRepository pageGroupRepository;
		private IPageRepository pageRepository;
		public HomeController()
		{
			pageGroupRepository = new PageGroupRepository(dataBaseContext);
			pageRepository = new PageRepository(dataBaseContext);
		}
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Slider()
		{
			return PartialView(pageRepository.Slider());
		}

		public ActionResult LastNews()
		{
			return PartialView(pageRepository.LastNews());
		}

		[Route ("Archive")]
		public ActionResult ArchiveNews()
		{
			return View(pageRepository.GetAllPages());
		}
	}
}