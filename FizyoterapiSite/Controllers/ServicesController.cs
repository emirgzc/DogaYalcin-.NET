using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FizyoterapiSite.Controllers
{
	public class ServicesController : Controller
	{
		ServiceManager sm = new ServiceManager(new EfServicesDal());
		Context c = new Context();
		[AllowAnonymous]
		public ActionResult Index(int page=1)
		{
			var serviceList = sm.GetListStatusTrue().ToPagedList(page,6);
			return View(serviceList);
		}
		[AllowAnonymous]
		public ActionResult ServicesDetails(int id)
		{
			var idService = sm.GetServicesByID(id);
			return View(idService);
		}
		[AllowAnonymous]
		public PartialViewResult AnaServices()
		{
			var idService = sm.GetListStatusTrue().Take(6);
			return PartialView(idService);
		}
		public ActionResult AServiceList()
		{
			var listservice = sm.GetAll();
			return View(listservice);
		}
		[HttpGet]
		public ActionResult AServiceAdd()
		{
			return View();
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult AServiceAdd(Services s)
		{
			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
			string way = "~/Image/Services/" + filename;
			s.Image = "/Image/Services/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					Request.Files[0].SaveAs(Server.MapPath(way));
					s.Status = true;
					sm.ServicesAdd(s);
					return RedirectToAction("AServiceList");
				}
				else
				{
					ViewBag.hata = "Dosya uzantısı yükleme için uygun değil. Uygun olan uzantılar : .jpg, .jpeg, .png";
				}
			}
			return View();
		}
		public ActionResult AServiceDoTrue(int id)
		{
			var idser = sm.GetByID(id);
			idser.Status = true;
			sm.ServicesUpdate(idser);
			return RedirectToAction("AServiceList");
		}
		public ActionResult AServiceDoFalse(int id)
		{
			var idser = sm.GetByID(id);
			idser.Status = false;
			sm.ServicesUpdate(idser);
			return RedirectToAction("AServiceList");
		}
		public ActionResult AServiceDelete(int id)
		{
			var idgal = sm.GetByID(id);
			var filename = Request.MapPath("~" + idgal.Image);
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			sm.ServicesDelete(idgal);
			return RedirectToAction("AServiceList");
		}
		[HttpGet]
		public ActionResult AServiceUpdate(int id)
		{
			var idserv = sm.GetByID(id);
			return View(idserv);
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult AServiceUpdate(Services s)
		{

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
			string way = "~/Image/Services/" + filename;
			s.Image = "/Image/Services/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					Request.Files[0].SaveAs(Server.MapPath(way));
					s.Status = false;
					sm.ServicesUpdate(s);
					return RedirectToAction("AServiceList");

				}
				else
				{
					ViewBag.hata = "Dosya uzantısı yükleme için uygun değil. Uygun olan uzantılar : .jpg, .jpeg, .png";
				}
			}
			if (!System.IO.File.Exists(s.Image))
			{

				string resim = c.Services.Where(x => x.ServicesId == s.ServicesId).Select(z => z.Image).FirstOrDefault();
				s.Image = resim;
				s.Status = false;
				sm.ServicesUpdate(s);
				return RedirectToAction("AServiceList");

			}
			return View();
		}
	}
}