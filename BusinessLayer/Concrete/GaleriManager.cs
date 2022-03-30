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
	public class GaleriManager:IGaleriService
	{
		IGaleriDal _galeriDal;

		public GaleriManager(IGaleriDal galeriDal)
		{
			_galeriDal = galeriDal;
		}

		public void GaleriAdd(Galeri galeri)
		{
			_galeriDal.Add(galeri);
		}

		public void GaleriDelete(Galeri galeri)
		{
			_galeriDal.Delete(galeri);
		}

		public void GaleriUpdate(Galeri galeri)
		{
			_galeriDal.Update(galeri);
		}

		public List<Galeri> GetAll()
		{
			return _galeriDal.GetAll();
		}

		public Galeri GetByID(int id)
		{
			return _galeriDal.Get(x => x.PhotoId == id);
		}

		public List<Galeri> GetGaleriByID(int id)
		{
			return _galeriDal.GetAll(x => x.PhotoId == id);
		}

		public List<Galeri> GetListStatusTrue()
		{
			return _galeriDal.GetAll(x=>x.Status==true);
		}
	}
}
