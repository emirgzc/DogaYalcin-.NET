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
	public class GaleriController : Controller
	{
		GaleriManager gm = new GaleriManager(new EfGaleriDal());
		[AllowAnonymous]
		public ActionResult Index(int page=1)
		{
			var galeriList = gm.GetListStatusTrue().ToPagedList(page,12);
			return View(galeriList);
		}
		public ActionResult AGaleriList()
		{
			var galery = gm.GetAll();
			return View(galery);
		}
		[HttpGet]
		public ActionResult AGaleriAdd()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AGaleriAdd(Galeri g)
		{

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 99999999).ToString() + uzanti;
			string way = "~/Image/Galeri/" + filename;
			g.Image = "/Image/Galeri/" + filename;

			if (Request.Files.Count > 0)
			{
				Request.Files[0].SaveAs(Server.MapPath(way));
				g.Status = true;
				g.DateImage = DateTime.Parse(DateTime.Now.ToLongTimeString());
				gm.GaleriAdd(g);
				return RedirectToAction("AGaleriList");
			}
			return View();
		}
		public ActionResult AGaleriDelete(int id)
		{
			var idgal = gm.GetByID(id);
			var filename = Request.MapPath("~" + idgal.Image);
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			gm.GaleriDelete(idgal);
			return RedirectToAction("AGaleriList");
		}
		public ActionResult AGaleriDoFalse(int id)
		{
			var idser = gm.GetByID(id);
			idser.Status = false;
			gm.GaleriUpdate(idser);
			return RedirectToAction("AGaleriList");
		}
		public ActionResult AGaleriDoTrue(int id)
		{
			var idser = gm.GetByID(id);
			idser.Status = true;
			gm.GaleriUpdate(idser);
			return RedirectToAction("AGaleriList");
		}
	}
}