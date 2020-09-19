using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace DaniyalSite.Controllers
{
	public class SearchController : Controller
	{
		DataBaseContext dataBaseContext = new DataBaseContext();
		private IPageRepository pageRepository;

		public SearchController()
		{
			pageRepository = new PageRepository(dataBaseContext);
		}
		// GET: Search
		public ActionResult Index(string q)
		{
			ViewBag.Name = q;
			return View(pageRepository.SearchPage(q));
		}
	}
}