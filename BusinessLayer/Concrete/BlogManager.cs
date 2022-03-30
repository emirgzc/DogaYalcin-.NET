using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}
		public void BlogAdd(Blog blog)
		{
			_blogDal.Add(blog);
		}

		public void BlogDelete(Blog blog)
		{
			_blogDal.Delete(blog);
		}

		public void BlogUpdate(Blog blog)
		{
			_blogDal.Update(blog);
		}

		public List<Blog> GetAll()
		{
			return _blogDal.GetAll();
		}

		public List<Blog> GetBlogByID(int id)
		{
			return _blogDal.GetAll(x => x.BlogId == id);
		}

		public Blog GetByID(int id)
		{
			return _blogDal.Get(x => x.BlogId == id);
		}

		public List<Blog> GetStatusTrue()
		{
			return _blogDal.GetAll(x => x.Status == true).OrderByDescending(z => z.BlogDate).ToList();
		}
	}
}
