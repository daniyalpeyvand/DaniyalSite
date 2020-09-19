using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace DaniyalSite
{
	public class NewsController : Controller
	{
		DataBaseContext dataBaseContext = new DataBaseContext();
		private IPageGroupRepository pageGroupRepository;
		private IPageRepository pageRepository;
		private IPageCommentRepository pageCommentRepository;
		public NewsController()
		{
			pageGroupRepository = new PageGroupRepository(dataBaseContext);
			pageRepository = new PageRepository(dataBaseContext);
			pageCommentRepository = new PageCommentRepository(dataBaseContext);
		}
		// GET: News
		public ActionResult ShowGroups()
		{
			return PartialView(pageGroupRepository.GetGroupsForView());
		}

		public ActionResult GroupsMenu()
		{
			return PartialView(pageGroupRepository.GetAllGroups());
		}

		public ActionResult TopNews()
		{
			return PartialView(pageRepository.TopNews());
		}

		[Route ("Group/{id}/{title}")]
		public ActionResult ShowNewsByGroup(int id,string title)
		{
			ViewBag.name = title;
			return View(pageRepository.ShowPageByGroupId(id));
		}

		[Route ("News/{Id}")]
		public ActionResult ShowNews(int id)
		{
			var news = pageRepository.GetPageById(id);
			if (news == null)
			{
				return HttpNotFound();
			}
			news.Visit += 1;
			pageRepository.UpdatePage(news);
			pageRepository.Save();
			return View(news);
		}

		public ActionResult AddComment(int id , string name,string email,string comment)
		{
			PageComment pageComment = new PageComment()
			{
				CreateDate = DateTime.Now,
				Comment = comment,
				Name = name,
				Email = email,
				PageID = id
			};
			pageCommentRepository.AddComment(pageComment);
			return PartialView("ShowComments",pageCommentRepository.GetCommentByNewsID(id));
		}
		public ActionResult ShowComments(int id)
		{
			return PartialView(pageCommentRepository.GetCommentByNewsID(id));
		}
	}
}