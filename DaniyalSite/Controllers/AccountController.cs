using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Web.Security;

namespace DaniyalSite.Controllers
{
	public class AccountController : Controller
	{
		private IAdminLoginRepository adminLoginRepository;
		DataBaseContext dataBaseContext = new DataBaseContext();

		public AccountController()
		{
			adminLoginRepository = new AdminLoginRepository(dataBaseContext);
		}
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(AdminLoginViewModel Login , string ReturnUrl="/")
		{
			if (ModelState.IsValid)
			{
				if (adminLoginRepository.IsEsixtUser(Login.UserName , Login.Password))
				{
					FormsAuthentication.SetAuthCookie(Login.UserName, Login.RememberMe);
					return Redirect(ReturnUrl);
				}
				else
				{
					ModelState.AddModelError("UserName","کاربری یافت نشد");
				}
			}
			return View(Login);
		}
		public ActionResult SignOut()
		{
			FormsAuthentication.SignOut();
			return Redirect("/");
		}
	}
}