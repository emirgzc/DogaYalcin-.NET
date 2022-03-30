using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FizyoterapiSite.Controllers
{
	public class SliderController : Controller
	{
		SliderManager sm = new SliderManager(new EfSliderDal());
		SettingsManager smm = new SettingsManager(new EfSettingsDal());
		Context c = new Context();
		[AllowAnonymous]
		public ActionResult Index()
		{
			var sliderList = sm.GetListStatusTrue();
			return View(sliderList);
		}
		[AllowAnonymous]
		public PartialViewResult Footer()
		{
			return PartialView();
		}
		[AllowAnonymous]
		public PartialViewResult SocialMedia()
		{
			var mediaList = smm.GetAll();
			return PartialView(mediaList);
		}
		[AllowAnonymous]
		public PartialViewResult ContactPhone()
		{
			var mediaList = smm.GetAll();
			return PartialView(mediaList);
		}
		public ActionResult ASliderList()
		{
			var list = sm.GetAll().OrderByDescending(z => z.SliderAddDate).ToList();
			return View(list);
		}
		public ActionResult ASliderDoFalse(int id)
		{
			var idser = sm.GetByID(id);
			idser.Status = false;
			sm.SliderUpdate(idser);
			return RedirectToAction("ASliderList");
		}
		public ActionResult ASliderDoTrue(int id)
		{
			var idser = sm.GetByID(id);
			idser.Status = true;
			sm.SliderUpdate(idser);
			return RedirectToAction("ASliderList");
		}
		[HttpGet]
		public ActionResult ASliderUpdate(int id)
		{
			var idserv = sm.GetByID(id);
			return View(idserv);
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult ASliderUpdate(Slider s)
		{

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
			string way = "~/Image/Slider/" + filename;
			s.Image = "/Image/Slider/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					Request.Files[0].SaveAs(Server.MapPath(way));
					s.Status = false;
					s.SliderAddDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
					sm.SliderUpdate(s);
					return RedirectToAction("ASliderList");
				}
				else
				{
					ViewBag.hata = "Dosya uzantısı yükleme için uygun değil. Uygun olan uzantılar : .jpg, .jpeg, .png";
				}
			}
			if (!System.IO.File.Exists(s.Image))
			{
				string resim = c.Sliders.Where(x => x.SliderId == s.SliderId).Select(z => z.Image).FirstOrDefault();
				s.Image = resim;
				s.Status = false;
				s.SliderAddDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
				sm.SliderUpdate(s);
				return RedirectToAction("ASliderList");
			}
			return View();
		}
	}
}