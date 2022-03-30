using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogService
	{
        List<Blog> GetAll();
        List<Blog> GetStatusTrue();
        List<Blog> GetBlogByID(int id);
        Blog GetByID(int id);
        void BlogAdd(Blog blog);
        void BlogUpdate(Blog blog);
        void BlogDelete(Blog blog);
    }
}
