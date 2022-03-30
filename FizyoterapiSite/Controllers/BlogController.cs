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
	public class BlogController : Controller
	{
		BlogManager bm = new BlogManager(new EfBlogDal());
		Context c = new Context();
		[AllowAnonymous]
		public ActionResult Index(int page=1)
		{
			var blogList = bm.GetStatusTrue().ToPagedList(page,4);
			return View(blogList);
		}
		[AllowAnonymous]
		public ActionResult BlogDetails(int id)
		{
			var idBlog = bm.GetBlogByID(id);
			return View(idBlog);
		}
		public ActionResult ABlogList()
		{
			var bloglist = bm.GetAll().OrderByDescending(z => z.BlogDate).ToList();
			return View(bloglist);
		}
		[HttpGet]
		public ActionResult ANewBlog()
		{
			return View();
		}
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult ANewBlog(Blog b)
		{

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);

			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 999999999).ToString() + uzanti;

			string way = "~/Image/Blog/" + filename;
			b.Image = "/Image/Blog/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					Request.Files[0].SaveAs(Server.MapPath(way));
					b.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
					b.Status = false;
					bm.BlogAdd(b);
					return RedirectToAction("ABlogList");
				}
				else
				{
					ViewBag.hata = "Dosya uzantısı yükleme için uygun değil. Uygun olan uzantılar : .jpg, .jpeg, .png";
				}
			}
			return View();
		}
		public ActionResult ADeleteBlog(int id)
		{
			var idgal = bm.GetByID(id);
			var filename = Request.MapPath("~" + idgal.Image);
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			bm.BlogDelete(idgal);
			return RedirectToAction("ABlogList");
		}
		public ActionResult ABlogDoFalse(int id)
		{
			var idser = bm.GetByID(id);
			idser.Status = false;
			bm.BlogUpdate(idser);
			return RedirectToAction("ABlogList");
		}
		public ActionResult ABlogDoTrue(int id)
		{
			var idser = bm.GetByID(id);
			idser.Status = true;
			bm.BlogUpdate(idser);
			return RedirectToAction("ABlogList");
		}
		[HttpGet]
		public ActionResult ABlogUpdate(int id)
		{
			var idserv = bm.GetByID(id);
			return View(idserv);
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult ABlogUpdate(Blog b)
		{

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);

			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 999999999).ToString() + uzanti;

			string way = "~/Image/Blog/" + filename;
			b.Image = "/Image/Blog/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					Request.Files[0].SaveAs(Server.MapPath(way));
					b.BlogDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
					b.Status = false;
					bm.BlogUpdate(b);
					return RedirectToAction("ABlogList");

				}
				else
				{
					ViewBag.hata = "Dosya uzantısı yükleme için uygun değil. Uygun olan uzantılar : .jpg, .jpeg, .png";
				}
			}
			if (!System.IO.File.Exists(b.Image))
			{

				string resim = c.Blogs.Where(x => x.BlogId == b.BlogId).Select(z => z.Image).FirstOrDefault();
				b.Image = resim;
				b.Status = false;
				b.BlogDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
				bm.BlogUpdate(b);
				return RedirectToAction("ABlogList");

			}
			return View();
		}
	}
}