using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
	public class Context:DbContext
	{
		public DbSet<About> Abouts { get; set; }		
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Galeri> Galeries { get; set; }
		public DbSet<Services> Services { get; set; }
		public DbSet<Settings> Settings { get; set; }
		public DbSet<Slider> Sliders { get; set; }
	}
}
