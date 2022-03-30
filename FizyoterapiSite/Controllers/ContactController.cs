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
	public class ContactController : Controller
	{
		SettingsManager sm = new SettingsManager(new EfSettingsDal());
		[AllowAnonymous]
		public ActionResult Index()
		{
			var setList = sm.GetAll();
			return View(setList);
		}
		public ActionResult ASetList()
		{
			var setlist = sm.GetAll();
			return View(setlist);
		}
		[HttpGet]
		public ActionResult ASettingUpdate(int id)
		{
			var set = sm.GetByID(id);
			return View(set);
		}
		[HttpPost]
		public ActionResult ASettingUpdate(Settings a)
		{
			sm.SettingsUpdate(a);
			return RedirectToAction("ASetList");

		}
	}
}