using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FizyoterapiSite.Controllers
{
	public class AboutController : Controller
	{
		AboutManager abm = new AboutManager(new EfAboutDal());
		[AllowAnonymous]
		public ActionResult Index()
		{
			var aboutList = abm.GetAll();
			return View(aboutList);
		}
		public ActionResult AAboutList()
		{
			var aboutlist = abm.GetAll();
			return View(aboutlist);
		}
		[HttpGet]
		public ActionResult AAboutUpdate(int id)
		{
			var aboutid = abm.GetByID(id);
			return View(aboutid);
		}
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult AAboutUpdate(About a)
		{

			abm.AboutUpdate(a);
			return RedirectToAction("AAboutList");

		}
	}
}